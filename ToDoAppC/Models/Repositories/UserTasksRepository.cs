using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models.Domains;

namespace ToDoApp.Models.Repositories
{
    public class UserTasksRepository
    {
        private readonly db_e337Context _context;

        public UserTasksRepository(db_e337Context context)
        {
            _context = context;
        }


        public IEnumerable<UsersTask> Get()
        {
            return _context.UsersTasks;
        }

        public UsersTask Get(int id)
        {
            return _context.UsersTasks.FirstOrDefault(x => x.Id == id);
        }

        public void Add(UsersTask userTask)
        {
            _context.Add(userTask);
        }

        public void Update(UsersTask userTask)
        {
            var taskToUpdate = _context.UsersTasks.FirstOrDefault(x => x.Id == userTask.Id);

            taskToUpdate.Id = userTask.Id;
            taskToUpdate.ShopListId = userTask.ShopListId;
            taskToUpdate.Title = userTask.Title;
            taskToUpdate.Date = userTask.Date;
            taskToUpdate.Information = userTask.Information;
            taskToUpdate.IsRemainderSelected = userTask.IsRemainderSelected;
            taskToUpdate.ReminderTime = userTask.ReminderTime;
            taskToUpdate.ReminderDate = userTask.ReminderDate;
            taskToUpdate.IsShopListAdded = userTask.IsShopListAdded;
            taskToUpdate.IsArch = userTask.IsArch;

        }

        public void Delete(int id)
        {
            var taskToDelete =  _context.UsersTasks.FirstOrDefault(x => x.Id == id);
            _context.Remove(taskToDelete);
        }
    }
}
