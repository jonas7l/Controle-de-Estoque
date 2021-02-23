using System;

namespace Modelo
{
    public class ModeloCategoria
    {

        public ModeloCategoria()
        {
            this.CatCod = 0;
            this.CatNome = "";
        }

        public ModeloCategoria (int catcod, String catnome)
        {
            this.CatCod = catcod;
            this.CatNome = catnome;
        }

        private int cat_cod;

        public int CatCod
        {
            get { return this.cat_cod; }
            set { this.cat_cod = value; }
        }
        private String cat_nome;

        public string CatNome
        {
            get { return this.cat_nome; }
            set { this.cat_nome = value; }
        }

    }
}
