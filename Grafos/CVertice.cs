using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;// Libreria agregada, para el manejo de hilos de ejecucién
using System.Drawing;// Libreria agregada, para poder dibujar

using System.Drawing.Drawing2D;// Libreria agregada, para poder dibujar


namespace Grafos
{
    class CVertice
    {
        public string Valor;// Valor que almacena (representa) el nodo
        public List<CArco> ListaAdyacencia;// Lista de adyacencia del nodo
        /* Los diccionarios representan una colecci6n de claves y valores. El primer parametro representa
        gl tipo de las claves del diccionario, el segundo, el tipo de los valores del diccionario. */
        Dictionary<string, short> _banderas;
        Dictionary<string, short> _banderas_predeterminado;

        //Propiedades
        public Color Color { get => color_nodo; set => color_nodo = value; }// Guarda el valor del color del nodo
     
        public Color FontColor { get => color_fuente; set => color_fuente = value; }//Color de la fuente del nodo
        public Point Posicion { get => _posicion; set => _posicion = value; }//Guarda la posición x/y del nodo
        public Size Dimensiones //Guarda el valor del tamaño del nodo
        { 
            get => dimensiones;
            set 
            {
                radio = value.Width / 2;
                dimensiones = value;
            }
        }
        static int size = 35;//Tamaño del nodo
        //Valores privados que se usarán como getters y setters a la hora de llamar las propiedades
        Size dimensiones;
        Color color_nodo;
        Color color_fuente;
        Point _posicion;
        int radio;
     
        //Constructor de la clase
        public CVertice(string Valor)
        {
            this.Valor = Valor;
            this.ListaAdyacencia = new List<CArco>();
            this._banderas = new Dictionary<string, short>();
            this._banderas_predeterminado = new Dictionary<string, short>();
            this.Color = Color.Green;
            this.Dimensiones = new Size(size,size);
            this.FontColor = Color.White;
        }
        //Constructor por defecto
        public CVertice() : this("") { }

        //Método para dibujar el nodo
        public void DibujarVertice(Graphics g)
        {
                SolidBrush b = new SolidBrush(this.color_nodo);
                Rectangle areaNodo = new Rectangle(_posicion.X - radio, Posicion.Y - radio, dimensiones.Width, dimensiones.Height);
                g.FillEllipse(b, areaNodo);
                g.DrawString(Valor, new Font("Times New Roman", 14), new SolidBrush(color_fuente), _posicion.X, Posicion.Y,
                    new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    }
                    );
                g.DrawEllipse(new Pen(Brushes.Black, (float)1.0), areaNodo);
                b.Dispose();//Libera la memoria que ocupa el objeto
            
        }
        //Método para dibujar los arcos
        public void DibujarArco(Graphics g)
        {
            float distancia;
            int difY, difX;
            
            foreach(CArco arco in ListaAdyacencia)
            {
                difX = Posicion.X - arco.nDestino.Posicion.X;
                difY = Posicion.Y - arco.nDestino.Posicion.Y;
                distancia = (float)Math.Sqrt((difX * difX + difY * difY));

                AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;
                g.DrawLine(
                    new Pen(
                        new SolidBrush(arco.color), 
                        arco.grosor_flecha)
                            { CustomEndCap = bigArrow, Alignment = PenAlignment.Center },
                    _posicion,
                    new Point(arco.nDestino.Posicion.X+(int)(radio*difX/distancia),
                    arco.nDestino.Posicion.Y+(int)(radio*difY/distancia)
                    )
                );
     
                
                g.DrawString
                    (
                        arco.peso.ToString(),
                        new Font("Times New Roman",12),
                        new SolidBrush(Color.White),
              
                        _posicion.X-(int)difX/3,
                        _posicion.Y-(int)(difY/3),
                        new StringFormat()
                        {
                            Alignment=StringAlignment.Center,
                            LineAlignment=StringAlignment.Far
                        }
                    );

               
            }
        }
        //Método para detectar posición en el panel donde se dibujará el nodo.
        public bool DetectarPunto(Point p)
        {
      
            GraphicsPath posicion = new GraphicsPath();
            posicion.AddEllipse(new Rectangle(_posicion.X - dimensiones.Width / 2, _posicion.Y - dimensiones.Height / 2, dimensiones.Width, dimensiones.Height));
            bool retval = posicion.IsVisible(p);
            return retval;
        }
        public override string ToString()
        {
            return this.Valor;
        }
        
    }
}
