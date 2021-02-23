using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BBL
{
    public class BBLCategoria
    {
        private DALConexao conexao;

        public BBLCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir (ModeloCategoria modelo)
        {
            if (modelo.CatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatorio");
            }
            //modelo.CatNome = modelo.CatNome.ToUpper();

            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Incluir(modelo);
        }

        public void Alterar (ModeloCategoria modelo)
        {
            if(modelo.CatCod <= 0)
            {
                throw new Exception("O codigo da categoria é obrigatorio");
            }
            if(modelo.CatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatorio");
            }

            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Alterar(modelo);

        }

        public void Excluir (int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Excluir(codigo);

        }

        public DataTable Localizar(String valor)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.Localizar(valor);
        }

        public ModeloCategoria CarregaModeloCategoria(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.CarregaModeloCategoria(codigo);
        }
    }
}
