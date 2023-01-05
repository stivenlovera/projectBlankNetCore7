using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using comisionesapi.Context;

namespace comisionesapi.Repository
{
    public class AuthenticationRepository
    {
        private readonly ILogger<AuthenticationRepository> logger;
        private readonly DbMysqlServerContext dbMysqlServerContext;

        public AuthenticationRepository(
            ILogger<AuthenticationRepository> logger,
            IConfiguration configuration,
            DbMysqlServerContext DbMysqlServerContext
        )
        {
            this.logger = logger;
            this.dbMysqlServerContext = DbMysqlServerContext;
        }
        public string Method(string parameter)
        {
            return "";
        }
    }
}