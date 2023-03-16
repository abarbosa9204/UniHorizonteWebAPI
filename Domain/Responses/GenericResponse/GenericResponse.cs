using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Responses.GenericResponses
{
    public class GenericResponse
    {
        public int Status { get; set; } = 200;
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
        public string? ErrorMessage { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
