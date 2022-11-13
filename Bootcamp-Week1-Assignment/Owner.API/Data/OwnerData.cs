using System;
using System.Collections.Generic;

namespace Owner.API.Data
{
    public static class OwnerData
    {
        public static List<Model.Owner> AllOwner()
        {
            return new List<Model.Owner>
            {
                new Model.Owner { Id = 1, Name = "John", Surname="Doe", Date=DateTime.Now, Description="Once upon a time", Type="Human" },
                new Model.Owner { Id = 2, Name = "Jane", Surname="Doe", Date=DateTime.Now, Description="Once upon a hack", Type="Human" },
                new Model.Owner { Id = 3, Name = "Jamie", Surname="Doe", Date=DateTime.Now, Description="Once upon a time", Type="Human" },
                new Model.Owner { Id = 4, Name = "Johny", Surname="Doe", Date=DateTime.Now, Description="Once upon a time", Type="Human" }
            };
        }
    }
}
