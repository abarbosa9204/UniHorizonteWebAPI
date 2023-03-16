using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Responses.GenericResponses
{
    public interface IGenericResponseFactory
    {
        public GenericResponse GetOK(object resultData);
        public GenericResponse GetCreated(object resultData);
        public GenericResponse GetNoContent();
        public GenericResponse GetError(Exception exception);
        public GenericResponse GetErrorValidation(string message);
    }
}
