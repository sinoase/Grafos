namespace Grafos
{
    partial class Simulador
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Pizarra = new System.Windows.Forms.Panel();
            this.CMSCrearVertice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NuevoVertice = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSCrearVertice.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(200, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Simulador de Grafos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Pizarra
            // 
            this.Pizarra.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Pizarra.Location = new System.Drawing.Point(0, 80);
            this.Pizarra.Name = "Pizarra";
            this.Pizarra.Size = new System.Drawing.Size(582, 281);
            this.Pizarra.TabIndex = 1;
            this.Pizarra.Paint += new System.Windows.Forms.PaintEventHandler(this.Pizarra_Paint);
            this.Pizarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseDown);
            this.Pizarra.MouseLeave += new System.EventHandler(this.Pizarra_MouseLeave);
            this.Pizarra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseMove);
            this.Pizarra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseUp);
            // 
            // CMSCrearVertice
            // 
            this.CMSCrearVertice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevoVertice});
            this.CMSCrearVertice.Name = "contextMenuStrip1";
            this.CMSCrearVertice.Size = new System.Drawing.Size(148, 26);
            this.CMSCrearVertice.Text = "CMSCrearVértice";
            // 
            // NuevoVertice
            // 
            this.NuevoVertice.Name = "NuevoVertice";
            this.NuevoVertice.Size = new System.Drawing.Size(147, 22);
            this.NuevoVertice.Text = "Nuevo Vertice";
            this.NuevoVertice.Click += new System.EventHandler(this.NuevoVertice_Click);
            // 
            // Simulador
            // 
            this.AccessibleDescription = "Formulario simulador de grafos";
            this.AccessibleName = "Simulador";
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.Pizarra);
            this.Controls.Add(this.label1);
            this.Name = "Simulador";
            this.Text = "Simulador";
            this.CMSCrearVertice.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Pizarra;
        private System.Windows.Forms.ContextMenuStrip CMSCrearVertice;
        private System.Windows.Forms.ToolStripMenuItem NuevoVertice;
    }
}

