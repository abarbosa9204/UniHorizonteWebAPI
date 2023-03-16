using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Responses {
  public class SignInResponse {
    public string token { get; set; }
    public string email { get; set; }
    public string name { get; set; }

    public string surname { get; set; }
  }
}
