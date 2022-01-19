using System;
using System.Collections.Generic;

#nullable disable

namespace ToDoApp.Models.Domains
{
    public partial class UsersTask
    {
        public UsersTask()
        {
            ShopLists = new HashSet<ShopList>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ShopListId { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public string Information { get; set; }
        public bool IsRemainderSelected { get; set; }
        public DateTime? ReminderTime { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsShopListAdded { get; set; }
        public bool IsArch { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ShopList> ShopLists { get; set; }
    }
}
