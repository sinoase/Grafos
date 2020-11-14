using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Grafos
{
    public partial class Simulador : Form
    {
        private CGrafo grafo; //Se usará para instanciar la clase grafo
        private CVertice nuevoNodo;//Se usará para instanciar CVertice para crear el nodo "nodoNuevo"
        private CVertice NodoOrigen;//Se usará para instanciar CVertice para crear el nodo "NodoNuevo"
        private CVertice NodoDestino;//Se usará para instanciar CVertice para crear el nodo "NodoDestino"
        private int var_control = 0;//Se usará para determinar el estado de la pizarra
                                    //0: Sin acción, 1: Dibujando arco, 2: Nuevo vértice

        //Variables para el control de ventanas modales
        private Vertice ventanaVertice;//Ventana para agregar los vértices

        public Simulador()
        {
            InitializeComponent();
            grafo = new CGrafo();
            nuevoNodo = null;
            var_control = 0;
            ventanaVertice = new Vertice();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

        }


        private void NuevoVertice_Click(object sender, EventArgs e)
        {
         
            nuevoNodo = new CVertice();
            var_control = 2;
        }

        private void Pizarra_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                grafo.DibujarGrafo(e.Graphics);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pizarra_MouseLeave(object sender, EventArgs e)
        {
            Pizarra.Refresh();
        }

        private void Pizarra_MouseUp(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 1://Dibujando arco

                    if((NodoDestino=grafo.DetectarPunto(e.Location))!=null&&NodoOrigen!=NodoDestino)
                    {
                        if(grafo.AgregarArco(NodoOrigen,NodoDestino))//Se procede a crear la arista
                        {
                            int distX=Math.Abs(NodoDestino.Posicion.X-NodoOrigen.Posicion.X);
                            int distY=Math.Abs(NodoDestino.Posicion.Y-NodoOrigen.Posicion.Y);
                            double distancia=Math.Sqrt(distY*distY+distX*distX);
                            
                            
                            NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = (int)distancia;

                        }
                    }
                    var_control = 0;
                    NodoOrigen = null;
                    NodoDestino = null;
                    Pizarra.Refresh();
                    break;

            }
        }

        private void Pizarra_MouseMove(object sender, MouseEventArgs e)
        {
            switch(var_control)
            {
                case 2://Creando nuevo nodo
                    if (nuevoNodo != null)
                    {
                        int posX = e.Location.X;
                        int posY = e.Location.Y;
                        if (posX < nuevoNodo.Dimensiones.Width / 2)
                            posX = nuevoNodo.Dimensiones.Width / 2;
                        else if(posX>Pizarra.Size.Width-nuevoNodo.Dimensiones.Width/2)
                            posX = Pizarra.Size.Width -nuevoNodo.Dimensiones.Width/ 2;

                        if (posY < nuevoNodo.Dimensiones.Height/ 2)
                            posY = nuevoNodo.Dimensiones.Height/ 2;
                        else if (posY > Pizarra.Size.Height - nuevoNodo.Dimensiones.Height / 2)
                            posY = Pizarra.Size.Height - nuevoNodo.Dimensiones.Height / 2;

                        nuevoNodo.Posicion = new Point(posX, posY);
                        Pizarra.Refresh();
                        nuevoNodo.DibujarVertice(Pizarra.CreateGraphics());
                    }
                    break;
                case 1://Dibujar arco
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                    bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;
                    Pizarra.Refresh();
                    Pizarra.CreateGraphics().DrawLine
                   (
                        new Pen(Brushes.Black, 2)
                        {
                            CustomEndCap = bigArrow
                        },
                        NodoOrigen.Posicion,e.Location
                    );
                    break;
            }
        }

        private void Pizarra_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                {
                    var_control = 1;

                }
                if (nuevoNodo != null && NodoOrigen == null)
                {
                    ventanaVertice.Visible = false;
                    ventanaVertice.control = false;
                    grafo.AgregarVertice(nuevoNodo);
                    ventanaVertice.ShowDialog();

                    if (ventanaVertice.control)
                    {
                        if (grafo.BuscarVertice(ventanaVertice.txtVertice.Text) == null)
                        {
                            nuevoNodo.Valor = ventanaVertice.txtVertice.Text;

                        }
                        else
                        {
                            MessageBox.Show("El Nodo " + ventanaVertice.txtVertice.Text + " ya existe en el grafo", "Error nuevo nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }

                    }
                    nuevoNodo = null;
                    var_control = 0;
                    Pizarra.Refresh();
                }
              

      
            }
            if(e.Button==System.Windows.Forms.MouseButtons.Right)
            {
                if(var_control==0)
                {
                    if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                        CMSCrearVertice.Text = "Nodo " + NodoOrigen.Valor;
                    else
                        Pizarra.ContextMenuStrip = this.CMSCrearVertice;
                }
            }
        }
    }
}
