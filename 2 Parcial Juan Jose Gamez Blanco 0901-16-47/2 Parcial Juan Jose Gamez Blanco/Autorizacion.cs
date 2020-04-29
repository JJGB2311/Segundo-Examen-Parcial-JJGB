using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.IO;
using System.Net;

namespace _2_Parcial_Juan_Jose_Gamez_Blanco
{
    public partial class Autorizacion : Form
    {
        OdbcConnection conn = new OdbcConnection("Dsn=Parcial");
        string ppps;
        public Autorizacion(string user)
        {
            InitializeComponent();
            CoboBanco.Items.Add("Gyt Continental");
            CoboBanco.Items.Add("Banrural");
            CoboBanco.Items.Add("Industrial");
         
            llenartbl();
        }
        void llenartbl()
        {

            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("SELECT codigo_nomina,fecha_inicial_nomina FROM `nominae` WHERE estado=1;");
            try
            {
                OdbcDataAdapter eje = new OdbcDataAdapter();
                eje.SelectCommand = cod;
                DataTable datos = new DataTable();
                eje.Fill(datos);
                dataGridView1.DataSource = datos;
                eje.Update(datos);
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR" + e.ToString());
                conn.Close();

            }
        }
        void llenartbl2()
        {

            OdbcCommand cod = new OdbcCommand();
            cod.Connection = conn;
            cod.CommandText = ("SELECT codigo_nomina,codigo_empleado,codigo_concepto FROM nominad WHERE estado=1 AND codigo_nomina=" + txtcodigo.Text + ";");
            try
            {
                OdbcDataAdapter eje = new OdbcDataAdapter();
                eje.SelectCommand = cod;
                DataTable datos = new DataTable();
                eje.Fill(datos);
                dataGridView2.DataSource = datos;
                eje.Update(datos);
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR" + e.ToString());
                conn.Close();

            }
        }

        private void CoboBanco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Autorizacion_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
              
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                llenartbl2();

                /**/
                
            }
            else
            {
                MessageBox.Show("Seleccione un Registro!", "Planilla", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void Eliniar()
        {

            conn.Close();
            string query = "UPDATE `nominae` SET `estado` = '0' WHERE `nominae`.`codigo_nomina` = '" + txtcodigo.Text + "';";

            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
                llenartbl();


            }
            catch (Exception ex)
            {
                MessageBox.Show("\t Error! \n\n " + ex.ToString());
                conn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Eliniar();
            MessageBox.Show("La transferencia se realizo corectamente");
            this.Close();

        }
    }
}
