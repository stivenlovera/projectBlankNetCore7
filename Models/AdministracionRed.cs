using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace comisionesapi.Models
{
    [Keyless]
    public class AdministracionRed
    {
        public string susuarioadd { get; set; }
        public int lcontacto_id { get; set; }
        public DateTime dtfechamod { get; set; }
    }
}