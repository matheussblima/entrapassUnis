using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

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

        SqlConnection sqlConnection;

        public PessoaUnis(string serverName, string nameDataBase, string ID, string userName)
        {
            this.serverName = serverName;
            this.ID = ID;
            this.userName = userName;
            this.nameDataBase = nameDataBase;

            //STRING DE CONEXÃO
            connectionString = string.Format("Server={0};Database={1};User Id={2};Password = {3};", this.serverName, this.nameDataBase, this.ID, this.userName);
        }

        private bool openConnection()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                MessageBox.Show("coenctou");
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show("NAO coenctou");
                return false;
            }
        }

        private bool closeConnection()
        {
            try
            {
                sqlConnection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable SelectDatePessoas(string date)
        {
            try
            {
                bool connection = openConnection();
                if (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand(string.Format("SELECT * FROM tUser WHERE C_UdatePassword >= {0}", date), sqlConnection);
                    //SqlCommand sqlCommand = new SqlCommand(string.Format("SELECT * FROM tUser"), sqlConnection);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    closeConnection();
                    return dataTable;
                }
                else
                {
                    closeConnection();
                    return null;
                }
            }
            catch (Exception e)
            {
                closeConnection();
                return null;
            }
        }
    }
}