using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmModeloDeFormularioDeCadastro : Form
    {
        public string operacao; 

        public FrmModeloDeFormularioDeCadastro()
        {
            InitializeComponent();
        }

        public void alteraBotoes(int op)
        {
            // op = operações que serão faitas com os botoes 
            // 1 = preparar os botoes para inserir e localizar
            // 2 = preparar os botoes para inserir/alterar um registro
            // 3 = preparar a tela para excluir ou alterar

            pnDados.Enabled = false;
            btinserir.Enabled = false;
            btalterar.Enabled = false;
            btlocalizar.Enabled = false;
            btExcluir.Enabled = false;
            btcancelar.Enabled = false;
            btsalvar.Enabled = false;

            if (op == 1)
            {
                btinserir.Enabled = true;
                btlocalizar.Enabled = true;
            }
            if (op == 2)
            {
                pnDados.Enabled = true;
                btsalvar.Enabled = true;
                btcancelar.Enabled = true;
            }
            if (op == 3)
            {
                btalterar.Enabled = true;
                btExcluir.Enabled = true;
                btcancelar.Enabled = true;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btExcluir_Click(object sender, EventArgs e)
        {

        }

        private void FrmModeloDeFormularioDeCadastro_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }

        private void FrmModeloDeFormularioDeCadastro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            } 
        }
    }
}
