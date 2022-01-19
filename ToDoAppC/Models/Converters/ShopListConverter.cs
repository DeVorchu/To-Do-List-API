using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models.Domains;
using ToDoApp.Models.Dtos;

namespace ToDoApp.Models.Converters
{
    public static class ShopListConverter
    {
        public static ShopListDto ToDto(this ShopList model)
        {
            return new ShopListDto
            {
                Id = model.Id,
                UserId = model.UserId,
                TaskId = model.TaskId,
                Title = model.Title,
                Items = model.Items              
            };
        }

        public static IEnumerable<ShopListDto> ToDtos(this IEnumerable<ShopList> model)
        {
            if (model == null)
            {
                return Enumerable.Empty<ShopListDto>();
            }
            else
            {
                return model.Select(x => x.ToDto());
            }
        }

        public static ShopList ToDao(this ShopListDto model)
        {
            return new ShopList
            {
                Id = model.Id,
                UserId = model.UserId,
                TaskId = model.TaskId,
                Title = model.Title,
                Items = model.Items
            };
        }
    }
}
