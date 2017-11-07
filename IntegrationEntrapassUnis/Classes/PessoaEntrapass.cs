using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advantage.Data.Provider;
using System.Windows.Forms;

namespace EntrapassUnisIntegration.Classes
{
    class PessoaEntrapass
    {
        //ARGUMENTOS
        AdsConnection adsConnection;

        string serverSource;

        public PessoaEntrapass(string serverSource)
        {
            this.serverSource = serverSource;

          
        }


        public void selectPessoas()
        {
            openConnection(serverSource);

            int iField;
            AdsCommand adsCommand = adsConnection.CreateCommand();
            adsCommand.CommandText = "SELECT * FROM Card";
           AdsDataReader adsDataReader = adsCommand.ExecuteReader();


            // dump the results of the query to the console
            while (adsDataReader.Read())
            {
                for (iField = 0; iField < adsDataReader.FieldCount; iField++)
                    MessageBox.Show(adsDataReader.GetValue(iField) + " ");
            }



        }

        private bool closeConnection()
        {
            try
            {
                adsConnection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool openConnection(string serverSource)
        {
            try
            {
                //CONEXÃO
                adsConnection = new AdsConnection(string.Format("data source={0};" + "ServerType=remote|local; TableType=ADT", serverSource));

                adsConnection.Open();
                AdsCommand adsCommand = adsConnection.CreateCommand();
                adsCommand.CommandText = "EXECUTE PROCEDURE sp_AllowMultipleCollations('GENERAL_VFP_CI_AS_1252', true );";
                int returnCommand = adsCommand.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
