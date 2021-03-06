﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDiseno;


namespace _2_Parcial_Juan_Jose_Gamez_Blanco
{
    public partial class _2do_Parcial : Form
    {
        string usuarioact;
        private int childFormNumber = 0;

        public _2do_Parcial()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void _2do_Parcial_Load(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            login.ShowDialog();
            LblUsuario.Text = login.obtenerNombreUsuario();
            usuarioact = LblUsuario.Text;
        }

        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleado nuevo = new Empleado(usuarioact);
            nuevo.MdiParent = this.MdiParent;
            nuevo.Show();
        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Puesto nuevo = new Puesto(usuarioact);
            nuevo.MdiParent = this.MdiParent;
            nuevo.Show();
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Departamento nuevo = new Departamento(usuarioact);
            nuevo.MdiParent = this.MdiParent;
            nuevo.Show();
        }

        private void conceptosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conceptos nuevo = new Conceptos(usuarioact);
            nuevo.MdiParent = this.MdiParent;
            nuevo.Show();
        }

        private void nominaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Nomina nuevo = new Nomina(usuarioact);
            nuevo.MdiParent = this.MdiParent;
            nuevo.Show();
        }

        private void transferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Autorizacion nuevo = new Autorizacion(usuarioact);
            nuevo.MdiParent = this.MdiParent;
            nuevo.Show();
        }
    }
}
