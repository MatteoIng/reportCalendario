//using Syncfusion.Pdf;
//using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace reportCalendario32
{
    public partial class FormMain : Form
    {
        //giorni in formato numerico
        private List<string> valore = new List<string>();
        //giorni in stringhe
        private List<string> giorni = new List<string>();
        //giorni festivi
        private List<DateTime> giorniFestivi = new List<DateTime>();
        //parametro del mese per generare i report
        private int valMese;
        private Bitmap bitmap;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inizializzaGiorniFestivi();
            //come default se il parametro in input non viene messo prende il corrente
            valMese = DateTime.Now.Month;
            //stampa abilitato solo dopo la generazione della tabella
            stampa.Enabled = false;
            lista.Width =360;
        }



        //main
        private void genera_Click(object sender, EventArgs e)
        {
            //per sicurezza ripulisco la lista se si e dimenticato di fare reset
            lista.Rows.Clear();
            //inizializzo con mese e anno la lista
            //lista.Rows.Add(valMese);

            //controllo il parametro in input, per il mese da generare
            checkInput();

            //prendo il giorno corrente
            DateTime now = DateTime.Now;
            //prendo l'inizio del mese richiesto
            DateTime inizioMese = new DateTime(now.Year, valMese, 1);
            //prendo i giorni del mese richiesto
            int days = DateTime.DaysInMonth(now.Year, valMese);

            //dal 1 del mese richiesto fino al 28 o 30 o 31 del mese richisto
            for (int i = 1; i <= days; i++)
            {
                //genero ogni giorno
                DateTime corrente = new DateTime(now.Year, valMese, i);
                //salvo i numeri che mi serviranno per stampare la tabella
                valore.Add(i.ToString());
                //salvo i giorni nell'ordine in cui si presentano
                giorni.Add(corrente.DayOfWeek.ToString());

                //nella datagridview inserisco una riga composta da valore giorno numerico e giorno
                lista.Rows.Add(i.ToString(), traduttore(corrente.DayOfWeek.ToString()));
            }
            stampa.Enabled = true;

            //colore la lista dove c'è sabato domenica o festività
            coloraLista();
            titolo.Text = "1-"+days+"/"+valMese + "/" + now.Year;
        }



        //controlla che il parametro in input sia conforme ai mesi dell'anno 1-12
        public void checkInput()
        {
            if (!mese.Text.Equals(""))
            {
                valMese = Convert.ToInt16(mese.Text);
                if (valMese > 12 || valMese < 0)
                {
                    valMese = DateTime.Now.Month;
                }
            }
        }



        //sabato, domenica e le festività me le segna in rosso
        public void coloraLista()
        {
            for (int i=0; i< lista.RowCount-1; i++)
            {
                if (lista.Rows[i].Cells[1].Value.Equals("Sabato") || lista.Rows[i].Cells[1].Value.Equals("Domenica"))
                {
                    //non controllo se festivo già è rosso perche weekend
                    lista.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                }
                else
                {
                    //controllo se è festivo
                    int d = Convert.ToInt16(lista.Rows[i].Cells[0].Value);
                    if (giorniFestivi.Contains(new DateTime(DateTime.Now.Year, valMese, d)))
                    {
                        lista.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    }
                }
            }
        }

        


        //inizializza in un lista i giorni festivi per segnarli rossi
        public void inizializzaGiorniFestivi()
        {
            //capodanno
            giorniFestivi.Add(new DateTime(DateTime.Now.Year, 1, 1));
            //epifania
            giorniFestivi.Add(new DateTime(DateTime.Now.Year, 1, 6));
            //1 maggio
            giorniFestivi.Add(new DateTime(DateTime.Now.Year, 5, 1));
            //ferragosto
            giorniFestivi.Add(new DateTime(DateTime.Now.Year, 8, 15));
            //i defunti
            giorniFestivi.Add(new DateTime(DateTime.Now.Year, 11, 1));
            //8 dicembre
            giorniFestivi.Add(new DateTime(DateTime.Now.Year, 12, 8));
            //natale
            giorniFestivi.Add(new DateTime(DateTime.Now.Year, 12, 25));
            //santostefano
            giorniFestivi.Add(new DateTime(DateTime.Now.Year, 12, 26));
        }



        //svuta sia la datagridview che il campo di input 
        private void reset_Click(object sender, EventArgs e)
        {
            mese.Text = "";
            lista.Rows.Clear();
            stampa.Enabled = false;
            titolo.Text = "";
        }



        //Bottone stampa
        private void stampa_Click(object sender, EventArgs e)
        {
            lista.ClearSelection();
            catturaListaBMP();
            //report.Print();
            previewReport.Document = report;
            previewReport.ShowDialog();
        }



        //quando report.print()
        //in teoria ma no
        private void report_PrintPage(object sender, PrintPageEventArgs e)
        {
            //mi serve per centrare il titolo
            int xTitolo =bitmap.Width/2-(titolo.Width/2)+249;
            int yTitolo = 100 - 25;

            //cornice data
            e.Graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(249,65),new Size(bitmap.Width,49)));
            //data
            e.Graphics.DrawString(titolo.Text,DefaultFont,Brushes.Black,new RectangleF(xTitolo,yTitolo, (float)(2 *titolo.Width), (float)(2 *titolo.Height)));
            //tabella dati
            e.Graphics.DrawImage(bitmap, new RectangleF(200, 100, 1.2f * bitmap.Width, 1.2f * bitmap.Height));
        }




        public void catturaListaBMP()
        {
            //mi salvo l'altezza della lista visualizzata
            int heigth = lista.Height;

            //creo ogetto bitmap
            bitmap = new Bitmap(lista.Width, (lista.Height * lista.RowCount));

            //setto la lista alta quanto il numero di righe
            //per la grandezza di ogni riga per vederla intera
            lista.Height = lista.RowTemplate.Height * lista.RowCount;
            //disegno immagine
            lista.DrawToBitmap(bitmap, new Rectangle(0, 0, lista.Width-18, lista.Height));

            //imposto altezza lista come da applicazione di default
            lista.Height = heigth;

            //bmp.Save("report.bmp");
        }


        //traduce i giorni da inglese a italiano
        public string traduttore(string s)
        {
            string traduttore="";

            if (s.Equals("Monday"))
            {
                traduttore="Lunedì";
            }
            else if (s.Equals("Tuesday"))
            {
                traduttore="Martedì";
            }
            else if (s.Equals("Wednesday"))
            {
                traduttore="Mercoledì";
            }
            else if (s.Equals("Thursday"))
            {
                traduttore="Giovedì";
            }
            else if (s.Equals("Friday"))
            {
                traduttore="Venerdì";
            }
            else if (s.Equals("Saturday"))
            {
                traduttore="Sabato";
            }
            else if (s.Equals("Sunday"))
            {
                traduttore="Domenica";
            }

            return traduttore;
        }
    }
}