using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Modelo
{
    public class ModeloProduto
    {
        //Construtores padrão
        public ModeloProduto() 
        {
            this.ProCod = 0;
            this.ProNome = "";
            this.ProDescricao = "";
            //this.ProFoto = null;
            this.ProValorPago = 0;
            this.ProValorVenda = 0;
            this.ProQtde = 0;
            this.UmedCod = 0;
            this.CatCod = 0;
            this.ScatCod = 0;
        }
        //Construtor que recebera um valor e um texto 
        public ModeloProduto(int pro_cod, String pro_nome, String pro_descricao, String pro_foto, Double pro_valorpago,
            Double pro_valorvenda, float pro_qtde, int umed_cod, int cat_cod, int scat_cod)
        {
            this.ProCod = pro_cod;
            this.ProNome = pro_nome;
            this.ProDescricao = pro_descricao;
            this.CarregaImagem(pro_foto); //Recebe um texto e indica onde esta a foto.
            this.ProValorPago = pro_valorpago;
            this.ProValorVenda = pro_valorvenda;
            this.ProQtde = pro_qtde;
            this.UmedCod = umed_cod;
            this.CatCod = cat_cod;
            this.ScatCod = scat_cod;
        }

        public ModeloProduto (byte[] pro_foto) 
        {
            this.pro_foto = pro_foto; //Recebe um vetor pronto e amarzena dentro do pro_foto
        }

        //Propriedades 
        private int pro_cod;
        public int ProCod 
        {
            get { return this.pro_cod; }
            set { this.pro_cod = value; }
        }

        private string pro_nome;
        public string ProNome 
        {
            get { return this.pro_nome; }
            set { this.pro_nome = value; }
        }

        private string pro_descricao;
        public string ProDescricao 
        {
            get { return this.pro_descricao; }
            set { this.pro_descricao = value; }
        }

        private byte[] pro_foto;
        public byte[] ProFoto 
        {
            get { return this.pro_foto; }
            set { this.pro_foto = value; }
        }

        //Metodo para carregar a imagem que esta alocada dentro do computador..
        public void CarregaImagem(string imgCaminho) 
        {
            try 
            {
                if (string.IsNullOrEmpty(imgCaminho)) return;
                //Fornece propriedades métodos de instacia para criar, cópiar,
                //excluir, mover, e abrir arquivos, e ajudar na croação de objetos FileStream
                FileInfo arqImagem = new FileInfo(imgCaminho);
                //Expõe um Stream ao redor de um arquivo de suporte
                //síncrono e assíncrono operações de leitura e gravar.
                FileStream fs = new FileStream(imgCaminho, FileMode.Open, FileAccess.Read, FileShare.Read);
                //aloca memória para o vetor
                this.ProFoto = new byte[Convert.ToInt32(arqImagem.Length)];
                //Lê um bloco de bytes do fluxo e grava osdados em um buffer fornecido.
                int iBytesRead = fs.Read(this.ProFoto, 0, Convert.ToInt32(arqImagem.Length));
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private double pro_valorpago;
        public double ProValorPago 
        {
            get { return this.pro_valorpago; }
            set { this.pro_valorpago = value; }
        }

        private double pro_valorvenda;
        public double ProValorVenda 
        {
            get { return this.pro_valorvenda; }
            set { this.pro_valorvenda = value; }
        }

        private float pro_qtde;
        public float ProQtde 
        {
            get { return this.pro_qtde; }
            set { this.pro_qtde = value; }
        }

        private int umed_cod;
        public int UmedCod 
        {
            get { return this.umed_cod; }
            set { this.umed_cod = value; }
        }

        private int cat_cod;
        public int CatCod 
        {
            get { return this.cat_cod; }
            set { this.cat_cod = value; }
        }


        private int scat_cod;
        public int ScatCod 
        {
            get { return this.scat_cod; }
            set { this.scat_cod = value; }
        }

    }
}
