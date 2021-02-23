using BBL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroUnidadeMedida : GUI.FrmModeloDeFormularioDeCadastro
    {
        public frmCadastroUnidadeMedida()
        {
            InitializeComponent();
        }
        //Metodo para Limpar a tela
        public void LimpaTela() 
        {
            txtCod.Clear();
            txtUnidadeMedida.Clear();
        }

        private void btinserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        private void btlocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaUnidadeDeMedida f = new frmConsultaUnidadeDeMedida();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BBLUnidadeMedida bbl = new BBLUnidadeMedida(cx);
                ModeloUnidadeMedida modelo = bbl.CarregarModeloUnidadeMedida(f.codigo);
                txtCod.Text = modelo.UmedCod.ToString();
                txtUnidadeMedida.Text = modelo.UmedNome;
                this.alteraBotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            f.Dispose();
        }

        private void btcancelar_Click(object sender, EventArgs e)
        {
            this.operacao = "cancelar";
            this.alteraBotoes(1);
        }

        private void btsalvar_Click(object sender, EventArgs e)
        {
            try 
            {
                ModeloUnidadeMedida modelo = new ModeloUnidadeMedida();
                modelo.UmedNome = txtUnidadeMedida.Text;
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BBLUnidadeMedida bbl = new BBLUnidadeMedida(cx);

                if (this.operacao == "inserir") 
                {
                    //cadastrando uma unidade de medida
                    bbl.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado com sucesso: Código" + modelo.UmedCod.ToString());
                }
                else 
                {
                    //alterar uma unidade de medida.
                    modelo.UmedCod = Convert.ToInt32(txtCod.Text);
                    bbl.Alterar(modelo);
                    MessageBox.Show("Cadastro Alterado com Sucesso");
                }
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            catch (Exception erro) 
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btalterar_Click(object sender, EventArgs e)
        {
            this.operacao = "Alterar";
            this.alteraBotoes(2);
        }

        private void txtUnidadeMedida_Leave(object sender, EventArgs e)
        {
            if (this.operacao == "inserir") 
            {
                int r = 0;
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BBLUnidadeMedida bbl = new BBLUnidadeMedida(cx);
                r = bbl.VerificaUnidadeDeMedida(txtUnidadeMedida.Text);
                if (r > 0) 
                {
                    DialogResult d = MessageBox.Show("Ja existe um registro com esse valor, Deseja altera-lo ?", "Aviso", MessageBoxButtons.YesNo);
                    if (d.ToString() == "Yes") 
                    {
                        this.operacao = "alterar";
                        ModeloUnidadeMedida modelo = bbl.CarregarModeloUnidadeMedida(r);
                        txtCod.Text = modelo.UmedCod.ToString();
                        txtUnidadeMedida.Text = modelo.UmedNome;    
                        
                    }
                }
            }
        }
    }
}
