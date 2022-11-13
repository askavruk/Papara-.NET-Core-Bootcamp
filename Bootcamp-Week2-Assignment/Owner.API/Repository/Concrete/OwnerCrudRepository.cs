using Owner.API.Data;
using Owner.API.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Owner.API.Repository
{
    public class OwnerCrudRepository : IOwnerCrudRepository
    {

        /// <summary>
        /// List all owners
        /// </summary>
        /// <returns></returns>
        public List<Model.Owner> GetAllOwner()
        {
            var ownerList = OwnerData.AllOwner();
            return ownerList;
        }

        /// <summary>
        /// Create new owner
        /// </summary>
        /// <param name="newOwner"></param>
        public void Create(Model.Owner newOwner)
        {
            var ownerList = OwnerData.AllOwner();
            ownerList.Add(newOwner);
        }

        /// <summary>
        /// Delete owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var ownerList = OwnerData.AllOwner();
            var owner = ownerList.FirstOrDefault(x => x.Id == id);
            if (owner != null)
            {
                ownerList.Remove(owner);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update owner
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        public Model.Owner Update(int id, Model.Owner owner)
        {
            var ownerList = OwnerData.AllOwner();
            var ownerToUpdate = ownerList.FirstOrDefault(x => x.Id == id);
            if (ownerToUpdate != null)
            {
                ownerToUpdate.Name = owner.Name != default ? ownerToUpdate.Name : owner.Name;
                ownerToUpdate.Surname = owner.Surname != default ? ownerToUpdate.Surname : owner.Surname;
                ownerToUpdate.Description = owner.Description != default ? ownerToUpdate.Name : owner.Name;
                ownerToUpdate.Date = owner.Date != default ? ownerToUpdate.Date : owner.Date;
                ownerToUpdate.Type = owner.Type != default ? ownerToUpdate.Type : owner.Type;

                return ownerToUpdate;
            }
            else return null;

        }

    }
}
