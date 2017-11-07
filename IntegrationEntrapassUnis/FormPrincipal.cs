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

namespace IntegrationEntrapassUnis
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void buttonConectar_Click(object sender, EventArgs e)
        {
            PessoaEntrapass pessoasEntrapass = new PessoaEntrapass(@"c:\Program Files (x86)\Kantech\Server_CE_Demo\Data");
             pessoasEntrapass.selectPessoas();
        }
    }
}
