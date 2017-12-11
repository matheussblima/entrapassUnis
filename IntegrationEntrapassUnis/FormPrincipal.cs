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

        string g_NomeServidor = "DESKTOP-KCK7M7E\\SQLNOVO";
        string g_BD = "UNIS";
        string g_Usuario = "unisuser";
        string g_Senha = "unisamho";
        string g_CaminhoEntraPass = @"c:\Program Files (x86)\Kantech\Server_CE_Demo\Data";

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            tbServidor.Text = g_NomeServidor;
            tbBD.Text = g_BD;
            tbUsuario.Text = g_Usuario;
            tbSenha.Text = g_Senha;
            rbUsuarioSenha.Checked = true;
        }

        private void btSync_Click(object sender, EventArgs e)
        {
            string regRead = RegRead(CHAVE_DATA_ATUALIZACAO);

            if (regRead == null) // se é a primeira vez que executa o programa..
            {
                RegWrite("ultimaAtualizacao", DateTime.Now.ToString("19900925141719")); // coloca a data de 99 para forçar a atualizar todas as pessoas
            }

            SincronizarBD();
        }

        // carrega o que o usuário digitou nos campos para as variáveis internas do programa
        public bool LerCampos()
        {
            g_NomeServidor = tbServidor.Text;
            g_BD = tbBD.Text;
            g_Usuario = tbUsuario.Text;
            g_Senha = tbSenha.Text;

            if ((g_BD == null) || (g_NomeServidor == null) || (g_Usuario == null)) // assim serve ou que que usar variavel.Lenght > 0 ?
            {
                return false;
            }

            // verificar aqui se os campos são válidos, se existe aquele servidor, se 

            return true;
        }

        public void SincronizarBD()
        {
            MessageBox.Show(subKey);

            string dataUltimaAtualizacao = RegRead(CHAVE_DATA_ATUALIZACAO);
            if (dataUltimaAtualizacao == null)
            {
                MessageBox.Show("Teoricamente nunca deveria chegar aqui. Mas, basicamente, deu pau.");
                return;
            }
            else
            {
                MessageBox.Show("data ultima atualizacao: " + dataUltimaAtualizacao);
            }

            if (LerCampos() == false) // carrega o que o usuário digitou nos campos para as variáveis internas do programa
            {
                MessageBox.Show("PARAMETROS INCORRETOS. PREENCHA NOVAMENTE.");
                return;
            }

            PessoaUnis pessoaUnis = new PessoaUnis(g_NomeServidor, g_BD, g_Usuario, g_Senha);
            DataTable pessoaUnisTable = pessoaUnis.SelectDatePessoas(dataUltimaAtualizacao);

            //PessoaEntrapass pessoaEntrapass = new PessoaEntrapass(g_CaminhoEntraPass);

            //pessoaEntrapass.selectPessoas();

            if (pessoaUnisTable != null)
            {
                MessageBox.Show("numero pessoas unis: " + pessoaUnisTable.Rows.Count);

                lbResultados.Items.Clear();

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

                        string startCardFormatted = cardFormatted.Substring(0, 5);
                        string endCardFormatted = cardFormatted.Substring(5, 5);
                        cardFormatted = startCardFormatted + ":" + endCardFormatted;
                    }

                    DateTime dateAndHourCreate = DateTime.Now;
                    string dateCreate = DateTime.Now.ToString("dd/MM/yyyy 00:00:00");

                    //pessoaEntrapass.insertPessoas(id, name, dateAndHourCreate, "00023:43423", "00000000000002997975", dateCreate, dateCreate);
                    lbResultados.Items.Add("id: " + id + " nome: " + name + " card: " + cardFormatted);
                }
            }
            else
            {
                MessageBox.Show("pessoasunistable retornou NULL");
            }

            RegWrite("ultimaAtualizacao", DateTime.Now.ToString("yyyyMMddHHmmss"));

            //1990 09 25 14 17 19
        }


        // ######################## FUNCAO PARA LER O REGISTRO DO WINDOWS
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
                catch (Exception e)
                {
                    MessageBox.Show("Erro lendo registro " + e.Message);
                    return null;
                }
            }
        }

        // ######################## FUNCAO PARA ESCREVER NO REGISTRO DO WINDOWS
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
                MessageBox.Show("Erro escrevendo registro " + e.Message);
                return false;
            }
        }
    }
}