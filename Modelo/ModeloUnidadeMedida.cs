using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class ModeloUnidadeMedida
    {

        //Construtor
        public ModeloUnidadeMedida() 
        {
            this.UmedCod = 0;
            this.UmedNome = "";
        }

        //Construtor que recebera um valor e um texto 
        public ModeloUnidadeMedida(int cod, String nome) 
        {
            this.UmedCod = cod;
            this.umed_nome = nome;
        }

        private int umed_cod;

        public int UmedCod
        {
            get { return this.umed_cod; }
            set { this.umed_cod = value; }
        }
        private String umed_nome;

        public string UmedNome
        {
            get { return this.umed_nome; }
            set { this.umed_nome = value; }
        }
    }
}
