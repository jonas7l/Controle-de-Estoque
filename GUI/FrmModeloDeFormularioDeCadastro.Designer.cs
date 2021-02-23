namespace GUI
{
    partial class FrmModeloDeFormularioDeCadastro
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
            this.pnDados = new System.Windows.Forms.Panel();
            this.pnBotoes = new System.Windows.Forms.Panel();
            this.btcancelar = new System.Windows.Forms.Button();
            this.btsalvar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btalterar = new System.Windows.Forms.Button();
            this.btlocalizar = new System.Windows.Forms.Button();
            this.btinserir = new System.Windows.Forms.Button();
            this.pnBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDados
            // 
            this.pnDados.Location = new System.Drawing.Point(12, 12);
            this.pnDados.Name = "pnDados";
            this.pnDados.Size = new System.Drawing.Size(676, 288);
            this.pnDados.TabIndex = 0;
            // 
            // pnBotoes
            // 
            this.pnBotoes.Controls.Add(this.btcancelar);
            this.pnBotoes.Controls.Add(this.btsalvar);
            this.pnBotoes.Controls.Add(this.btExcluir);
            this.pnBotoes.Controls.Add(this.btalterar);
            this.pnBotoes.Controls.Add(this.btlocalizar);
            this.pnBotoes.Controls.Add(this.btinserir);
            this.pnBotoes.Location = new System.Drawing.Point(12, 306);
            this.pnBotoes.Name = "pnBotoes";
            this.pnBotoes.Size = new System.Drawing.Size(676, 160);
            this.pnBotoes.TabIndex = 1;
            // 
            // btcancelar
            // 
            this.btcancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btcancelar.Image = global::GUI.Properties.Resources.icons8_cancelar_2_64;
            this.btcancelar.Location = new System.Drawing.Point(516, 76);
            this.btcancelar.Name = "btcancelar";
            this.btcancelar.Size = new System.Drawing.Size(75, 75);
            this.btcancelar.TabIndex = 5;
            this.btcancelar.Text = "Cancelar";
            this.btcancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btcancelar.UseVisualStyleBackColor = true;
            this.btcancelar.Click += new System.EventHandler(this.button6_Click);
            // 
            // btsalvar
            // 
            this.btsalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsalvar.Image = global::GUI.Properties.Resources.icons8_salvar_como_64;
            this.btsalvar.Location = new System.Drawing.Point(431, 76);
            this.btsalvar.Name = "btsalvar";
            this.btsalvar.Size = new System.Drawing.Size(75, 75);
            this.btsalvar.TabIndex = 4;
            this.btsalvar.Text = "Salvar";
            this.btsalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btsalvar.UseVisualStyleBackColor = true;
            // 
            // btExcluir
            // 
            this.btExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcluir.Image = global::GUI.Properties.Resources.icons8_apagar_para_sempre_64;
            this.btExcluir.Location = new System.Drawing.Point(345, 76);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 75);
            this.btExcluir.TabIndex = 3;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btalterar
            // 
            this.btalterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btalterar.Image = global::GUI.Properties.Resources.icons8_atualizações_disponíveis_30;
            this.btalterar.Location = new System.Drawing.Point(259, 76);
            this.btalterar.Name = "btalterar";
            this.btalterar.Size = new System.Drawing.Size(75, 75);
            this.btalterar.TabIndex = 2;
            this.btalterar.Text = "Alterar";
            this.btalterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btalterar.UseVisualStyleBackColor = true;
            // 
            // btlocalizar
            // 
            this.btlocalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btlocalizar.Image = global::GUI.Properties.Resources.icons8_procurar_usuário_masculino_64;
            this.btlocalizar.Location = new System.Drawing.Point(174, 76);
            this.btlocalizar.Name = "btlocalizar";
            this.btlocalizar.Size = new System.Drawing.Size(75, 75);
            this.btlocalizar.TabIndex = 1;
            this.btlocalizar.Text = "Localizar";
            this.btlocalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btlocalizar.UseVisualStyleBackColor = true;
            // 
            // btinserir
            // 
            this.btinserir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btinserir.Image = global::GUI.Properties.Resources.icons8_mais_50;
            this.btinserir.Location = new System.Drawing.Point(90, 76);
            this.btinserir.Name = "btinserir";
            this.btinserir.Size = new System.Drawing.Size(75, 75);
            this.btinserir.TabIndex = 0;
            this.btinserir.Text = "Inserir";
            this.btinserir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btinserir.UseVisualStyleBackColor = true;
            // 
            // FrmModeloDeFormularioDeCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 471);
            this.Controls.Add(this.pnBotoes);
            this.Controls.Add(this.pnDados);
            this.KeyPreview = true;
            this.Name = "FrmModeloDeFormularioDeCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modelo de Formulario de Cadastro";
            this.Load += new System.EventHandler(this.FrmModeloDeFormularioDeCadastro_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmModeloDeFormularioDeCadastro_KeyDown);
            this.pnBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnDados;
        protected System.Windows.Forms.Panel pnBotoes;
        protected System.Windows.Forms.Button btcancelar;
        protected System.Windows.Forms.Button btsalvar;
        protected System.Windows.Forms.Button btExcluir;
        protected System.Windows.Forms.Button btalterar;
        protected System.Windows.Forms.Button btlocalizar;
        protected System.Windows.Forms.Button btinserir;
    }
}