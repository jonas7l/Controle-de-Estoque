using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BBL
{
    public class BBLUnidadeMedida
    {
        private DALConexao conexao;

        public BBLUnidadeMedida(DALConexao cx) 
        {
            this.conexao = cx;
        }
        //Metodo para fazer uma inclusão de uma unidade de medida.
        public void Incluir (ModeloUnidadeMedida modelo) 
        {
            if(modelo.UmedNome.Trim().Length == 0) 
            {
                throw new Exception("O nome da Uinidade de Medida é Obrigatorio");
            }
            modelo.UmedNome = modelo.UmedNome.ToUpper();

            DALUnidadeMedida DALobj = new DALUnidadeMedida(conexao);
            DALobj.Incluir(modelo);
        }
        //Metodo para fazer uma alteração na unidade de medida.
        public void Alterar (ModeloUnidadeMedida modelo) 
        {
            if (modelo.UmedCod <= 0) 
            {
                throw new Exception("O codigo da Unidade de Medida é Obrigatorio");
            }
            DALUnidadeMedida DALobj = new DALUnidadeMedida(conexao);
            DALobj.Alterar(modelo);
        }
        //Metodo para fazer uma exclusão em uma unidade de medida.
        public void Excluir (int codigo) 
        {
            DALUnidadeMedida DALobj = new DALUnidadeMedida(conexao);
            DALobj.Excluir(codigo);
        }
        // Metodo para localizar uma unidade de medida.
        public DataTable Localizar (String valor) 
        {
            DALUnidadeMedida DALobj = new DALUnidadeMedida(conexao);
            return DALobj.Localizar(valor);
        }

        public int VerificaUnidadeDeMedida(String valor) //0 - não existe || numero > 0 existe 
        {
            DALUnidadeMedida Dalobj = new DALUnidadeMedida(conexao);
            return Dalobj.VerificaUnidadeDeMedida(valor);
        } 

        public ModeloUnidadeMedida CarregarModeloUnidadeMedida (int codigo) 
        {
            DALUnidadeMedida DALobj = new DALUnidadeMedida(conexao);
            return DALobj.CarregaModeloUnidadeMedida(codigo);
        }
    }
}
