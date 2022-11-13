using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Owner.API.Data;
using Owner.API.Model;
using Owner.API.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Owner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        IOwnerCrudRepository crudRepository;

        public OwnerController(IOwnerCrudRepository crudRepository)
        {
            //Bağımlılığı azaltmak için dependency injection kullandım.
            this.crudRepository = crudRepository;
        }

        /// <summary>
        /// List all owners
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Model.Owner))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("Owners")]
        public IActionResult Get()
        {
            var ownerList = crudRepository.GetAllOwner();
            return Ok(ownerList);
        }

        /// <summary>
        /// Create new owner
        /// </summary>
        /// <param name="newOrwner"></param>
        /// <returns>Owner</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Model.Owner))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        [Route("NewOwner")]
        [Consumes("application/json")]
        public IActionResult Post(Model.Owner newOwner)
        {
            if (newOwner.Description.ToLower().Contains("hack"))
            {
                return BadRequest("The description section should not contain the word 'hack'");
            }
            crudRepository.Create(newOwner);
            return Ok(newOwner);
        }

        /// <summary>
        /// Update owner
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ownerToUpdate"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Model.Owner))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        [Route("UpdateOwner")]
        public IActionResult Update(int id, Model.Owner ownerToUpdate)
        {
            if (id == ownerToUpdate.Id && ownerToUpdate != null)
            {
                Model.Owner owner = crudRepository.Update(id, ownerToUpdate);
                if (owner != null) return Ok(ownerToUpdate);
                else return NotFound($"{id} not found! ");
            }
            return BadRequest("Id did not match!");
        }

        /// <summary>
        /// Delete owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Model.Owner))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [Route("DeleteOwner")]
        public IActionResult Delete(int id)
        {
            bool isDeleted = crudRepository.Delete(id);
            if (isDeleted) return Ok($"Owner deleted.");
            else return NotFound($"{id} not found! ");
        }
    }
}
