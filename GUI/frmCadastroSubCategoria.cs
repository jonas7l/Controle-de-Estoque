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
    public partial class frmCadastroSubCategoria : GUI.FrmModeloDeFormularioDeCadastro
    {
        public frmCadastroSubCategoria()
        {
            InitializeComponent();
        }

        public void LimpaTela()
        {
            txtNome.Clear();
            txtScatCod.Clear();

        }
        private void frmCadastroSubCategoria_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BBLCategoria bll = new BBLCategoria(cx);
            cbCatCod.DataSource = bll.Localizar("");
            cbCatCod.DisplayMember = "cat_nome";
            cbCatCod.ValueMember = "cat_cod";
        }

        private void btinserir_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(2);
            this.operacao = "inserir";
        }

        private void btcancelar_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            this.LimpaTela();
        }

        private void btalterar_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(2);
            this.operacao = "alterar";
        }

        private void btsalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloSubCategoria modelo = new ModeloSubCategoria();
                modelo.ScatNome = txtNome.Text;
                modelo.CatCod = Convert.ToInt32(cbCatCod.SelectedValue);
                //obj para gravar os dados no banco 
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BBLSubCategoria bll = new BBLSubCategoria(cx);
                if(this.operacao == "inserir")
                {
                    //cadastrar uma categoria 
                    bll.incluir(modelo);
                    MessageBox.Show("Nova SubCategoria Cadastrada com sucesso: Código" + modelo.ScatCod.ToString());
                }
                else
                {
                    //alterar uma categoria
                    modelo.ScatCod = Convert.ToInt32(txtScatCod.Text);
                    bll.alterar(modelo);
                    MessageBox.Show("SubCategoria Alterada com Sucesso");
                }
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Realmente Deseja Excluir o Registro?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    BBLSubCategoria bll = new BBLSubCategoria(cx);
                    bll.Excluir(Convert.ToInt32(txtScatCod.Text));
                    this.LimpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossivel excluir o regitro desejado. \n ) registro esta sendo usado em outro local.");
                this.alteraBotoes(3);
            }
        }

        private void btlocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaSubCategoria f = new frmConsultaSubCategoria();
            f.ShowDialog();
            if(f.codigo !=0)
            {

                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BBLSubCategoria bll = new BBLSubCategoria(cx);
                ModeloSubCategoria modelo = bll.CarregaModeloSubCategoria(f.codigo);
                txtScatCod.Text = modelo.ScatCod.ToString();
                txtNome.Text = modelo.ScatNome;
                cbCatCod.SelectedValue = modelo.CatCod;
                alteraBotoes(3);
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
