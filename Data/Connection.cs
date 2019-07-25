using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ConexiuneBD  // am incercat sa fac o clasa separata care sa gestioneze conexiunea, dar nu am reusit, dupa ce initializam un nou obiect ConesiuneBD, nu-mi gasea obiectul(variabila)
    {
        public const string connectionString = "Data Source=.; Initial Catalog=w14;Integrated Security=True;";
        public readonly SqlConnection conexiune;

        public ConexiuneBD()
        {
            conexiune = new SqlConnection(connectionString);
            conexiune.Open();            
        }

    }
}
