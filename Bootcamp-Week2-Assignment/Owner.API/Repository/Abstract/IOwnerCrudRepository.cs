using System.Collections.Generic;

namespace Owner.API.Repository.Abstract
{
    public interface IOwnerCrudRepository
    {
        List<Model.Owner> GetAllOwner();
        void Create(Model.Owner owner);
        Model.Owner Update(int id, Model.Owner owner);
        bool Delete(int id);

    }
}
