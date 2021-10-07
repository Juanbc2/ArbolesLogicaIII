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
    public partial class Form2 : Form
    {

        string nodos;
        ArbolBinario arbol = new ArbolBinario();


        public Form2(string nodos) //si envía sólo nodos
        {

            this.nodos = nodos;
            InitializeComponent();
            crearArbolConNodos();
            setArbolInfo();
        }
        public Form2(ArbolBinario arbol) //si envía ordenes
        {
            this.arbol = arbol;
            InitializeComponent();
            setArbolInfo();
        }
        public Form2(int numRandom) //si envía nodos para generar random
         {
            InitializeComponent();
            crearArbolAleatorio(numRandom);
            setArbolInfo();
        }


        public void crearArbolAleatorio(int rand)
        {
            Random rm = new Random();
            for (int i = 0; i < rand; i++)
            {
                arbol.insertarDato(rm.Next(0,100));
            }
        }

        public void crearArbolConNodos()
        {
            string[] nodosList = nodos.Split(',');
            for (int i = 0; i < nodosList.Length; i++)
            {
                arbol.insertarDato(nodosList[i]);
            }
        }


        //cargar info arbol
        int getHojas(nodoDoble r)
        {

            int hh = 0;
            if (r != null)
            {
                if (r.retornaLi() == null && r.retornaLd() == null)
                {
                    hh = hh + 1;
                }
                else
                {
                    hh = hh + getHojas(r.retornaLi()) + getHojas(r.retornaLd());
                }
            }
            return hh;
        }

        List<string> getHojasList(nodoDoble r,List<string> hojasList)
        {
            if (r != null)
            {
                hojasList = getHojasList(r.retornaLi(),hojasList);
                if(arbol.hijos(r,0)==1) hojasList.Add(r.retornaDato().ToString());
                hojasList = getHojasList(r.retornaLd(),hojasList);
            }
            return hojasList;
        }

        int getGrado(nodoDoble r)
        {
            int g = 0;
            if (r != null)
            {
                if (r.retornaLi() != null && r.retornaLd() != null)
                {
                    g = 2;
                }
                else
                {
                    if (r.retornaLi() != null || r.retornaLd() != null)
                    {
                        g = 1;
                    }
                }
                if (g == 2) return g;
                g = getGrado(r.retornaLi());
                if (g == 2) return g;
                g = getGrado(r.retornaLd());
            }
            return g;
        }

        int getAltura(nodoDoble r)
        {
            int altizq, altder;
            if (r == null)
            {
                return 0;
            }
            altizq = 0;
            altder = 0;
            if (r.retornaLi() != null)
            {
                altizq = getAltura(r.retornaLi());
            }
            if (r.retornaLd() != null)
            {
                altder = getAltura(r.retornaLd());
            }
            return mayor(altizq, altder) + 1;
        }

     	int  mayor(int a, int b){
		    if (a > b)  return a;
		    return  b;
        }

        void setArbolInfo()
        {
            string altura = "La altura del árbol es: " + getAltura(arbol.getRaiz())+"\n";
            string grado = "El grado del árbol es: " + getGrado(arbol.getRaiz())+"\n";
            List<string> hojasList= new List<string>();
            List<string> inordenList = new List<string>();
            List<string> preordenList = new List<string>(); 
            List<string> posordenList = new List<string>();
            hojasList = getHojasList(arbol.getRaiz(),hojasList);
            inordenList = arbol.inorden(arbol.getRaiz(), inordenList);
            preordenList = arbol.preorden(arbol.getRaiz(), preordenList);
            posordenList = arbol.posorden(arbol.getRaiz(), posordenList);
            string hojas = "Las hojas del árbol son: ";
            string inorden = "El recorrido inorden es: ";
            string preorden ="El recorrido preorden es: ";
            string posorden = "El recorrido posorden es: ";
            foreach(string a in hojasList) hojas = hojas + "," + a;
            foreach (string a in inordenList) inorden = inorden + "," + a;
            foreach (string a in preordenList) preorden = preorden + "," + a;
            foreach (string a in posordenList) posorden = posorden + "," + a;
            infoLabel.Text = altura + grado + hojas+"\n"+inorden+"\n"+preorden+"\n"+posorden;
        }

        //fin info arbol

        //info nodos
       int isIzq(string nodo) //si es izquierdo, retorna 1, si es derecho, retorna 2, si es la raíz retorna 3
        {
            nodoDoble padre= new nodoDoble("");
            padre = arbol.buscarDato(arbol.getRaiz(),arbol.padre(arbol.getRaiz(),nodo),padre);
            nodoDoble nodoActual = new nodoDoble("");
            nodoActual = arbol.buscarDato(arbol.getRaiz(), nodo, padre);
            if (padre != null)
            {
                if (padre.retornaLi() == nodoActual) return 1;
                if (padre.retornaLd() == nodoActual) return 2;
            }
           return 3;
        }

       private void button1_Click(object sender, EventArgs e)
       {
           nodoDoble aux = new nodoDoble("");
           if (arbol.buscarDato(arbol.getRaiz(), textBox1.Text, aux).retornaDato().ToString() != "")
           {
               int izqOrDer = isIzq(textBox1.Text);
               string padre = arbol.padre(arbol.getRaiz(), textBox1.Text);
               string abuelo = arbol.padre(arbol.getRaiz(), arbol.padre(arbol.getRaiz(), textBox1.Text));
               List<string> ancestros = arbol.ancestros(textBox1.Text);
               padreLabel.Text = ("el padre es: " + checkInfo(padre));
               abueloLabel.Text = ("el abuelo es: " + checkInfo(abuelo));
               if (ancestros.Count == 0) ancestrosLabel.Text = ("No tiene ancestros.");
               else ancestrosLabel.Text = "los ancestros son: ";
               foreach (string a in ancestros) ancestrosLabel.Text = ancestrosLabel.Text + "," + a;


               if (izqOrDer == 1) //el nodo es izquierdo 
               {
                   direccionLabel.Text = ("el nodo es izquierdo.");
               }
               else if (izqOrDer == 2) //el nodo es derecho
               {
                   direccionLabel.Text = ("el nodo es derecho.");
               }
               else
               {
                   direccionLabel.Text = ("el nodo no tiene dirección.");
               }
               string tio = "";
               string hermano = "";
               //hermano
               try
               {
                   if (izqOrDer == 1) hermano = arbol.buscarDato(arbol.getRaiz(), arbol.padre(arbol.getRaiz(), textBox1.Text), aux).retornaLd().retornaDato().ToString();
                   else if (izqOrDer == 2) hermano = arbol.buscarDato(arbol.getRaiz(), arbol.padre(arbol.getRaiz(), textBox1.Text), aux).retornaLi().retornaDato().ToString();
               }
               catch (Exception error) { //Console.WriteLine(error); 
               }
               hermanoLabel.Text = ("El hermano es: " + checkInfo(hermano));
               //tío
               try
               {
                   if (isIzq(arbol.padre(arbol.getRaiz(), textBox1.Text)) == 1) tio = arbol.buscarDato(arbol.getRaiz(), arbol.padre(arbol.getRaiz(), arbol.padre(arbol.getRaiz(), textBox1.Text)), aux).retornaLd().retornaDato().ToString();
                   else if (isIzq(arbol.padre(arbol.getRaiz(), textBox1.Text)) == 2) tio = arbol.buscarDato(arbol.getRaiz(), arbol.padre(arbol.getRaiz(), arbol.padre(arbol.getRaiz(), textBox1.Text)), aux).retornaLi().retornaDato().ToString();
               }
               catch (Exception error) {//Console.WriteLine(error); 
               }
               tioLabel.Text = ("El tío es: " + checkInfo(tio));
               int numHijos = 0;
               hijosLabel.Text = ("La cantidad de hijos es: " + (arbol.hijos(arbol.buscarDato(arbol.getRaiz(), textBox1.Text, aux), numHijos) - 1));
           }
           else
           {
               MessageBox.Show("Asegúrese de ingresar un nodo existente.");
           }
       }



        private string checkInfo(string info) //mirar si no viene vacía la información de parientes
        {
            if (info == "")
            {
                return "no tiene.";
            }
            else
            {
                return info;
            }
        }
        // fin info nodos
        //Fin construyeConNodos

    }

 


    

    public class ArbolBinario
    {

        private nodoDoble primero, raiz;
        private List<nodoDoble> listOrden = new List<nodoDoble>();
        private int length = 0;
        public List<nodoDoble> getListOrden()
        {
            return listOrden;
        }

        public int getLength()
        {
            return length;
        }

        public ArbolBinario()
        {
            this.primero = new nodoDoble(null);
            this.primero.asignaLi(primero);
            this.primero.asignaLd(primero);
        }

        public void inorden(nodoDoble  r){
		    if(r != null){
		        inorden(r.retornaLi());
		        //Console.WriteLine(r.retornaDato());
		        inorden(r.retornaLd());
            }
        }

        public void posorden(nodoDoble  r){
		    if(r != null){
		        posorden(r.retornaLi());
		        posorden(r.retornaLd());
                //Console.WriteLine(r.retornaDato());
            }
        }

        public void preorden(nodoDoble  r){
		    if(r != null){
                //Console.WriteLine(r.retornaDato());
		        preorden(r.retornaLi());
		        preorden(r.retornaLd());
            }
        }

        public List<string> inorden(nodoDoble r,List<string> inordenList)
        {
            if (r != null)
            {
                inordenList = inorden(r.retornaLi(),inordenList);
                inordenList.Add(r.retornaDato().ToString());
                inordenList = inorden(r.retornaLd(),inordenList);
            }
            return inordenList;
        }

        public List<string> posorden(nodoDoble r,List<string> posordenList)
        {
            if (r != null)
            {
                posordenList = posorden(r.retornaLi(),posordenList);
                posordenList = posorden(r.retornaLd(),posordenList);
                posordenList.Add(r.retornaDato().ToString());
            }
            return posordenList;
        }

        public List<string> preorden(nodoDoble r,List<string> preordenList)
        {
            if (r != null)
            {
                preordenList.Add(r.retornaDato().ToString());
                preordenList = preorden(r.retornaLi(),preordenList);
                preordenList = preorden(r.retornaLd(),preordenList);
            }
            return preordenList;
        }


        public nodoDoble getRaiz()
        {
            return raiz;
        }

        public void setRaiz(nodoDoble raiz)
        {
            this.raiz = raiz;
        }


        public void insertarDato(string d)
        {
            this.length++;
            nodoDoble x = new nodoDoble(d);
            if (getRaiz() == null)
            {
                setRaiz(x);
                return;
            }
            nodoDoble p = getRaiz();
            nodoDoble q = null;
            nodoDoble pivote = getRaiz();
            nodoDoble pp = null;
            while (p != null)
            {
                if (String.Compare(p.retornaDato().ToString(), d) == 0)
                {
                    return;
                }
                if (p.getFactor() != 0)
                {
                    pivote = p;
                    pp = q;
                }
                q = p;
                if (String.Compare(p.retornaDato().ToString(),d) == 1)
                {
                    p = p.retornaLi();
                }
                else
                {
                    p = p.retornaLd();
                }
            }
            if (String.Compare(q.retornaDato().ToString(),d) == 1)
            {
                q.asignaLi(x);
            }
            else
            {
                q.asignaLd(x);
            }
            int aux = pivote.getFactor();
            if (String.Compare(pivote.retornaDato().ToString(),d) == 1)
            {
                pivote.setFactor(aux + 1);
                q = pivote.retornaLi();
            }
            else
            {
                pivote.setFactor(aux - 1);
                q = pivote.retornaLd();
            }
            p = q;
            while (p != x)
            {
                if (String.Compare(p.retornaDato().ToString(),d) == 1)
                {
                    p.setFactor(+1);
                    p = p.retornaLi();
                }
                else
                {
                    p.setFactor(-1);
                    p = p.retornaLd();
                }
            }
        }

        public void insertarDato(int d)
        {
            this.length++;
            nodoDoble x = new nodoDoble(d);
            if (getRaiz() == null)
            {
                setRaiz(x);
                return;
            }
            nodoDoble p = getRaiz();
            nodoDoble q = null;
            nodoDoble pivote = getRaiz();
            nodoDoble pp = null;
            while (p != null)
            {
                if ((int)p.retornaDato() == d)
                {
                    return;
                }
                if (p.getFactor() != 0)
                {
                    pivote = p;
                    pp = q;
                }
                q = p;
                if ((int)p.retornaDato() > d)
                {
                    p = p.retornaLi();
                }
                else
                {
                    p = p.retornaLd();
                }
            }
            if ((int)q.retornaDato() > d)
            {
                q.asignaLi(x);
            }
            else
            {
                q.asignaLd(x);
            }
            int aux = pivote.getFactor();
            if ((int)pivote.retornaDato() > d)
            {
                pivote.setFactor(aux + 1);
                q = pivote.retornaLi();
            }
            else
            {
                pivote.setFactor(aux - 1);
                q = pivote.retornaLd();
            }
            p = q;
            while (p != x)
            {
                if ((int)p.retornaDato() > d)
                {
                    p.setFactor(+1);
                    p = p.retornaLi();
                }
                else
                {
                    p.setFactor(-1);
                    p = p.retornaLd();
                }
            }
        }


        public nodoDoble buscarDato(nodoDoble r,string dato,nodoDoble aux)
        {
            if (r != null)
            {
                aux = buscarDato(r.retornaLi(),dato,aux);
                if (String.Compare(dato, r.retornaDato().ToString()) == 0)
                {
                    ////Console.WriteLine("econtrado");
                    return aux = r;
                }   
                aux = buscarDato(r.retornaLd(),dato,aux);
            }
            return aux;
        }



        bool finDeRecorrido(nodoDoble x)
        {
            return x == null;
        }


        //cargar info nodo
        public string padre(nodoDoble r, string dato)
        {
            string d,pad;
            nodoDoble p;
            pad = "";
            if (r != null)
            {
                if (r.retornaLi() != null)
                {
                    p = r.retornaLi();
                    d = p.retornaDato().ToString();
                    if (String.Compare(d.ToString(),dato) == 0)
                    {
                        pad = r.retornaDato().ToString();
                    }
                }
                if (pad == "")
                {
                    if (r.retornaLd() != null)
                    {
                        p = r.retornaLd();
                        d = p.retornaDato().ToString();
                        if (d == dato)
                        {
                            pad = r.retornaDato().ToString();
                        }
                    }
                }
                if (pad == "")
                {
                    pad = padre(r.retornaLi(), dato);
                    if (pad == "")
                    {
                        pad = padre(r.retornaLd(), dato);
                    }
                }
            }
            return pad;
        }


        public List<string> ancestros(string dato)
        {
            string p;
            List<string> ancestrosList = new List<string>();
            Stack<object> pila = new Stack<object>();
            p = padre(raiz, dato);
            while (p != "")
            {
                pila.Push(p);
                p = padre(raiz, p);
            }
            while (pila.Count!=0)
            {
                p = pila.Pop().ToString();
                ancestrosList.Add(p);
            }
            return ancestrosList;
        }

        public int hijos(nodoDoble r,int numHijos)
        {
            if (r != null)
            {
                numHijos = hijos(r.retornaLi(),numHijos);
                numHijos = hijos(r.retornaLd(),numHijos);
                numHijos++;
            }
            return numHijos;
        }

        //fin cargar info nodo
    }


    public class nodoDoble
    {
        private Object dato;
        private nodoDoble ld, li;
        int factor;


        public nodoDoble(Object d)
        {
            this.dato = d;
            li = null;
            ld = null;
        }

        public void asignaDato(Object d)
        {
            dato = d;
        }

        public void asignaLi(nodoDoble x)
        {
            li = x;
        }
        public void asignaLd(nodoDoble x)
        {
            ld = x;
        }
        public Object retornaDato()
        {
            return this.dato;
        }
        public nodoDoble retornaLi()
        {
            return this.li;
        }
        public nodoDoble retornaLd()
        {
            return this.ld;
        }

        public int getFactor()
        {
            return factor;
        }

        public void setFactor(int factor)
        {
            this.factor = factor;
        }
    }
}
