using System;

namespace ACTIVIDAD_11

{

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=DIEGO-PC ; database=base1 ; integrated security = true");
            conexion.Open();
            MessageBox.Show("seleccio base de datos PAGOS");
            conexion.Close();
            MessageBox.Show("Se cerró la conexión.");
        }
    }
}

}