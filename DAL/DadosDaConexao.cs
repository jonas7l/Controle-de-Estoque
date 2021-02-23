using System;

namespace DAL
{
    public class DadosDaConexao
    {
        public static String StringDeConexao
        {
            get
            {
                return @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ControleDeEstoque;Data Source=CNXL16\SQLEXPRESS";
            }
        }
    }
}
