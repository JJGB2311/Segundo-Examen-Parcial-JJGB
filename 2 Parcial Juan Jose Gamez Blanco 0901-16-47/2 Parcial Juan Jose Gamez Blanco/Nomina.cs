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
    public partial class Nomina : Form
    {
        OdbcConnection conn = new OdbcConnection("Dsn=Parcial");
        public Nomina(string user)
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            combo1.llenarse("empleado", "codigo_empleado");
            combo2.llenarse("concepto", "codigo_concepto");
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
        void Insertar()
        {

            conn.Close();
            string query = "INSERT INTO `nominae` (`codigo_nomina`, `fecha_inicial_nomina`, `estado`) VALUES('" + txtcod.Text + "','" + dateTimePicker1.Text + "', '1');";

            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
                MessageBox.Show("La nomina se Registro Corectamente");
                llenartbl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("\t Error! \n\n " + ex.ToString());
                conn.Close();
            }
        }
        private void Nomina_Load(object sender, EventArgs e)
        {

        }
        void Insertar2()
        {

            conn.Close();
            string query = "INSERT INTO `nominad` (`codigo_nomina`, `codigo_empleado`, `codigo_concepto`, `estado`) VALUES ('" + txtcodigo.Text + "', '" + combo1.obtener() + "', '" + combo2.obtener() + "', '1');";

            conn.Open();
            OdbcCommand consulta = new OdbcCommand(query, conn);
            try
            {
                consulta.ExecuteNonQuery();
                MessageBox.Show("El consepto se Registro Corectamente");
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
            Insertar();
            txtcod.Text = "";
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                txtcod.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();


            }
            else
            {
                MessageBox.Show("Seleccione un Registro!", "Planilla", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Insertar2();
            txtcod.Text = "";
        }
    }
}
