using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models.Domains;

namespace ToDoApp.Models.Dtos
{
    public class UserDto
    {
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
