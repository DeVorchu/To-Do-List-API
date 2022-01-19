using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Models.Converters;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.Response;

namespace ToDoApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public UserController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        [EnableCors]
        public DataResponse<UserDto> Get(int id)
        {
            var response = new DataResponse<UserDto>();

            try
            {
                response.Data = _unitOfWork.User.Get(id)?.ToDto();
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }

        [HttpPost]
        [EnableCors]
        public DataResponse<int> Add(UsersTaskDto userTask)
        {
            var response = new DataResponse<int>();

            try
            {
                var userTasker = userTask.ToDao();
                _unitOfWork.UsersTask.Add(userTasker);
                _unitOfWork.Complete();
                response.Data = userTasker.Id;
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }

        [HttpPut]
        [EnableCors]
        public Response Update(UsersTaskDto userTask)
        {
            var response = new Response();

            try
            {
                _unitOfWork.UsersTask.Update(userTask.ToDao());
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }

        [HttpDelete("{id}")]
        [EnableCors]
        public Response Update(int id)
        {
            var response = new Response();

            try
            {
                _unitOfWork.UsersTask.Delete(id);
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }
    }
}
