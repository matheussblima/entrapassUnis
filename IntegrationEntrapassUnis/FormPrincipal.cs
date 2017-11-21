using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntegrationEntrapassUnis;
using EntrapassUnisIntegration.Classes;
using Microsoft.Win32;
using System.Data.SqlClient;

namespace IntegrationEntrapassUnis
{
    public partial class FormPrincipal : Form
    {
        const string CHAVE_DATA_ATUALIZACAO = "ultimaAtualizacao";

        string subKey = "SOFTWARE\\" + Application.ProductName;
        RegistryKey baseRegistryKey = Registry.LocalMachine;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void buttonConectar_Click(object sender, EventArgs e)
        {

            string regRead = RegRead(CHAVE_DATA_ATUALIZACAO);

            if (regRead == null) // se é a primeira vez que executa o programa..
            {
                RegWrite("ultimaAtualizacao", DateTime.Now.ToString("19900925141719")); // coloca a data de 99 para forçar a atualizar todas as pessoas
            }

            SincronizarBD();
        }

        public void SincronizarBD()
        {
            string dataUltimaAtualizacao = RegRead(CHAVE_DATA_ATUALIZACAO);

            PessoaUnis pessoaUnis = new PessoaUnis("DESKTOP-57NJIV7\\SQLEXPRESS", "UNIS", "unisuser", "unisamho");
            DataTable pessoaUnisTable = pessoaUnis.SelectDatePessoas(dataUltimaAtualizacao);

            //PessoaEntrapass pessoaEntrapass = new PessoaEntrapass(@"c:\Program Files (x86)\Kantech\Server_CE_Demo\Data");

            //pessoaEntrapass.selectPessoas();


            if (pessoaUnisTable != null)
            {
                foreach (DataRow row in pessoaUnisTable.Rows)
                {
                    string id = row["L_ID"].ToString();
                    string name = row["C_Name"].ToString();

                    string cardFormatted = id;

                    if (cardFormatted.Length < 10)
                    {
                        int amountOfZeros = 10 - cardFormatted.Length;

                        while (amountOfZeros > 0)
                        {
                            cardFormatted = '0' + cardFormatted;
                            amountOfZeros--;
                        }

                        string startCardFormatted = cardFormatted.Substring(0,5);
                        string endCardFormatted = cardFormatted.Substring(5, 5);
                        cardFormatted = startCardFormatted + ":" + endCardFormatted;
                    }

                   string dateAndHourCreate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                   string dateCreate = DateTime.Now.ToString("dd/MM/yyyy 00:00:00");

                    // pessoaEntrapass.insertPessoas(id, name, dateAndHourCreate, cardFormatted, cardNumber, dateCreate, dateCreate);
                }
            }

            RegWrite("ultimaAtualizacao", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }


        public string RegRead(string KeyName)
        {
            RegistryKey rk = baseRegistryKey;
            RegistryKey sk1 = rk.OpenSubKey(subKey);

            if (sk1 == null)
            {
                return null;
            }
            else
            {
                try
                {
                    return (string)sk1.GetValue(KeyName);
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro de Registro " + erro);
                    return null;
                }
            }
        }

        public bool RegWrite(string KeyName, object Value)
        {
            try
            {
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(subKey);
                sk1.SetValue(KeyName, Value);

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Writing registry: " + e.Message);
                return false;
            }
        }
    }
}
