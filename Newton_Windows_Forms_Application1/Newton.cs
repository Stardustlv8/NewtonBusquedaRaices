using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using info.lundin.math;

namespace Newton_Windows_Forms_Application1
{
    class Newton
    {
        private double inicio;
        private string expresion;
        private string derivada;
        private int iteraciones;
        private double tolerancia;
        public Newton()
        {

        }
        public Newton(double inicio,string expresion,string derivada,int iteraciones,double tolerancia)
        {
            this.inicio = inicio;
            this.expresion = expresion;
            this.derivada = derivada;
            this.iteraciones = iteraciones;
            this.tolerancia = tolerancia;
        }

        public void set_punto_inicio(double inicio)
        {
            this.inicio = inicio;
        }
        public void set_expresion(string expresion)
        {
            this.expresion = expresion;
        }
        public void set_derivada(string derivada)
        {
            this.derivada = derivada;
        }
        public void set_iteraciones(int iteraciones)
        {
            this.iteraciones = iteraciones;
        }
        public void set_tolerancia(double tolerancia)
        {
            this.tolerancia = tolerancia;
        }

        public double Solucion(System.Windows.Forms.DataGridView data)
        {
            double x=inicio;
            int i = 1;
            double fx;
            double dfx;
            double ax;
            
            do
            {
                fx = fun(x);
                dfx = Dfun(x);
                ax = x;
                x = Math.Round(x - (fx / dfx),7);
                data.Rows.Add(i, ax, fx, dfx, x);
                i++;
            } while (Math.Abs(fx) > this.tolerancia && i < this.iteraciones);
            return x;
        }

        private double fun(double x)
        {
            ExpressionParser evaluador = new ExpressionParser();
            evaluador.Values.Add("x",x);
            double resultado = evaluador.Parse(this.expresion);
            return resultado;
        }

        private double Dfun(double x)
        {
            ExpressionParser evaluador = new ExpressionParser();
            evaluador.Values.Add("x", x);
            double resultado = evaluador.Parse(this.derivada);
            return resultado;
        }

    }
}
