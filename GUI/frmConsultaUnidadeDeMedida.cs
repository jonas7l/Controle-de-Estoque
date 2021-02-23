﻿using BBL;
using DAL;
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
    public partial class frmConsultaUnidadeDeMedida : Form
    {
        //propriedade responsavel para devolver o codigo da unidade de medida.
        public int codigo = 0;
        public frmConsultaUnidadeDeMedida()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BBLUnidadeMedida bbl = new BBLUnidadeMedida(cx);
            dgvDados.DataSource = bbl.Localizar(txtValor.Text);
        }

        private void frmConsultaUnidadeDeMedida_Load(object sender, EventArgs e)
        {
            btLocalizar_Click(sender, e);
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 50;
            dgvDados.Columns[1].HeaderText = "Unidade de Medida";
            dgvDados.Columns[1].Width = 700;
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0) 
            {
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}
