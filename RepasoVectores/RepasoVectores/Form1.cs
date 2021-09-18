using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace RepasoVectores
{
    public partial class Form1 : Form
    {
        //creamos los arrays que se usan en distintos métodos
        static int[] array = new int[50];
        static int[] arraySinReps = new int[50];
        //también el random
        static Random aleatorio = new Random();

        public Form1()
        {
            InitializeComponent();            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = "(Usa el array generado en el Ej 1)";
            textBox3.Text = "(Usa el array generado en el Ej 1)";
            textBox4.Text = "(Usa el array generado en el Ej 1)";
            textBox5.Text = "(Usa el array generado en el Ej 1)";
            textBox6_2.Text = "(Usa el array generado en el Ej 1)";
            textBox7.Text = "(Usa el array generado en el Ej 1)";
            textBox8.Text = "(Usa el array generado en el Ej 1)\r\nInvierte los números repetidos para poder ver bien qué números se repiten";
            textBox9.Text = "Ordena el array antes de mostrarlo para que sea más fácil ver si funciona";
            textBox10.Text = "(Usa el array generado en el Ej 9)";
            textBox11.Text = "(Usa el array generado en el Ej 9)";
            textBox12_2.Text = "(Usa el array generado en el Ej 1)\r\nInvierte los números que han sido cambiados para verlos más fácilmente";
            textBox13_2.Text = "(Usa el array generado en el Ej 1)";
        }

        private void button1_Click(object sender, EventArgs e)
        {                     
            //rellenar el array
            for (int i = 0; i < array.Length; i++) { 
                array[i] = aleatorio.Next(1,100);
            }

            //mostrarlo en el textbox
            String mostrar = String.Join("\r\n", array);

            textBox1.Text = mostrar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            String mostrar = String.Join("\r\n",("Número más bajo: " + array.Min()), ("Número más alto: " + array.Max()));
            textBox2.Text = mostrar;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Join("\r\n", ("Número en la posición 20: " + array[19]),("Número en la posición 30: "+ array[29]));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "La media es: " + array.Average();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] arrayEj5 = array;
            Array.Sort(arrayEj5);
            textBox5.Text= String.Join("\r\n", arrayEj5);

        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals("")) textBox6_2.Text = "Introduce el número a buscar y vuelve a pulsar el botón";

            else {
                int numUsuario = Convert.ToInt32(textBox6.Text);
                int contador = 0;
                for (int i = 0; i < array.Length; i++) {
                    if (numUsuario == array[i]) contador++;
                }
                textBox6_2.Text = String.Join("\r\n", ("Has buscado: " + numUsuario), ("Aparece: " + contador + " veces."));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int[] arrayEj7 = array;
            Array.Reverse(arrayEj7);
            textBox7.Text = String.Join("\r\n", arrayEj7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int[] arrayEj8 = array;
            //array de números que vayan saliendo para no repetir
            ArrayList nums = new ArrayList();

            for (int i = 0; i < arrayEj8.Length; i++) {
                if (!nums.Contains(arrayEj8[i])) {
                    nums.Add(arrayEj8[i]);
                }
                else arrayEj8[i] = -arrayEj8[i];
            }
            textBox8.Text= String.Join("\r\n", arrayEj8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //mismo que antes, creamos un array dinámico para ir guardando los número que ya están para no repetir
            ArrayList nums = new ArrayList();

            for (int i = 0; i < arraySinReps.Length; i++){
                do{
                    arraySinReps[i] = aleatorio.Next(1, 100);                    
                }
                while (nums.Contains(arraySinReps[i]));
                nums.Add(arraySinReps[i]);
            }

            Array.Sort(arraySinReps);
            textBox9.Text = String.Join("\r\n", arraySinReps);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int mayor = 0;
            int menor = 0;
            for (int i = 0; i < arraySinReps.Length; i++) {
                if (arraySinReps[i] <= 25) menor++;
                if (arraySinReps[i] > 25) mayor++;
            }
            textBox10.Text = String.Join("\r\n", ("Menores o iguales a 25: " + menor),("Mayores de 25: " + mayor));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int [] arrayEj11 = arraySinReps;
            Array.Sort(arrayEj11);
            Array.Reverse(arrayEj11);
            textBox11.Text = String.Join("\r\n", arrayEj11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox12.Text.Equals("")) textBox12_2.Text = "Introduce un número y vuelve a pulsar el botón";

            else
            {
                int numUsuario = Convert.ToInt32(textBox12.Text);

                if (!array.Contains(numUsuario))
                {
                    textBox12_2.Text = "Ese número no está en el array";
                }

                else
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (numUsuario == array[i]) {
                            int numAux = 0;
                            do {
                                numAux= aleatorio.Next(1, 100);
                            }
                            while (array.Contains(numAux));
                            array[i] = -numAux;
                        }
                    }
                    textBox12_2.Text = String.Join("\r\n", array);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Equals("")) textBox13_2.Text = "Introduce un número y vuelve a pulsar el botón";
            else
            {
                int numUsuario = Convert.ToInt32(textBox13.Text);
                int mayor = 0;
                int menor = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] <= numUsuario) menor++;
                    if (array[i] > numUsuario) mayor++;
                }
                textBox13_2.Text = String.Join("\r\n", ("Menores o iguales a " + numUsuario +  " : " + menor), ("Mayores de " + numUsuario + " : " + mayor));
            }



            }

    }
}
