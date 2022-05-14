namespace eAgenda.WinApp.ModuloTeste
{
    partial class TelaCadastroTesteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboDisciplina = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboMateria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtNrQuestoes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateData = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGerarQuestoes = new System.Windows.Forms.Button();
            this.listQuestoes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // comboDisciplina
            // 
            this.comboDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDisciplina.FormattingEnabled = true;
            this.comboDisciplina.Location = new System.Drawing.Point(74, 43);
            this.comboDisciplina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboDisciplina.Name = "comboDisciplina";
            this.comboDisciplina.Size = new System.Drawing.Size(133, 23);
            this.comboDisciplina.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 37;
            this.label5.Text = "Disciplina:";
            // 
            // comboMateria
            // 
            this.comboMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMateria.FormattingEnabled = true;
            this.comboMateria.Location = new System.Drawing.Point(279, 43);
            this.comboMateria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboMateria.Name = "comboMateria";
            this.comboMateria.Size = new System.Drawing.Size(133, 23);
            this.comboMateria.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 35;
            this.label2.Text = "Matéria:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(59, 75);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(209, 23);
            this.txtTitulo.TabIndex = 34;
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(74, 11);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(64, 23);
            this.txtNumero.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Título:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "Número:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(340, 345);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 39);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(259, 345);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(72, 39);
            this.btnGravar.TabIndex = 39;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtNrQuestoes
            // 
            this.txtNrQuestoes.Location = new System.Drawing.Point(138, 107);
            this.txtNrQuestoes.Name = "txtNrQuestoes";
            this.txtNrQuestoes.Size = new System.Drawing.Size(130, 23);
            this.txtNrQuestoes.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 41;
            this.label1.Text = "Número de Questões:";
            // 
            // dateData
            // 
            this.dateData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateData.Location = new System.Drawing.Point(314, 75);
            this.dateData.Name = "dateData";
            this.dateData.Size = new System.Drawing.Size(96, 23);
            this.dateData.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 44;
            this.label6.Text = "Data:";
            // 
            // btnGerarQuestoes
            // 
            this.btnGerarQuestoes.Location = new System.Drawing.Point(279, 107);
            this.btnGerarQuestoes.Name = "btnGerarQuestoes";
            this.btnGerarQuestoes.Size = new System.Drawing.Size(133, 23);
            this.btnGerarQuestoes.TabIndex = 45;
            this.btnGerarQuestoes.Text = "Gerar questões";
            this.btnGerarQuestoes.UseVisualStyleBackColor = true;
            this.btnGerarQuestoes.Click += new System.EventHandler(this.btnGerarQuestoes_Click);
            // 
            // listQuestoes
            // 
            this.listQuestoes.FormattingEnabled = true;
            this.listQuestoes.ItemHeight = 15;
            this.listQuestoes.Location = new System.Drawing.Point(11, 146);
            this.listQuestoes.Name = "listQuestoes";
            this.listQuestoes.Size = new System.Drawing.Size(399, 184);
            this.listQuestoes.TabIndex = 46;
            // 
            // TelaCadastroTesteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 397);
            this.Controls.Add(this.listQuestoes);
            this.Controls.Add(this.btnGerarQuestoes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateData);
            this.Controls.Add(this.txtNrQuestoes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.comboDisciplina);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboMateria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroTesteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCadastroTesteForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroTesteForm_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroTesteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboDisciplina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboMateria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TextBox txtNrQuestoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGerarQuestoes;
        private System.Windows.Forms.ListBox listQuestoes;
    }
}