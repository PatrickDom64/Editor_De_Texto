using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor_De_Texto
{
    public partial class Form1 : Form
    {

        StringReader leitura = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void bt_Novo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //IMPRIMIR
        private void Imprimir()
        {

            printDialog1.Document = printDocument1;
            string texto = this.richTextBox1.Text;
            leitura = new StringReader(texto);
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDialog1.Print();
            }


        }



        private void Novo() {

            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Salvar()
        {
            try {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter cfb_streamWriter = new StreamWriter(arquivo);
                    cfb_streamWriter.Flush();
                    cfb_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    cfb_streamWriter.Write(this.richTextBox1.Text);
                    cfb_streamWriter.Flush();
                    cfb_streamWriter.Close();

                }
            } catch (Exception ex) {
                MessageBox.Show("Erro na gravação:" + ex.Message, "Erro na gravação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void bt_Salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Abrir()
        {

            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"C:\Users\patrick.silva\Documents\Textos do meu editor Test";
            openFileDialog1.Filter = "(*.txt)|*txt";
            DialogResult dr = this.openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {

                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                    StreamReader cfb_streamReader = new StreamReader(arquivo);
                    cfb_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = cfb_streamReader.ReadLine();

                    while (linha != null)
                    {

                        this.richTextBox1.Text = linha + "\n";
                        linha = cfb_streamReader.ReadLine();

                    }
                    cfb_streamReader.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro na gravação:" + ex.Message, "Erro na gravação", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void Copiar() {

            if (richTextBox1.SelectionLength > 0) {
                richTextBox1.Copy();
            }

        }
        private void Colar()
        {
            richTextBox1.Paste();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void Negrito() {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool n, i, s = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;
            if (n == false) {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
            }
            else {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
            }
        }

        private void Italico()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool ita = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            ita = richTextBox1.Font.Italic;

            if (ita == false)
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
            }
        }

        private void Sublinhado()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool sub = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            sub = richTextBox1.Font.Italic;

            if (sub == false)
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
            }
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void italicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void alinharEsquerda() {

            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;

        }
        private void alinharDireita()
        {

            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;

        }
        private void alinharCentro()
        {

            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPagina = 0;
            
            float posY = 0;
            
            float posX = 0;

            int cont = 0;
            
            float margemEsquerda = e.MarginBounds.Left - 50;
            
            float margemSuperior = e.MarginBounds.Top - 50;

            if (margemEsquerda < 5) {
            
                margemEsquerda = 20;
            
            }
         if(margemSuperior< 5 ){
            
                margemSuperior = 20;
                
            }
            
            string linha = null;
            
            Font fonte = this.richTextBox1.Font;
            
            SolidBrush pincel = new SolidBrush(Color.Black);
            
            linhasPagina= e.MarginBounds.Height / fonte.GetHeight(e.Graphics);
           
            linha = leitura.ReadLine();
            
                 while(cont < linhasPagina){
                   posY = (margemSuperior + (cont * fonte.GetHeight(e.Graphics)));
                   
                   e.Graphics.DrawString(linha,fonte,pincel ,margemEsquerda,posY,new StringFormat());
                      
                   cont++;
                  }
            if (linha != null) { 
            e.HasMorePages = true;
            }
            else { 
            e.HasMorePages= false;
            }
            pincel.Dispose();
        }
    }
    
}
