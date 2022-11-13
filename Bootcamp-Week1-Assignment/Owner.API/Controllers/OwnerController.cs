using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Owner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        public static List<Model.Owner> AllOwners = new List<Model.Owner>()
        {
                new Model.Owner { Id = 1, Name = "John", Surname="Doe", Date=DateTime.Now, Description="Once upon a time", Type="Human" },
                new Model.Owner { Id = 2, Name = "Jane", Surname="Doe", Date=DateTime.Now, Description="Once upon a hack", Type="Human" },
                new Model.Owner { Id = 3, Name = "Jamie", Surname="Doe", Date=DateTime.Now, Description="Once upon a time", Type="Human" },
                new Model.Owner { Id = 4, Name = "Johny", Surname="Doe", Date=DateTime.Now, Description="Once upon a time", Type="Human" }
        };

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
            var ownerList = AllOwners.OrderBy(x => x.Id).ToList();
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
            var owner = AllOwners.SingleOrDefault(x => x.Id == newOwner.Id);
            if (owner is not null)
                return BadRequest($"There is a user with this id");
            else if (newOwner.Description.ToLower().Contains("hack"))
                return BadRequest("The description section should not contain the word 'hack'");
            else
            {
                AllOwners.Add(newOwner);
                return Ok(newOwner);
            }
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
            var owner = AllOwners.FirstOrDefault(x => x.Id == id);
            if (owner == null) return NotFound();

            owner.Name = ownerToUpdate.Name != default ? ownerToUpdate.Name : owner.Name;
            owner.Surname = ownerToUpdate.Surname != default ? ownerToUpdate.Surname : owner.Surname;
            owner.Description = ownerToUpdate.Description != default ? ownerToUpdate.Description : owner.Description;
            owner.Date = ownerToUpdate.Date != default ? ownerToUpdate.Date : owner.Date;
            owner.Type = ownerToUpdate.Type != default ? ownerToUpdate.Type : owner.Type;

            return Ok(ownerToUpdate);
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
            var ownerToDelete = AllOwners.FirstOrDefault(x => x.Id == id);
            if(ownerToDelete == null) return NotFound($"{id} not found! ");
            AllOwners.Remove(ownerToDelete);
            return Ok("Owner is deleted");
        }
    }
}
