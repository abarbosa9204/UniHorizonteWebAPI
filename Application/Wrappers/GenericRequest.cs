using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Responses.GenericResponses;

using MediatR;

namespace Application.Wrappers {
  public class GenericRequest<T> : IRequest<GenericResponse> where T : class { 
    public T Body { get; set; }
  }
}
