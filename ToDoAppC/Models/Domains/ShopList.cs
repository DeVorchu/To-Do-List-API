using System;
using System.Collections.Generic;

#nullable disable

namespace ToDoApp.Models.Domains
{
    public partial class ShopList
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
