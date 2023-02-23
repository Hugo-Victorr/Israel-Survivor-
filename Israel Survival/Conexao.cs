using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Israel_Survival
{
    public class Conexao
    {
        SqlConnection conex = new SqlConnection();

        //construtor
        public Conexao()
        {
            conex.ConnectionString = "Data Source=HUGO;Initial Catalog=teste;Integrated Security=True";
        }

        //metodo conectar
        public SqlConnection conectar()
        {
            if (conex.State == System.Data.ConnectionState.Closed)
            {
                conex.Open();
            }

            return conex; 
        }

        //metodo desconctar
        public void desconectar()
        {
            if (conex.State == System.Data.ConnectionState.Open)
            {
                conex.Close();
            }
        }

    }
}
