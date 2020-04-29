using System;
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
    public partial class Departamento : Form
    { string usuario;
        public Departamento(string user)
        {
            InitializeComponent();
            usuario = user;
            string[] alias = { "No", "Nombre", "Estado" }; // Arreglo de nombres para campos
            navegador1.asignarAlias(alias); // Asignar nombres
            navegador1.asignarSalida(this); // Asignar form de salida
            Color nuevoColor = System.Drawing.ColorTranslator.FromHtml("#0926E3"); // Deficion de 
            navegador1.asignarColorFondo(nuevoColor);
            navegador1.asignarColorFuente(Color.White);
            navegador1.asignarAyuda("1"); // asignar 1 por defecto 

            navegador1.asignarTabla("departamento"); // tabla principal
            navegador1.asignarNombreForm("Departamento"); // Titulo y nombre del form
        }

        private void Departamento_Load(object sender, EventArgs e)
        {
            string aplicacionActiva = "1";
            navegador1.ObtenerIdUsuario(usuario); // Pasa el parametro del usuario
            navegador1.botonesYPermisosInicial(usuario, aplicacionActiva); // Consulta permisos al iniciar
            navegador1.ObtenerIdAplicacion(aplicacionActiva);// Pasa el id de la aplicacion actual
        }
    }
}
