using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace comisionesapi.Dtos
{
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object data { get; set; }
    }
}