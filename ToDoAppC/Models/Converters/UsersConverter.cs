using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models.Domains;
using ToDoApp.Models.Dtos;

namespace ToDoApp.Models.Converters
{
    public static class UsersConverter
    {
        public static UserDto ToDto(this User model)
        {
            return new UserDto
            {
                Id = model.Id,
                Login = model.Login,
                Password = model.Password,
                Bdate = model.Bdate,
                Mail = model.Mail,
                SecretCode = model.SecretCode,
                ShopLists = model.ShopLists,
                UsersTasks = model.UsersTasks
            };
        }

        public static IEnumerable<UserDto> ToDtos(this IEnumerable<User> model)
        {
            if (model == null)
            {
                return Enumerable.Empty<UserDto>();
            }
            else
            {
                return model.Select(x => x.ToDto());
            }
        }

        public static User ToDao(this UserDto model)
        {
            return new User
            {
                Id = model.Id,
                Login = model.Login,
                Password = model.Password,
                Bdate = model.Bdate,
                Mail = model.Mail,
                SecretCode = model.SecretCode,
                ShopLists = model.ShopLists,
                UsersTasks = model.UsersTasks
            };
        }
    }
}
