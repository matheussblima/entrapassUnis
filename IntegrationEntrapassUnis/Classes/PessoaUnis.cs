using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EntrapassUnisIntegration.Classes
{
    class PessoaUnis
    {
        //ARGUMENTOS
        string serverName;
        string ID;
        string userName;
        string connectionString;
        string nameDataBase;

        public PessoaUnis(string serverName, string nameDataBase, string ID, string userName)
        {
            this.serverName = serverName;
            this.ID = ID;
            this.userName = userName;
            this.nameDataBase = nameDataBase;

            //STRING DE CONEXÃO
            connectionString = string.Format("Server={0};Database={1};User Id={2};Password = {3};", this.serverName, this.nameDataBase, this.ID, this.userName);

        }

        public bool openConnection()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void selectPessoas()
        {
            
        }
    }
}
