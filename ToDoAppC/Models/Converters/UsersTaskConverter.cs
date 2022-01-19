using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models.Domains;
using ToDoApp.Models.Dtos;

namespace ToDoApp.Models.Converters
{
    public static class UsersTaskConverter
    {
        public static UsersTaskDto ToDto(this UsersTask model)
        {
            return new UsersTaskDto
            {
                Id = model.Id,
                UserId = model.UserId,
                ShopListId = (int)model.ShopListId,
                Title = model.Title,
                Date = (DateTime)model.Date,
                Information = model.Information,
                IsRemainderSelected = model.IsRemainderSelected,
                ReminderTime = (DateTime)model.ReminderTime,
                ReminderDate = (DateTime)model.ReminderDate,
                IsShopListAdded = model.IsShopListAdded,
                IsArch = model.IsArch,
                User = model.User,
                ShopLists = model.ShopLists
            };
        }

        public static IEnumerable<UsersTaskDto> ToDtos(this IEnumerable<UsersTask> model)
        {
            if(model == null)
            {
                return Enumerable.Empty<UsersTaskDto>();
            } else
            {
                return model.Select(x => x.ToDto());
            }
        }

        public static UsersTask ToDao(this UsersTaskDto model)
        {
            return new UsersTask
            {
                Id = model.Id,
                UserId = model.UserId,
                ShopListId = model.ShopListId,
                Title = model.Title,
                Date = model.Date,
                Information = model.Information,
                IsRemainderSelected = model.IsRemainderSelected,
                ReminderTime = model.ReminderTime,
                ReminderDate = model.ReminderDate,
                IsShopListAdded = model.IsShopListAdded,
                IsArch = model.IsArch,
                User = model.User,
                ShopLists = model.ShopLists
            };
        }
    }
}
