using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBackEnd.DAL
{
    class ConnectionDAL
    {
        private string _connectionstring;
        public void Dal(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("Default");
        }
    }
}
