using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Adivina_el_numero
{

   
    public partial class fr_inicio : Form
    {

        string num_user = "";// Carga el numero que el usuario intenta adivinar
        string numerosecreto = "";// Carga el numero secreo asignado dinamicamente
        int ronda = 1;//Numero de ronda
        int puntos = 0;//Acumulado de puntos
        int turno = 4;//Turno actual
        int verx = 0;// Carga el numero secreto para su visualizacion
        int continuar = 0;

        public fr_inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();//Cierra el formulario actual0
        }

        private void fr_inicio_Load(object sender, EventArgs e)
        {
            //Cargas labels de puntaje, ronda y marcador y activa el boton de reiniciar
            lbl_ronda.Text = "Ronda: " + ronda;
            lbl_puntos.Text = "Puntos: " + puntos;
            lbl_turno.Text = "Turno : " + turno;
            bt_reiniciar.Enabled = false;
            lbl_x.Visible = false;
        }



        private void bt_1_Click(object sender, EventArgs e)
        {
            Imprimir_numero("1");
        }

        private void bt_2_Click(object sender, EventArgs e)
        {
            Imprimir_numero("2");
        }

        private void bt_3_Click(object sender, EventArgs e)
        {
            Imprimir_numero("3");
        }

        private void bt_4_Click(object sender, EventArgs e)
        {
            Imprimir_numero("4");
        }

        private void bt_5_Click(object sender, EventArgs e)
        {
            Imprimir_numero("5");
        }

        private void bt_6_Click(object sender, EventArgs e)
        {
            Imprimir_numero("6");
        }

        private void bt_7_Click(object sender, EventArgs e)
        {
            Imprimir_numero("7");
        }

        private void bt_8_Click(object sender, EventArgs e)
        {
            Imprimir_numero("8");
        }

        private void bt_9_Click(object sender, EventArgs e)
        {
            Imprimir_numero("9");
        }

        private void bt_0_Click(object sender, EventArgs e)
        {
            Imprimir_numero("0");
        }




        /// <summary>
        /// Se recibe el numero ingresado por el usuario y lo ingresa a la paatalla
        /// </summary>
        /// <param name="numero">Numero ingresado por teclado</param>
        private void Imprimir_numero(string numero)
        {
            num_user = num_user + numero;
            lbl_numero.Text = num_user;
        }

        /// <summary>
        /// Genera el numero secreto aleatorio
        /// </summary>
        private void Generar_x()
        {
            //Funcion para generar el numero secreto aleatorio
            Random rnd = new Random();
            int num_x = rnd.Next(1, 101);
            numerosecreto = Convert.ToString(num_x);
            bt_inicio.Visible = false;//Habilita el boton de inicio
            gb_teclado.Enabled = true;//Habilita el teclado
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Muestra un mensaje y habilita los boton de reiniciar
            lbl_notas.AutoSize = true;
            lbl_notas.Text = "Debes ingresar un numero entre 1 y 100\n y luego hacer clik en enviar, el sistema\n  te indicara si acertastes(Ver ayuda)";
            bt_continuar.Visible = true;
            bt_reiniciar.Enabled = true;
            lbl_x.Visible = false;
        }

        private void txt_numero_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_enviar_Click(object sender, EventArgs e)
        {
            if (lbl_numero.Text == "")// Valida que el usuario haiga ingresado el numero
            {
                lbl_notas.Text = "No has ingresado el numero!!";
            }
            else
            {
                //Llama la funcion para evaluar el numero enviado, se envia tanto el numero secreto y el numero ingresado por el usuario
                EvaluarNumero(Convert.ToInt32(num_user), Convert.ToInt32(numerosecreto));
                lbl_ronda.Text = "Ronda: " + ronda;
            }


        }

        private void EvaluarNumero(int num_usurio, int numerox)
        {
            lbl_turno.Text = "Turno: " + turno;// Muestra el numero de tuno en pantalla
            //Oculta los pones de pista a los usuarios, en caso de que esten habilitados
            bt_alerta1.Visible = false;
            bt_alerta2.Visible = false;
            bt_alerta3.Visible = false;
            int diferencia = 0;
            //Se valida la diferencia de numeros entre el numero secreto y el ingresado por el usuario
            if (num_usurio > numerox)
            {
                diferencia = num_usurio - numerox;
            }
            else
            {
                diferencia = numerox - num_usurio;
            }

            //lbl_notas.Text = "Diferencia: " + diferencia + " numero secreto: " + numerosecreto;
            if (Convert.ToInt32(num_usurio) > 100)
            {
                //Se valida que el numero ingresado sea entre 0 y 100
                lbl_notas.Text = "Numero fuera de rango(Rango:1-100)";
                num_user = "";
                lbl_numero.Text = "";
            }
            //En caso de que la diferencia sea mayor a 50 numeros
            if (diferencia > 50 & diferencia < 101)
            {
                lbl_notas.Text = "Numero Ingresado: "+num_user+" \n¡Muy lejos! \n Analiza tu jugada. Intentalo de nuevo.";
                num_user = "";
                lbl_numero.Text = "";
                // Se habilitan los botones para generar la pista al usuario
                bt_alerta1.Visible = true;
                bt_alerta1.BackColor = Color.Red;
                bt_alerta1.ForeColor = Color.Red;
                // Se valida el turno  y la proximidad para asignar los puntos
                if (turno == 4)
                {
                    puntos = puntos + 30;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
               if (turno == 3)
                {
                    puntos = puntos + 20;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
                    if (turno == 2)
                {
                    puntos = puntos - 10;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
                    if (turno == 1)
                {
                    puntos = puntos - 5;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }

            }
            //Se validad que la diferencia sea entre 25 y 50 numeros con respecto al numero secreto
            if (diferencia < 51 & diferencia > 10)
            {
                lbl_notas.Text = "Numero Ingresado: "+num_user+" \n¡Medianamente cerca!\n Tus posibibilidades de acierto han subido.";
                num_user = "";
                lbl_numero.Text = "";
                // Se habilitan los botones para generar la pista al usuario
                bt_alerta1.Visible = true;
                bt_alerta2.Visible = true;
                bt_alerta1.BackColor = Color.Yellow;
                bt_alerta2.BackColor = Color.Yellow;
                bt_alerta1.ForeColor = Color.Yellow;
                bt_alerta2.ForeColor = Color.Yellow;
                // Se valida el turno  y la proximidad para asignar los puntos
                if (turno == 4)
                {
                    puntos = puntos + 65;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
               if (turno == 3)
                {
                    puntos = puntos + 60;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
                    if (turno == 2)
                {
                    puntos = puntos + 50;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
                    if (turno == 1)
                {
                    puntos = puntos + 40;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
            }
            //Se valida que el rango de proximida sea menor a 10 en cualquier sentido
            if (diferencia < 11)
            {
                lbl_notas.Text = "Numero Ingresado: "+num_user+" \n¡Estas muy cerca!";
                num_user = "";
                lbl_numero.Text = "";
                // Se habilitan los botones para generar la pista al usuario
                bt_alerta1.Visible = true;
                bt_alerta2.Visible = true;
                bt_alerta3.Visible = true;
                bt_alerta1.BackColor = Color.Green;
                bt_alerta2.BackColor = Color.Green;
                bt_alerta3.BackColor = Color.Green;
                bt_alerta1.ForeColor = Color.Green;
                bt_alerta2.ForeColor = Color.Green;
                bt_alerta3.ForeColor = Color.Green;
                // Se valida el turno  y la proximidad para asignar los puntos
                if (turno == 4)
                {
                    puntos = puntos + 90;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
               if (turno == 3)
                {
                    puntos = puntos + 80;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
                    if (turno == 2)
                {
                    puntos = puntos + 75;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
                    if (turno == 1)
                {
                    puntos = puntos + 60;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
            }
            // Se valida si el jugador ha acertado el numero
            if (num_usurio == numerox)
            {
                // Se imprime un mensaje en pantalla junto con lo puntos
                lbl_notas.Text = "Felicidades a adivinado el numero secreto (" + numerox + ").\n Has ganado 150 puntos adicionales.";
                verx = numerox;
                lbl_x.Text = Convert.ToString(verx);
                Generar_x();
                //Se reinician las vistas de puntos y turnos
                puntos = puntos + 150;// Se le asigna los puntos correspondientes por haber acertado
                turno = 1;
                continuar = 1;
                // Se deshabilitan los botones para generar la pista al usuario
                bt_alerta1.Visible = false;
                bt_alerta2.Visible = false;
                bt_alerta3.Visible = false;
                bt_continuar.Visible = true;
                num_user = "";
                lbl_numero.Text = num_user;
                // Se valida el turno  y la proximidad para asignar los puntos
                if (turno == 4)
                {
                    puntos = puntos + 100;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
               if (turno == 3)
                {
                    puntos = puntos + 95;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
                    if (turno == 2)
                {
                    puntos = puntos + 85;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
                    if (turno == 1)
                {
                    puntos = puntos + 70;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }

            }

            turno = turno - 1;// Se descuenta el turno jugado
            lbl_turno.Text = "Turno: " + turno;
            // Se valida la cantida de turnos jugados para, avanzar a la siguiente ronda
            if (turno == 0)
            {
                ronda = ronda + 1;// Se aumneta en uno la ronda
                turno = 4;
                lbl_turno.Text = "Turno: " + turno;
            }

            if (ronda > 5 & turno == 4)
            {
                // Se reinician las vistas de pntos, ronda y turno y se imprime uin mesaje de salida y el puntaje
                continuar = 2;
                bt_continuar.Visible = true;
                lbl_notas.Text = "Has llegado al final del juego.\n Puntaje final:" + puntos;
                lbl_turno.Text = "Turno: 0 ";
                lbl_ronda.Text = "ronda: 0 ";
                lbl_puntos.Text = "Puntos: 0 ";
                //Se deshabilitan los botones de pista y el teclado
                gb_teclado.Enabled = false;
                bt_alerta1.Visible = false;
                bt_alerta2.Visible = false;
                bt_alerta3.Visible = false;
                ronda = 0;
            }
        }




        private void tm_pausa_Tick(object sender, EventArgs e)
        {

        }

        
        private void bt_reiniciar_Click(object sender, EventArgs e)
        {
            Generar_x();// Se llama la funcion  para generar un nuevo numero

            gb_teclado.Enabled = true;// Se habilita el teclado
            // Se reinian las vistas, se imprimen y se deshabilitan los botones de pista
            puntos = 0;
            turno = 4;
            ronda = 1;
            lbl_ronda.Text = "Ronda: " + ronda;
            lbl_puntos.Text = "Puntos: " + puntos;
            lbl_turno.Text = "Turno : " + turno;
            lbl_notas.Text = "";
            bt_alerta1.Visible = false;
            bt_alerta2.Visible = false;
            bt_alerta3.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bt_alerta2_Click(object sender, EventArgs e)
        {

        }

        private void bt_alerta3_Click(object sender, EventArgs e)
        {

        }

        private void bt_alerta1_Click(object sender, EventArgs e)
        {

        }

        private void bt_continuar_Click(object sender, EventArgs e)
        {
            // Se validan las diferntes funciones del born continuar
            if (continuar == 0)
            {
                lbl_notas.Text = "";// Se limpia la pantalla
                Generar_x();// Se llama la funcion para generar un numero aleatorio
                continuar = 0;
            }
            else if (continuar == 1)
            {
                // Se limpia la pantalla
                lbl_x.Text = "X";
                lbl_notas.Text = "";
            }
            else if (continuar == 2)
            {
                // Se limpia la pantalla
                lbl_notas.Text = "";
            }

            bt_continuar.Visible = false;// Se oculta el boton de continuar

        }

        private void lbl_ronda_Click(object sender, EventArgs e)
        {

        }

        private void bt_ayuda_Click(object sender, EventArgs e)
        {// Se invoca el formulario de ayuda
            frm_ayuda frm_Ayuda = new frm_ayuda();
            frm_Ayuda.Show();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {


        }
    }
}
