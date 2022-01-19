using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models.Domains;

namespace ToDoApp.Models.Repositories
{
    public class ShopListRepository
    {
        private readonly db_e337Context _context;

        public ShopListRepository(db_e337Context context)
        {
            _context = context;
        }


        public ShopList Get(int id)
        {
            return _context.ShopLists.FirstOrDefault(x => x.Id == id);
        }

        public void Add(ShopList shopList)
        {
            _context.Add(shopList);
        }

        public void Update(ShopList shopList)
        {
            var listToUpdate = _context.ShopLists.FirstOrDefault(x => x.Id == shopList.Id);

            listToUpdate.Id = shopList.Id;
            listToUpdate.Title = shopList.Title;
            listToUpdate.Items = shopList.Items;

        }

        public void Delete(int id)
        {
            var listToDelete = _context.ShopLists.FirstOrDefault(x => x.Id == id);
            _context.Remove(listToDelete);
        }
    }
}
