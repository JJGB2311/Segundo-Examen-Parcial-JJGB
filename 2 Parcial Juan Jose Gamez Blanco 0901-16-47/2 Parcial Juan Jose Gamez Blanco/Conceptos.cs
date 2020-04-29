﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_Parcial_Juan_Jose_Gamez_Blanco
{
    public partial class Conceptos : Form
    {
        string usuario;
        public Conceptos(string user)
        {
            InitializeComponent();
            usuario = user;
            string[] alias = { "Codigo", "Nombre", "Efecto", "Estado" }; // Arreglo de nombres para campos
            navegador1.asignarAlias(alias); // Asignar nombres
            navegador1.asignarSalida(this); // Asignar form de salida
            Color nuevoColor = System.Drawing.ColorTranslator.FromHtml("#0926E3"); // Deficion de 
            navegador1.asignarColorFondo(nuevoColor);
            navegador1.asignarColorFuente(Color.White);
            navegador1.asignarAyuda("1"); // asignar 1 por defecto 
                                          // navegador1.asignarComboConTabla("puesto", "nombre_puesto", 1); // 0 o 1 en modo, 0 pone el id y 1 coloca el nombre y consulta el id
                                          //navegador1.asignarComboConTabla("departamento", "nombre_departamento", 1); // 0 o 1 en modo, 0 pone el id y 1 coloca el nombre y consulta el id
            navegador1.asignarTabla("concepto"); // tabla principal
            navegador1.asignarNombreForm("Concepto"); // Titulo y nombre del form
        }

        private void Conceptos_Load(object sender, EventArgs e)
        {
            string aplicacionActiva = "1";
            navegador1.ObtenerIdUsuario(usuario); // Pasa el parametro del usuario
            navegador1.botonesYPermisosInicial(usuario, aplicacionActiva); // Consulta permisos al iniciar
            navegador1.ObtenerIdAplicacion(aplicacionActiva);// Pasa el id de la aplicacion actual
        }
    }
}
