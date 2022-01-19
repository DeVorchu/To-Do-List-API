using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models.Domains;

namespace ToDoApp.Models.Dtos
{
    public class ShopListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? TaskId { get; set; }
        public string Title { get; set; }
        public string Items { get; set; }

        public virtual UsersTask Task { get; set; }
        public virtual User User { get; set; }
    }
}
