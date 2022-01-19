using System;
using System.Collections.Generic;

#nullable disable

namespace ToDoApp.Models.Domains
{
    public partial class User
    {
        public User()
        {
            ShopLists = new HashSet<ShopList>();
            UsersTasks = new HashSet<UsersTask>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Bdate { get; set; }
        public string Mail { get; set; }
        public string SecretCode { get; set; }

        public virtual ICollection<ShopList> ShopLists { get; set; }
        public virtual ICollection<UsersTask> UsersTasks { get; set; }
    }
}
