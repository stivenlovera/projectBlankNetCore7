using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace comisionesapi.Querys
{
    public class AdministracionRedQuery
    {
        public string demo()
        {
            return @"
            SELECT AR.dtfechamod,AR.dtfechaadd
                FROM AdministracionRed as AR
            WHERE
                AR.lpatrocinador2g = '608'
                AND AR.lpatrocinador1g = '85062';
            ";
        }
    }
}