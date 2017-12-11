namespace IntegrationEntrapassUnis
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.btSync = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rbUsuarioSenha = new System.Windows.Forms.RadioButton();
            this.rbWindows = new System.Windows.Forms.RadioButton();
            this.tbServidor = new System.Windows.Forms.TextBox();
            this.tbBD = new System.Windows.Forms.TextBox();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCaminhoEntraPass = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbResultados = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btSync
            // 
            this.btSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSync.Location = new System.Drawing.Point(12, 64);
            this.btSync.Name = "btSync";
            this.btSync.Size = new System.Drawing.Size(462, 80);
            this.btSync.TabIndex = 0;
            this.btSync.Text = "SYNCAO";
            this.btSync.UseVisualStyleBackColor = true;
            this.btSync.Click += new System.EventHandler(this.btSync_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servidor SQL UNIS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BD:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Usuário:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Senha:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Modo de autenticação:";
            // 
            // rbUsuarioSenha
            // 
            this.rbUsuarioSenha.AutoSize = true;
            this.rbUsuarioSenha.Location = new System.Drawing.Point(28, 242);
            this.rbUsuarioSenha.Name = "rbUsuarioSenha";
            this.rbUsuarioSenha.Size = new System.Drawing.Size(127, 17);
            this.rbUsuarioSenha.TabIndex = 6;
            this.rbUsuarioSenha.TabStop = true;
            this.rbUsuarioSenha.Text = "Modo Usuário/Senha";
            this.rbUsuarioSenha.UseVisualStyleBackColor = true;
            // 
            // rbWindows
            // 
            this.rbWindows.AutoSize = true;
            this.rbWindows.Location = new System.Drawing.Point(27, 265);
            this.rbWindows.Name = "rbWindows";
            this.rbWindows.Size = new System.Drawing.Size(99, 17);
            this.rbWindows.TabIndex = 7;
            this.rbWindows.TabStop = true;
            this.rbWindows.Text = "Modo Windows";
            this.rbWindows.UseVisualStyleBackColor = true;
            // 
            // tbServidor
            // 
            this.tbServidor.Location = new System.Drawing.Point(125, 167);
            this.tbServidor.Name = "tbServidor";
            this.tbServidor.Size = new System.Drawing.Size(100, 20);
            this.tbServidor.TabIndex = 8;
            // 
            // tbBD
            // 
            this.tbBD.Location = new System.Drawing.Point(125, 191);
            this.tbBD.Name = "tbBD";
            this.tbBD.Size = new System.Drawing.Size(100, 20);
            this.tbBD.TabIndex = 9;
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(125, 291);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(100, 20);
            this.tbUsuario.TabIndex = 10;
            // 
            // tbSenha
            // 
            this.tbSenha.Location = new System.Drawing.Point(125, 313);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.Size = new System.Drawing.Size(100, 20);
            this.tbSenha.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Caminho do EntraPass:";
            // 
            // tbCaminhoEntraPass
            // 
            this.tbCaminhoEntraPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCaminhoEntraPass.Location = new System.Drawing.Point(378, 167);
            this.tbCaminhoEntraPass.Name = "tbCaminhoEntraPass";
            this.tbCaminhoEntraPass.Size = new System.Drawing.Size(100, 20);
            this.tbCaminhoEntraPass.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(505, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 280);
            this.panel1.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(178, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "CONFIGURACOES";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(691, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "RESULTADOS";
            // 
            // lbResultados
            // 
            this.lbResultados.FormattingEnabled = true;
            this.lbResultados.Location = new System.Drawing.Point(526, 63);
            this.lbResultados.Name = "lbResultados";
            this.lbResultados.Size = new System.Drawing.Size(448, 277);
            this.lbResultados.TabIndex = 18;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 367);
            this.Controls.Add(this.lbResultados);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbCaminhoEntraPass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSenha);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.tbBD);
            this.Controls.Add(this.tbServidor);
            this.Controls.Add(this.rbWindows);
            this.Controls.Add(this.rbUsuarioSenha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.Text = "EntraPass Unity";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbUsuarioSenha;
        private System.Windows.Forms.RadioButton rbWindows;
        private System.Windows.Forms.TextBox tbServidor;
        private System.Windows.Forms.TextBox tbBD;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.TextBox tbSenha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCaminhoEntraPass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lbResultados;
    }
}

