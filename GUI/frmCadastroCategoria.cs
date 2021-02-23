using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelo;
using DAL;
using BBL;

namespace GUI
{
    public partial class frmCadastroCategoria : GUI.FrmModeloDeFormularioDeCadastro
    {
        public frmCadastroCategoria()
        {
            InitializeComponent();
        }

        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }

        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);

        }

        private void btinserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        private void btcancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela();
            this.alteraBotoes(1);
        }

        private void btsalvar_Click(object sender, EventArgs e)
        {
            try
            { 
            //Leitura dos dados
            ModeloCategoria modelo = new ModeloCategoria();
            modelo.CatNome = txtNome.Text;
            //objeto para gravar os dados no banco
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BBLCategoria bbl = new BBLCategoria(cx);
            if (this.operacao == "inserir")
            {
                //cadastra uma categoria
                bbl.Incluir(modelo);
                MessageBox.Show("Cadastro efetuado: Código " + modelo.CatCod.ToString());

            }
            else
            {
                //alterar uma categoria
                modelo.CatCod = Convert.ToInt32(txtCodigo.Text);
                bbl.Alterar(modelo);
                MessageBox.Show("Cadastro Alterado");
            }
                this.LimpaTela();
                this.alteraBotoes(1);  



            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btalterar_Click(object sender, EventArgs e)
        {
            this.operacao = "Alterar";
            this.alteraBotoes(2);
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja escluir o registro?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    BBLCategoria bbl = new BBLCategoria(cx);
                    bbl.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.LimpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossivel excluir o registro, \n O registro esta sendo ultilizado em outro local.");
                this.alteraBotoes(3);
            }
        }

        private void btlocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaCategoria f = new frmConsultaCategoria();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BBLCategoria bbl = new BBLCategoria(cx);
                ModeloCategoria modelo = bbl.CarregaModeloCategoria(f.codigo);
                txtCodigo.Text = modelo.CatCod.ToString();
                txtNome.Text = modelo.CatNome;
                this.alteraBotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            f.Dispose();
        }
    }
}
