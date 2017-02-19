using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using info.lundin.math;
using System.Text.RegularExpressions;
namespace Newton_Windows_Forms_Application1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string inicial;
            string expresion;
            string derivada;
            int iteraciones;
            double tolerancia ;

            try
            {
                inicial = this.textBox1.Text;
                expresion = this.textBox2.Text;
                derivada = this.textBox3.Text;
                iteraciones = Convert.ToInt32(this.textBox5.Text);
                tolerancia = Convert.ToDouble(this.textBox6.Text);                
            }
            catch (FormatException)
            {
                System.Windows.Forms.MessageBox.Show(this, "Format Error", "Advertencia", MessageBoxButtons.OK);
                inicial = "0.0";
                expresion = "x^2";
                derivada = "2x";
                iteraciones = 0;
                tolerancia = 0;
            }
            ExpressionParser parse = new ExpressionParser();
            double valor_inicial = parse.Parse(inicial);

            Newton newton= new Newton();
            newton.set_punto_inicio(Math.Round(valor_inicial,7));

            string expresion1 = Regex.Replace(expresion,"e","Euler");
            string expresion2 = Regex.Replace(derivada,"e","Euler");
            newton.set_expresion(expresion1);
            newton.set_derivada(expresion2);
            newton.set_iteraciones(iteraciones);
            newton.set_tolerancia(tolerancia);

            double resultado = newton.Solucion(this.dataGridView1);
            this.textBox4.Text = resultado.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }
    }
}
