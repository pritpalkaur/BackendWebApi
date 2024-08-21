using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Data.Interface
{
    public interface IDbConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
