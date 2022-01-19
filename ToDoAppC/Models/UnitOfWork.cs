using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models.Domains;
using ToDoApp.Models.Repositories;

namespace ToDoApp.Models
{
    public class UnitOfWork
    {
        private readonly db_e337Context _context;

        

        public UnitOfWork(db_e337Context context)
        {
            _context = context;
            User = new UserRepository(context);
            UsersTask = new UserTasksRepository(context);
            UserShopList = new ShopListRepository(context);
        }

        public UserRepository User { get; }
        public UserTasksRepository UsersTask { get; set; }
        public ShopListRepository UserShopList { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
