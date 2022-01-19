using System.Linq;
using ToDoApp.Models.Domains;

namespace ToDoApp.Models.Repositories
{
    public class UserRepository
    {
        private readonly db_e337Context _context;

        public UserRepository(db_e337Context context)
        {
            _context = context;
        }


        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Add(User user)
        {
            _context.Add(user);
        }

        public void Update(User user)
        {
            var taskToUpdate = _context.Users.FirstOrDefault(x => x.Id == user.Id);

            taskToUpdate.Id = user.Id;
            taskToUpdate.Login = user.Login;
            taskToUpdate.Password = user.Password;
            taskToUpdate.Bdate = user.Bdate;
            taskToUpdate.Mail = user.Mail;
            taskToUpdate.SecretCode = user.Mail;
        }

        public void Delete(int id)
        {
            var userToDelete = _context.Users.FirstOrDefault(x => x.Id == id);
            _context.Remove(userToDelete);
        }
    }
}
