using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models.Response
{
    public class Response
    {
        public Response()
        {
            Errors = new List<Error>();
        }

        public List<Error> Errors { get; set; }
        public bool IsSucces => Errors == null || !Errors.Any();

        
    }
}
