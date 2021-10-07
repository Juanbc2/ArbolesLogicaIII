using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolesLogicaIII
{
    public partial class Form1 : Form
    {


        Form2 fm2;
        ArbolBinario arbol = new ArbolBinario();

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e) //ingresado 
        {
            fm2 = new Form2(textBox1.Text);
            fm2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) //inorden y preorden/posorden
        {
            String inorden= textBox2.Text;
            String orden = textBox3.Text;
            bool isPreOrden=true;
            var checkedButton = panel1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            if (checkedButton.Equals(radioButton1))
            {
                isPreOrden = true;
            }else if(checkedButton.Equals(radioButton2)){
                isPreOrden = false;
            }
            int[] inordenR = inorden.Split(',').Select(Int32.Parse).ToArray();
            int[] ordenR = orden.Split(',').Select(Int32.Parse).ToArray();
            try
            {
            construyeConRecorridos(inordenR, ordenR, isPreOrden);
            fm2 = new Form2(arbol);
            fm2.ShowDialog();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al cargar los recorridos, por favor revise los recorridos ingresados.\n");
            }

        }

        private void button3_Click(object sender, EventArgs e) //aleatorio
        {
            fm2 = new Form2(Convert.ToInt32(Math.Round(numericUpDown1.Value)));
            fm2.ShowDialog();
        }


        //Construir con recorridos

        void construyeConRecorridos(int[] ino, int[] ord, bool isPre)
        {//inorden y preorden
            nodoDoble raiz;
            if (isPre)
            {
                raiz = reconstruyePreorden(ino, ord);
            }
            else
            {
                raiz = reconstruyePosorden(ino, ord);
            }
            arbol.setRaiz(raiz);
        }


        nodoDoble reconstruyePreorden(int[] ino, int[] pre)
        {
            nodoDoble x;
            int k;
            int[] ain, apre;
            if (ino.Length == 0) return null;
            x = new nodoDoble(pre[0]);
            //Console.WriteLine("pre[0] es: " + pre[0]);
            List<int> aux = ino.ToList();
            k = aux.IndexOf(pre[0]);
            //Console.WriteLine("k es:" + k);
            apre = new ArraySegment<int>(pre, 1, k).ToArray();
            ain = new ArraySegment<int>(ino, 0, k).ToArray();
            x.asignaLi(reconstruyePreorden(ain, apre));
            //Console.WriteLine("test: " + (k) + " " + (ino.Length));
            apre = new ArraySegment<int>(pre, k + 1, ino.Length - (k + 1)).ToArray();
            //Console.WriteLine("test: " + (k) + " " + (ino.Length));
            ain = new ArraySegment<int>(ino, k + 1, ino.Length - (k + 1)).ToArray();
            x.asignaLd(reconstruyePreorden(ain, apre));
            return x;
        }

        nodoDoble reconstruyePosorden(int[] ino, int[] pos)
        {
            nodoDoble x;
            int k;
            int[] ain, apos;
            if (ino.Length == 0) return null;
            x = new nodoDoble(pos[ino.Length - 1]);
            //Console.WriteLine("pre[ini.length-1] es: " + pos[ino.Length - 1]);
            List<int> aux = ino.ToList();
            k = aux.IndexOf(pos[ino.Length - 1]);
            //Console.WriteLine("k es:" + k);
            apos = new ArraySegment<int>(pos, ino.Length - (k + 1), k).ToArray();
            ain = new ArraySegment<int>(ino, k + 1, k).ToArray();
            x.asignaLd(reconstruyePosorden(ain, apos));
            //Console.WriteLine("test: " + (k) + " " + (ino.Length));
            apos = new ArraySegment<int>(pos, 0, k).ToArray();
            //Console.WriteLine("test: " + (k) + " " + (ino.Length));
            ain = new ArraySegment<int>(ino, 0, k).ToArray();
            x.asignaLi(reconstruyePosorden(ain, apos));
            return x;
        }


    }
}
