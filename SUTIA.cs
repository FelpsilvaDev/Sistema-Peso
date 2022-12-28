using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;


namespace Sistema_de_medidas
{
    public partial class SUTIA : Form
    {
        public SUTIA()
        {
            InitializeComponent();
        }

        string linhaMedidas;
        const double lista38 = 38;
        const double lista40 = 40;
        const double lista42 = 42;
        const double lista44 = 44;
        const double lista46 = 46;
        const double lista48 = 48;
        const double lista50 = 50;
        const double lista52 = 52;
        const double lista54 = 54;
        const double lista56 = 56;
        const double lista58 = 58;
        double valorreferencia = 0;
        double resultadobruto = 0;
        double resultadoliquido = 0;


        ///Declarações de Lista\\\

        List<string> ListaCopas38 = new List<string>();
        List<string> ListaCopas40 = new List<string>();
        List<string> ListaCopas042 = new List<string>();
        List<string> ListaCopas44 = new List<string>();
        List<string> ListaCopas46 = new List<string>();
        List<string> ListaCopas48 = new List<string>();
        List<string> ListaCopas50 = new List<string>();
        List<string> ListaCopas52 = new List<string>();
        List<string> ListaCopas54 = new List<string>();
        List<double> tblbruto = new List<double>();
        List<string> tblbojo = new List<string>();
        List<string> tblsku = new List<string>();
        List<double> tblliquido = new List<double>();


        private void Copas()
        {
            ListaCopas38.Add("40A");
            ListaCopas38.Add("38B");
            ListaCopas38.Add("36C");
            ListaCopas38.Add("34D");

            ListaCopas40.Add("42A");
            ListaCopas40.Add("40B");
            ListaCopas40.Add("38C");
            ListaCopas40.Add("36D");
            ListaCopas40.Add("34DD");

            ListaCopas042.Add("44A");
            ListaCopas042.Add("42B");
            ListaCopas042.Add("40C");
            ListaCopas042.Add("38D");
            ListaCopas042.Add("36DD");
            ListaCopas042.Add("34F");

            ListaCopas44.Add("46A");
            ListaCopas44.Add("44B");
            ListaCopas44.Add("42C");
            ListaCopas44.Add("40D");
            ListaCopas44.Add("38DD");
            ListaCopas44.Add("36F");

            ListaCopas46.Add("48A");
            ListaCopas46.Add("46B");
            ListaCopas46.Add("44C");
            ListaCopas46.Add("42D");
            ListaCopas46.Add("40DD");
            ListaCopas46.Add("38F");
            ListaCopas46.Add("36G");

            ListaCopas48.Add("48B");
            ListaCopas48.Add("46C");
            ListaCopas48.Add("44D");
            ListaCopas48.Add("42DD");
            ListaCopas48.Add("40F");
            ListaCopas48.Add("38G");
            ListaCopas48.Add("36h");

            ListaCopas50.Add("50B");
            ListaCopas50.Add("48C");
            ListaCopas50.Add("46D");
            ListaCopas50.Add("44DD");
            ListaCopas50.Add("42F");
            ListaCopas50.Add("40G");
            ListaCopas50.Add("38H");

            ListaCopas52.Add("52B");
            ListaCopas52.Add("50C");
            ListaCopas52.Add("48D");
            ListaCopas52.Add("46DD");
            ListaCopas52.Add("44F");
            ListaCopas52.Add("42G");
            ListaCopas52.Add("40H");

            ListaCopas54.Add("54B");
            ListaCopas54.Add("52C");
            ListaCopas54.Add("50D");
            ListaCopas54.Add("48DD");
            ListaCopas54.Add("46F");
            ListaCopas54.Add("44G");
            ListaCopas54.Add("42H");
        }

        public class Listasku
        {
            public string colunaskus { get; set; }
            public string colunaliquido { get; set; }
            public string colunaembalagem { get; set; }
            public string colunabojo { get; set; }
            public string colunabruto { get; set; }        
          
        }
        List<Listasku> lstskus = new List<Listasku>();
        List<Listasku> alimentarlista = new List<Listasku>();
        //Listasku skuss = new Listasku();
        private void Arquivo()
        {
            //Buscar arquivo csv
            OpenFileDialog paste = new OpenFileDialog();

            paste.Filter = "All files (*.csv)|*.csv";
            paste.Title = "Selecione o arquivo";
            paste.ShowDialog();

            string csv = paste.FileName;

            StreamReader lerArquivo = new StreamReader(File.OpenRead(csv));


            while ((linhaMedidas = lerArquivo.ReadLine()) != null)
            {
                Listasku skuss = new Listasku();

                skuss.colunaskus = linhaMedidas;
                alimentarlista.Add(skuss);
            }            
        }

        private void btnAnexar_Click(object sender, EventArgs e)
        {
            Arquivo();

        }


        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Copas();

            //variaveis para calculo
            double tmreferencia = Convert.ToDouble(txtBojo.Text);
            var vlreferencia = Convert.ToDouble(txtEmbalagem.Text);
            var vlrliquido = Convert.ToDouble(txtLiquido.Text);

            //Armazenar labelBox em variavel 
            string textoSku = Convert.ToString(txtSku.Text);
            double textoLiquido = Convert.ToDouble(txtLiquido.Text);
            double textoBojo = Convert.ToDouble(tmreferencia);
            double textoEmbalagem = Convert.ToDouble(txtEmbalagem.Text);
            double resultado = Convert.ToDouble(textoLiquido + textoEmbalagem);
            lblBruto.Text = Convert.ToString(resultado);

            //alimentar lista     

            //Concatenar quantidade de "0"
            string QntZero = textoSku.Substring(13, 2);

            //Exemplos de Skus
            //Numero SKu com 1 letra  035101851104000A    11 ate a referencia da copa
            //Numero Sku com 2 letras 03510185110400DD    11 ate a referencia da copa 

            string numerocopas = textoSku.Substring(11, 2);
            string letracopas = textoSku.Substring(15);
            string copas = Convert.ToString(numerocopas + letracopas);

            switch (tmreferencia)
            {
                case lista38:
                    valorreferencia = tmreferencia;
                    break;

                case lista40:
                    valorreferencia = tmreferencia;
                    break;

                case lista42:
                    valorreferencia = tmreferencia;
                    break;

                case lista44:
                    valorreferencia = tmreferencia;
                    break;

                case lista46:
                    valorreferencia = tmreferencia;
                    break;

                case lista48:
                    valorreferencia = tmreferencia;
                    break;

                case lista50:
                    valorreferencia = tmreferencia;
                    break;

                case lista52:
                    valorreferencia = tmreferencia;
                    break;

                case lista54:
                    valorreferencia = tmreferencia;
                    break;

                case lista56:
                    valorreferencia = tmreferencia;
                    break;

                case lista58:
                    valorreferencia = tmreferencia;
                    break;

            }

            if (valorreferencia < 40 && valorreferencia >= lista38)
            {
                if (valorreferencia == lista38)
                {
                    if (QntZero == "00")
                    {
                        foreach (string lc38 in ListaCopas38)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc38)
                                {
                                    resultadoliquido = vlrliquido;
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblbojo.Add("38");
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;


                        foreach (string lc40 in ListaCopas40)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc40)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("40");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc42 in ListaCopas042)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc42)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("42");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc44 in ListaCopas44)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc44)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("44");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc46 in ListaCopas46)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc46)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("46");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc48 in ListaCopas48)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc48)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("48");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc50 in ListaCopas50)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc50)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("50");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc52 in ListaCopas52)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc52)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("52");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc54 in ListaCopas54)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc54)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("54");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }
                    }



                    else
                    {
                        if (QntZero == "0")
                        {
                            foreach (string lc38 in ListaCopas38)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc38)
                                    {
                                        resultadoliquido = vlrliquido;
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblbojo.Add("38");
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;


                            foreach (string lc40 in ListaCopas40)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc40)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("40");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc42 in ListaCopas042)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc42)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("42");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc44 in ListaCopas44)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc44)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("44");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc46 in ListaCopas46)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc46)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("46");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc48 in ListaCopas48)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc48)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("48");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc50 in ListaCopas50)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc50)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("50");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc52 in ListaCopas52)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc52)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("52");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc54 in ListaCopas54)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc54)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("54");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (valorreferencia < 42 && valorreferencia >= lista40)
            {
                if (valorreferencia == lista40)
                {
                    if (QntZero == "00")
                    {
                        foreach (string lc38 in ListaCopas38)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc38)
                                {
                                    resultadoliquido = vlrliquido * (1 - 0.05);
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("38");
                                }
                            }
                        }


                        resultadoliquido = vlrliquido;

                        foreach (string lc40 in ListaCopas40)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc40)
                                {
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("40");
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc42 in ListaCopas042)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc42)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("42");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc44 in ListaCopas44)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc44)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("44");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc46 in ListaCopas46)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc46)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("46");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc48 in ListaCopas48)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc48)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("48");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc50 in ListaCopas50)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc50)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("50");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc52 in ListaCopas52)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc52)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("52");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * 1.05;
                        resultadobruto = resultadoliquido + textoEmbalagem;

                        foreach (string lc54 in ListaCopas54)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc54)
                                {
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("54");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }
                    }

                    else
                    {
                        if (QntZero == "0")
                        {
                            foreach (string lc38 in ListaCopas38)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc38)
                                    {
                                        resultadoliquido = vlrliquido * (1 - 0.05);
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("38");
                                    }
                                }
                            }


                            resultadoliquido = vlrliquido;

                            foreach (string lc40 in ListaCopas40)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc40)
                                    {
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("40");
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc42 in ListaCopas042)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc42)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("42");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc44 in ListaCopas44)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc44)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("44");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc46 in ListaCopas46)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc46)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("46");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc48 in ListaCopas48)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc48)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("48");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc50 in ListaCopas50)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc50)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("50");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc52 in ListaCopas52)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc52)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("52");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * 1.05;
                            resultadobruto = resultadoliquido + textoEmbalagem;

                            foreach (string lc54 in ListaCopas54)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc54)
                                    {
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("54");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (valorreferencia < 44 && valorreferencia >= lista42)
            {
                if (valorreferencia == lista42)
                {
                    if (QntZero == "00")
                    {
                        foreach (string lc38 in ListaCopas38)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc38)
                                {
                                    double Porcentagem = vlrliquido * (1 - 0.05);
                                    resultadoliquido = Porcentagem * (1 - 0.05);
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("38");
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc40 in ListaCopas40)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc40)
                                {
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("40");
                                }
                            }
                        }

                        resultadoliquido = vlrliquido;

                        foreach (string lc42 in ListaCopas042)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc42)
                                {
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("42");
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc44 in ListaCopas44)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc44)
                                {
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("44");
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc46 in ListaCopas46)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc46)
                                {
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("46");
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc48 in ListaCopas48)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc48)
                                {
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("48");
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc50 in ListaCopas50)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc50)
                                {
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("50");
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc52 in ListaCopas52)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc52)
                                {
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("52");
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc54 in ListaCopas54)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc54)
                                {
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("54");
                                }
                            }
                        }
                    }



                    else
                    {
                        if (QntZero == "0")
                        {
                            foreach (string lc38 in ListaCopas38)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc38)
                                    {
                                        double Porcentagem = vlrliquido * (1 - 0.05);
                                        resultadoliquido = Porcentagem * (1 - 0.05);
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("38");
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc40 in ListaCopas40)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc40)
                                    {
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("40");
                                    }
                                }
                            }

                            resultadoliquido = vlrliquido;

                            foreach (string lc42 in ListaCopas042)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc42)
                                    {
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("42");
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc44 in ListaCopas44)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc44)
                                    {
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("44");
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc46 in ListaCopas46)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc46)
                                    {
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("46");
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc48 in ListaCopas48)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc48)
                                    {
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("48");
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc50 in ListaCopas50)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc50)
                                    {
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("50");
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc52 in ListaCopas52)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc52)
                                    {
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("52");
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc54 in ListaCopas54)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc54)
                                    {
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("54");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (valorreferencia < 46 && valorreferencia >= lista44)
            {
                if (valorreferencia == lista44)
                {
                    if (QntZero == "00")
                    {
                        foreach (string lc38 in ListaCopas38)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc38)
                                {
                                    double Porcentagem = vlrliquido * (1 - 0.05);
                                    double porcentagem2 = Porcentagem * (1 - 0.05);
                                    resultadoliquido = porcentagem2 * (1 - 0.05);
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("38");
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc40 in ListaCopas40)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc40)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("40");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc42 in ListaCopas042)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc42)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("42");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadobruto = vlrliquido;


                        foreach (string lc44 in ListaCopas44)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc44)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("44");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc46 in ListaCopas46)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc46)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("46");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc48 in ListaCopas48)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc48)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("48");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc50 in ListaCopas50)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc50)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("50");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc52 in ListaCopas52)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc52)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("52");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc54 in ListaCopas54)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc54)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("54");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }
                    }



                    else
                    {
                        if (QntZero == "0")
                        {
                            foreach (string lc38 in ListaCopas38)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc38)
                                    {
                                        resultadobruto = (((vlrliquido * -1.05) * -1.05) * -1.05);
                                        tblbojo.Add("38");
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc40 in ListaCopas40)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc40)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("40");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc42 in ListaCopas042)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc42)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("42");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadobruto = vlrliquido;


                            foreach (string lc44 in ListaCopas44)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc44)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("44");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc46 in ListaCopas46)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc46)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("46");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc48 in ListaCopas48)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc48)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("48");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc50 in ListaCopas50)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc50)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("50");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc52 in ListaCopas52)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc52)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("52");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc54 in ListaCopas54)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc54)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("54");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (valorreferencia < 48 && valorreferencia >= lista46)
            {
                if (valorreferencia == lista46)
                {
                    if (QntZero == "00")
                    {
                        foreach (string lc38 in ListaCopas38)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc38)
                                {
                                    double Porcentagem = vlrliquido * (1 - 0.05);
                                    double porcentagem2 = Porcentagem * (1 - 0.05);
                                    double porcentagem3 = porcentagem2 * (1 - 0.05);
                                    resultadoliquido = porcentagem3 * (1 - 0.05);
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("38");
                                }
                            }
                        }
                    }


                    resultadoliquido = resultadoliquido * (1 + 0.05);

                    foreach (string lc40 in ListaCopas40)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);

                            if (sku == lc40)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("40");
                            }
                        }
                    }


                    resultadoliquido = resultadoliquido * (1 + 0.05);


                    foreach (string lc42 in ListaCopas042)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);

                            if (sku == lc42)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("42");
                            }
                        }
                    }


                    resultadoliquido = resultadoliquido * (1 + 0.05);


                    foreach (string lc44 in ListaCopas44)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);

                            if (sku == lc44)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("44");
                            }
                        }
                    }


                    resultadoliquido = vlrliquido;


                    foreach (string lc46 in ListaCopas46)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);

                            if (sku == lc46)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("46");
                            }
                        }
                    }


                    resultadoliquido = resultadoliquido * (1 + 0.05);


                    foreach (string lc48 in ListaCopas48)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);

                            if (sku == lc48)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("48");
                            }
                        }
                    }

                    resultadoliquido = resultadoliquido * (1 + 0.05);


                    foreach (string lc50 in ListaCopas50)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);

                            if (sku == lc50)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("50");
                            }
                        }
                    }


                    resultadoliquido = resultadoliquido * (1 + 0.05);

                    foreach (string lc52 in ListaCopas52)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);
                            if (sku == lc52)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("52");
                            }
                        }
                    }

                    resultadoliquido = resultadoliquido * (1 + 0.05);

                    foreach (string lc54 in ListaCopas54)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);
                            if (sku == lc54)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("54");
                            }
                        }
                    }
                }



                else
                {
                    if (QntZero == "0")
                    {
                        foreach (string lc38 in ListaCopas38)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc38)
                                {
                                    double Porcentagem = vlrliquido * (1 - 0.05);
                                    double porcentagem2 = Porcentagem * (1 - 0.05);
                                    double porcentagem3 = porcentagem2 * (1 - 0.05);
                                    resultadoliquido = porcentagem3 * (1 - 0.05);
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("38");
                                }
                            }
                        }
                    }


                    resultadoliquido = resultadoliquido * (1 + 0.05);

                    foreach (string lc40 in ListaCopas40)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);

                            if (sku == lc40)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("40");
                            }
                        }
                    }


                    resultadoliquido = resultadoliquido * (1 + 0.05);


                    foreach (string lc42 in ListaCopas042)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);

                            if (sku == lc42)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("42");
                            }
                        }
                    }


                    resultadoliquido = resultadoliquido * (1 + 0.05);


                    foreach (string lc44 in ListaCopas44)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);

                            if (sku == lc44)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("44");
                            }
                        }
                    }


                    resultadoliquido = vlrliquido;


                    foreach (string lc46 in ListaCopas46)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);

                            if (sku == lc46)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("46");
                            }
                        }
                    }


                    resultadoliquido = resultadoliquido * (1 + 0.05);


                    foreach (string lc48 in ListaCopas48)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);

                            if (sku == lc48)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("48");
                            }
                        }
                    }

                    resultadoliquido = resultadoliquido * (1 + 0.05);


                    foreach (string lc50 in ListaCopas50)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);

                            if (sku == lc50)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("50");
                            }
                        }
                    }


                    resultadoliquido = resultadoliquido * (1 + 0.05);

                    foreach (string lc52 in ListaCopas52)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);
                            if (sku == lc52)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("52");
                            }
                        }
                    }

                    resultadoliquido = resultadoliquido * (1 + 0.05);

                    foreach (string lc54 in ListaCopas54)
                    {
                        foreach (var item in alimentarlista)
                        {
                            string skunumero = item.colunaskus.Substring(11, 2);
                            string skuletra = item.colunaskus.Substring(15);
                            string sku = Convert.ToString(skunumero + skuletra);
                            if (sku == lc54)
                            {
                                resultadobruto = resultadoliquido + textoEmbalagem;
                                tblliquido.Add(resultadoliquido);
                                tblsku.Add(item.colunaskus);
                                tblbruto.Add(resultadobruto);
                                tblbojo.Add("54");
                            }
                        }
                    }
                }
            }

            if (valorreferencia < 50 && valorreferencia >= lista48)
            {
                if (valorreferencia == lista48)
                {
                    if (QntZero == "00")
                    {
                        foreach (string lc38 in ListaCopas38)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc38)
                                {
                                    double Porcentagem = vlrliquido * (1 - 0.05);
                                    double porcentagem2 = Porcentagem * (1 - 0.05);
                                    double porcentagem3 = porcentagem2 * (1 - 0.05);
                                    double porcentagem4 = porcentagem3 * (1 - 0.05);
                                    resultadoliquido = porcentagem4 * (1 - 0.05);
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("38");
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc40 in ListaCopas40)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc40)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("40");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc42 in ListaCopas042)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc42)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("42");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc44 in ListaCopas44)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc44)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("44");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc46 in ListaCopas46)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc46)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("46");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = vlrliquido;

                        foreach (string lc48 in ListaCopas48)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc48)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("48");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc50 in ListaCopas50)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc50)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("50");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc52 in ListaCopas52)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc52)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("52");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc54 in ListaCopas54)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc54)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("54");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }
                    }



                    else
                    {
                        if (QntZero == "0")
                        {
                            foreach (string lc38 in ListaCopas38)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc38)
                                    {
                                        double Porcentagem = vlrliquido * (1 - 0.05);
                                        double porcentagem2 = Porcentagem * (1 - 0.05);
                                        double porcentagem3 = porcentagem2 * (1 - 0.05);
                                        double porcentagem4 = porcentagem3 * (1 - 0.05);
                                        resultadoliquido = porcentagem4 * (1 - 0.05);
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("38");
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc40 in ListaCopas40)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc40)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("40");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc42 in ListaCopas042)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc42)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("42");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc44 in ListaCopas44)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc44)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("44");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc46 in ListaCopas46)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc46)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("46");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = vlrliquido;

                            foreach (string lc48 in ListaCopas48)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc48)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("48");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc50 in ListaCopas50)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc50)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("50");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc52 in ListaCopas52)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc52)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("52");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc54 in ListaCopas54)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc54)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("54");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (valorreferencia < 52 && valorreferencia >= lista50)
            {
                if (valorreferencia == lista50)
                {
                    if (QntZero == "00")
                    {
                        foreach (string lc38 in ListaCopas38)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc38)
                                {
                                    double Porcentagem = vlrliquido * (1 - 0.05);
                                    double porcentagem2 = Porcentagem * (1 - 0.05);
                                    double porcentagem3 = porcentagem2 * (1 - 0.05);
                                    double porcentagem4 = porcentagem3 * (1 - 0.05);
                                    double porcentagem5 = porcentagem4 * (1 - 0.05);
                                    resultadoliquido = porcentagem5 * (1 - 0.05);
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("38");
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc40 in ListaCopas40)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc40)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("40");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc42 in ListaCopas042)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc42)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("42");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc44 in ListaCopas44)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc44)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("44");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc46 in ListaCopas46)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc46)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("46");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc48 in ListaCopas48)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc48)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("48");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = vlrliquido;


                        foreach (string lc50 in ListaCopas50)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc50)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("50");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc52 in ListaCopas52)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc52)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("52");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc54 in ListaCopas54)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc54)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("54");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }
                    }



                    else
                    {
                        if (QntZero == "0")
                        {
                            foreach (string lc38 in ListaCopas38)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc38)
                                    {
                                        double Porcentagem = vlrliquido * (1 - 0.05);
                                        double porcentagem2 = Porcentagem * (1 - 0.05);
                                        double porcentagem3 = porcentagem2 * (1 - 0.05);
                                        double porcentagem4 = porcentagem3 * (1 - 0.05);
                                        double porcentagem5 = porcentagem4 * (1 - 0.05);
                                        resultadoliquido = porcentagem5 * (1 - 0.05);
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("38");
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc40 in ListaCopas40)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc40)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("40");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc42 in ListaCopas042)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc42)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("42");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc44 in ListaCopas44)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc44)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("44");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc46 in ListaCopas46)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc46)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("46");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc48 in ListaCopas48)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc48)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("48");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = vlrliquido;


                            foreach (string lc50 in ListaCopas50)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc50)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("50");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc52 in ListaCopas52)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc52)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("52");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc54 in ListaCopas54)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc54)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("54");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (valorreferencia < 54 && valorreferencia >= lista52)
            {
                if (valorreferencia == lista52)
                {
                    if (QntZero == "00")
                    {
                        foreach (string lc38 in ListaCopas38)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc38)
                                {
                                    double Porcentagem = vlrliquido * (1 - 0.05);
                                    double porcentagem2 = Porcentagem * (1 - 0.05);
                                    double porcentagem3 = porcentagem2 * (1 - 0.05);
                                    double porcentagem4 = porcentagem3 * (1 - 0.05);
                                    double porcentagem5 = porcentagem4 * (1 - 0.05);
                                    double porcentagem6 = porcentagem5 * (1 - 0.05);
                                    resultadoliquido = porcentagem6 * (1 - 0.05);
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("38");
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc40 in ListaCopas40)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc40)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("40");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc42 in ListaCopas042)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc42)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("42");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc44 in ListaCopas44)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc44)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("44");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc46 in ListaCopas46)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc46)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("46");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc48 in ListaCopas48)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc48)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("48");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc50 in ListaCopas50)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc50)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("50");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = vlrliquido;

                        foreach (string lc52 in ListaCopas52)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc52)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("52");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc54 in ListaCopas54)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc54)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("54");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }
                    }

                    else
                    {
                        if (QntZero == "0")
                        {
                            foreach (string lc38 in ListaCopas38)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc38)
                                    {
                                        double Porcentagem = vlrliquido * (1 - 0.05);
                                        double porcentagem2 = Porcentagem * (1 - 0.05);
                                        double porcentagem3 = porcentagem2 * (1 - 0.05);
                                        double porcentagem4 = porcentagem3 * (1 - 0.05);
                                        double porcentagem5 = porcentagem4 * (1 - 0.05);
                                        double porcentagem6 = porcentagem5 * (1 - 0.05);
                                        resultadoliquido = porcentagem6 * (1 - 0.05);
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("38");
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc40 in ListaCopas40)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc40)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("40");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc42 in ListaCopas042)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc42)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("42");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc44 in ListaCopas44)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc44)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("44");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc46 in ListaCopas46)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc46)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("46");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc48 in ListaCopas48)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc48)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("48");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc50 in ListaCopas50)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc50)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("50");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = vlrliquido;

                            foreach (string lc52 in ListaCopas52)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc52)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("52");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc54 in ListaCopas54)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc54)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("54");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (valorreferencia < 56 && valorreferencia == lista54)
            {
                if (valorreferencia == lista54)
                {
                    if (QntZero == "00")
                    {
                        foreach (string lc38 in ListaCopas38)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc38)
                                {
                                    double Porcentagem = vlrliquido * (1 - 0.05);
                                    double porcentagem2 = Porcentagem * (1 - 0.05);
                                    double porcentagem3 = porcentagem2 * (1 - 0.05);
                                    double porcentagem4 = porcentagem3 * (1 - 0.05);
                                    double porcentagem5 = porcentagem4 * (1 - 0.05);
                                    double porcentagem6 = porcentagem5 * (1 - 0.05);
                                    double porcentagem7 = porcentagem6 * (1 - 0.05);
                                    resultadoliquido = porcentagem7 * (1 - 0.05);
                                    resultadobruto = resultadoliquido + textoEmbalagem;
                                    tblliquido.Add(resultadoliquido);
                                    tblsku.Add(item.colunaskus);
                                    tblbruto.Add(resultadobruto);
                                    tblbojo.Add("38");
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc40 in ListaCopas40)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc40)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("40");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc42 in ListaCopas042)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc42)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("42");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc44 in ListaCopas44)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc44)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("44");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc46 in ListaCopas46)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc46)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("46");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc48 in ListaCopas48)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc48)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("48");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = resultadoliquido * (1 + 0.05);


                        foreach (string lc50 in ListaCopas50)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);

                                if (sku == lc50)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("50");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }


                        resultadoliquido = resultadoliquido * (1 + 0.05);

                        foreach (string lc52 in ListaCopas52)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc52)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("52");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }

                        resultadoliquido = vlrliquido;

                        foreach (string lc54 in ListaCopas54)
                        {
                            foreach (var item in alimentarlista)
                            {
                                string skunumero = item.colunaskus.Substring(11, 2);
                                string skuletra = item.colunaskus.Substring(15);
                                string sku = Convert.ToString(skunumero + skuletra);
                                if (sku == lc54)
                                {
                                    tblsku.Add(item.colunaskus);
                                    tblbojo.Add("54");
                                    tblbruto.Add(resultadobruto);
                                }
                            }
                        }
                    }



                    else
                    {
                        if (QntZero == "0")
                        {
                            foreach (string lc38 in ListaCopas38)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc38)
                                    {
                                        double Porcentagem = vlrliquido * (1 - 0.05);
                                        double porcentagem2 = Porcentagem * (1 - 0.05);
                                        double porcentagem3 = porcentagem2 * (1 - 0.05);
                                        double porcentagem4 = porcentagem3 * (1 - 0.05);
                                        double porcentagem5 = porcentagem4 * (1 - 0.05);
                                        double porcentagem6 = porcentagem5 * (1 - 0.05);
                                        double porcentagem7 = porcentagem6 * (1 - 0.05);
                                        resultadoliquido = porcentagem7 * (1 - 0.05);
                                        resultadobruto = resultadoliquido + textoEmbalagem;
                                        tblliquido.Add(resultadoliquido);
                                        tblsku.Add(item.colunaskus);
                                        tblbruto.Add(resultadobruto);
                                        tblbojo.Add("38");
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc40 in ListaCopas40)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc40)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("40");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc42 in ListaCopas042)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc42)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("42");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc44 in ListaCopas44)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc44)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("44");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc46 in ListaCopas46)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc46)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("46");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc48 in ListaCopas48)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc48)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("48");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = resultadoliquido * (1 + 0.05);


                            foreach (string lc50 in ListaCopas50)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);

                                    if (sku == lc50)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("50");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }


                            resultadoliquido = resultadoliquido * (1 + 0.05);

                            foreach (string lc52 in ListaCopas52)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc52)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("52");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }

                            resultadoliquido = vlrliquido;

                            foreach (string lc54 in ListaCopas54)
                            {
                                foreach (var item in alimentarlista)
                                {
                                    string skunumero = item.colunaskus.Substring(11, 2);
                                    string skuletra = item.colunaskus.Substring(15);
                                    string sku = Convert.ToString(skunumero + skuletra);
                                    if (sku == lc54)
                                    {
                                        tblsku.Add(item.colunaskus);
                                        tblbojo.Add("54");
                                        tblbruto.Add(resultadobruto);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            for (int y = 0; y < alimentarlista.Count; y++)
            {
                if (alimentarlista[y] != null)
                {

                    Listasku skuss = new Listasku();
                    skuss.colunaembalagem = Convert.ToString(textoEmbalagem);
                    skuss.colunaliquido = tblliquido[y].ToString("0.000");
                    skuss.colunabojo = Convert.ToString(tblbojo[y]);
                    skuss.colunaskus = Convert.ToString(tblsku[y]);
                    skuss.colunabruto = tblbruto[y].ToString("0.000");
                    lstskus.Add(skuss);
                }
            }
            gridMedidas.DataSource = lstskus;
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog salvar = new SaveFileDialog(); // novo

            Excel.Application App; // Aplicação Excel
            Excel.Workbook WorkBook; // Pasta
            Excel.Worksheet WorkSheet; // Planilha
            object misValue = System.Reflection.Missing.Value;

            App = new Excel.Application();
            WorkBook = App.Workbooks.Add(misValue);
            WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;

            // passa as celulas do DataGridView para a Pasta do Excel

            for (i = 0; i <= gridMedidas.RowCount - 1; i++)
            {
                for (j = 0; j <= gridMedidas.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = gridMedidas[j, i];
                    WorkSheet.Cells[i + 1, j + 1] = cell.Value;
                }
            }

            // define algumas propriedades da caixa salvar
            salvar.Title = "Exportar para Excel";
            salvar.Filter = "Arquivo do Excel *.xls | *.xls";
            salvar.ShowDialog(); // mostra

            // salva o arquivo
            WorkBook.SaveAs(salvar.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,

            Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            WorkBook.Close(true, misValue, misValue);
            App.Quit(); // encerra o excel

            MessageBox.Show("Exportado com sucesso!");

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
            MenuPrincipal menu = new MenuPrincipal();
            menu.ShowDialog();
        }
    }
}












