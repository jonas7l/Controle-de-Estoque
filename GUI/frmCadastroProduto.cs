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
    public partial class frmCadastroProduto : GUI.FrmModeloDeFormularioDeCadastro
    {
        //Propriedade foto 
        public string foto = "";

        public frmCadastroProduto()
        {
            
            InitializeComponent();
        }

        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtQuantidade.Clear();
            txtValorPago.Clear();
            txtValorVenda.Clear();
            
        }

        private void pnDados_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btinserir_Click(object sender, EventArgs e)
        {

            this.operacao = "inserir";
            this.alteraBotoes(2);
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
                    BBLProduto bbl = new BBLProduto(cx);
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

        private void btcancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela();
            this.alteraBotoes(1);
        }

        private void btlocalizar_Click(object sender, EventArgs e)
        {
            /*
            frmConsultaProduto f = new frmConsultaCategoria();
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
            */
        }

        private void btsalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //Leitura dos dados
                ModeloProduto modelo = new ModeloProduto();
                modelo.ProNome = txtNome.Text;
                //objeto para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BBLProduto bbl = new BBLProduto(cx);
                if (this.operacao == "inserir")
                {
                    //cadastra uma categoria
                    bbl.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado: Código " + modelo.ProCod.ToString());

                }
                else
                {
                    //alterar uma categoria
                    modelo.ProCod = Convert.ToInt32(txtCodigo.Text);
                    bbl.Alteraer(modelo);
                    MessageBox.Show("Cadastro Alterado");
                }
                this.LimpaTela();
                this.alteraBotoes(1);



            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btinserir_Click_1(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        private void frmCadastroProduto_Load(object sender, EventArgs e)
        {
            //Combo da Categoria
            this.alteraBotoes(1);
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BBLCategoria bll = new BBLCategoria(cx);
            cboCategoria.DataSource = bll.Localizar("");
            cboCategoria.DisplayMember = "cat_nome";
            cboCategoria.ValueMember = "cat_cod";
            try
            {
                //Combo da SubCategoria            
                BBLSubCategoria sbll = new BBLSubCategoria(cx);
                cboSubCategoria.DataSource = sbll.LocalizaPorCategoria((int)cboCategoria.SelectedValue);
                cboSubCategoria.DisplayMember = "scat_nome";
                cboSubCategoria.ValueMember = "scat_cod";
            }
            catch 
            {
                MessageBox.Show("Ops! Não Existe Nenhuma Categoria Cadastrada!");
            }            
            //Combo Unidade Medida
            BBLUnidadeMedida mbll = new BBLUnidadeMedida(cx);
            cboUnidadeMedida.DataSource = mbll.Localizar("");
            cboUnidadeMedida.DisplayMember = "umed_nome";
            cboUnidadeMedida.ValueMember = "umed_cod";


        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorVenda.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.') 
            {
                e.Handled = true;
            }
            if(e.KeyChar == ',' || e.KeyChar == '.') 
            {
                if (!txtValorPago.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            if(txtValorVenda.Text.Contains(".") == false) 
            {
                txtValorVenda.Text += ".00";
            }
            else 
            {
                if(txtValorVenda.Text.IndexOf(".") == txtValorVenda.Text.Length - 1) 
                {
                    txtValorVenda.Text = "00";
                }
            }
            try 
            {
                Double d = Convert.ToDouble(txtValorVenda.Text);
            }
            catch 
            {
                txtValorVenda.Text = "0.00";
            }
        }

        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            if (txtValorPago.Text.Contains(".") == false)
            {
                txtValorPago.Text += ".00";
            }
            else
            {
                if (txtValorPago.Text.IndexOf(".") == txtValorPago.Text.Length - 1)
                {
                    txtValorPago.Text += "00";
                }
            }
            try 
            {
                Double d = Convert.ToDouble(txtValorPago.Text);
            }
            catch 
            {
                txtValorPago.Text = "0.00";
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtQuantidade.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            if (txtQuantidade.Text.Contains(".") == false)
            {
                txtQuantidade.Text += ".00";
            }
            else
            {
                if (txtQuantidade.Text.IndexOf(".") == txtQuantidade.Text.Length - 1)
                {
                    txtQuantidade.Text += "00";
                }
            }
            try
            {
                Double d = Convert.ToDouble(txtQuantidade.Text);
            }
            catch
            {
                txtQuantidade.Text = "0.00";
            }
        }

        private void cboCategoria_SelectedValueChanged(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);      
            try
            {
                //Combo da SubCategoria 
                
                cboSubCategoria.Text = "";
                BBLSubCategoria sbll = new BBLSubCategoria(cx);
                cboSubCategoria.DataSource = sbll.LocalizaPorCategoria((int)cboCategoria.SelectedValue);
                cboSubCategoria.DisplayMember = "scat_nome";
                cboSubCategoria.ValueMember = "scat_cod";
            }
            catch
            {
                //MessageBox.Show("Ops! Não Existe Nenhuma Categoria Cadastrada!");
            }
        }
    }
}
