using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TMSA.PIZZARIA.Core.Data.Connection
{
    public abstract class ConnectionDB
    {
        private readonly IConfiguration _configuration;

        protected ConnectionDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("ConnectionDbApi"));
            }
        }
    }
}
