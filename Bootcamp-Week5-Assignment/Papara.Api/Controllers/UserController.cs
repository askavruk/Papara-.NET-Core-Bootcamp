using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Papara.Core.Dtos;
using Papara.Core.Entites;
using Papara.Core.Enums;
using Papara.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Papara.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly Func<CacheTech, ICacheService> _cacheService;
        private readonly IMapper mapper;

        public UserController(IUserRepository repository, Func<CacheTech, ICacheService> cacheService, IMapper mapper)
        {
            _repository = repository;
            _cacheService = cacheService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetDataFromApi")]
        public async Task GetDataFromApi()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                List<UserDto> users = JsonConvert.DeserializeObject<List<UserDto>>(data);

                var mapedUsers = mapper.Map<List<User>>(users);
                foreach (var item in mapedUsers)
                {
                    await _repository.AddAsync(item);
                }
            }
        }

        [HttpPost]
        [Route("RetrieveFromApi")]
        public IActionResult RetrieveFromApi()
        {
            RecurringJob.AddOrUpdate(() => GetDataFromApi(), "*/5 * * * * *");
            return Ok("Data is added every 5 seconds.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllUsers()
        {
            var users = _repository.GetAllAsync();
            return Ok(users);
        }
    }
}
