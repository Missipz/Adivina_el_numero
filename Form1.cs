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
        
        string num_user = "";
        string numerosecreto = "";
        int ronda = 1;
        int puntos = 0;
        int turno = 4;
        int verx = 0;
        int continuar = 0;
        
        public fr_inicio()
        {
            

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            this.Close();

        }

        private void fr_inicio_Load(object sender, EventArgs e)
        {
            lbl_ronda.Text = "Ronda: "+ronda;
            lbl_puntos.Text = "Puntos: " + puntos;
            lbl_turno.Text = "Turno : " + turno;
            bt_reiniciar.Enabled = false;
            lbl_x.Visible=false;
        }



        private void bt_1_Click(object sender, EventArgs e)
        {
            Validar_numero("1");
        }

        private void bt_2_Click(object sender, EventArgs e)
        {
            Validar_numero("2");
        }

        private void bt_3_Click(object sender, EventArgs e)
        {
            Validar_numero("3");
        }

        private void bt_4_Click(object sender, EventArgs e)
        {
            Validar_numero("4");
        }

        private void bt_5_Click(object sender, EventArgs e)
        {
            Validar_numero("5");
        }

        private void bt_6_Click(object sender, EventArgs e)
        {
            Validar_numero("6");
        }

        private void bt_7_Click(object sender, EventArgs e)
        {
            Validar_numero("7");
        }

        private void bt_8_Click(object sender, EventArgs e)
        {
            Validar_numero("8");
        }

        private void bt_9_Click(object sender, EventArgs e)
        {
            Validar_numero("9");
        }

        private void bt_0_Click(object sender, EventArgs e)
        {
            Validar_numero("0");
        }




        private void Validar_numero(string numero)
        {
            num_user = num_user + numero;
            lbl_numero.Text = num_user;
        }

        private void Generar_x()
        {
           // lbl_x.Text = "X";
            Random rnd = new Random();
            int num_x = rnd.Next(1, 101);
            numerosecreto = Convert.ToString(num_x);
            bt_inicio.Visible = false;
            gb_teclado.Enabled = true;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbl_notas.AutoSize = true;
            lbl_notas.Text = "Debes ingresar un numero entre 1 y 100\n y luego hacer clik en enviar, el sistema\n  te indicara si acertastes(Ver ayuda)";
            bt_continuar.Visible = true;
            bt_reiniciar.Enabled= true;
            lbl_x.Visible = false;



        }

        private void txt_numero_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bt_enviar_Click(object sender, EventArgs e)
        {
            if (lbl_numero.Text=="")
            {
                lbl_notas.Text = "No has ingresado el numero!!";
            }
            else
            {

                EvaluarNumero(Convert.ToInt32(num_user), Convert.ToInt32(numerosecreto));
               
               // lbl_turno.Text = "Turno: " + turno;
                lbl_ronda.Text = "Ronda: " + ronda;
               
            }
            
           
        }

        private void EvaluarNumero(int num_usurio, int numerox)
        {
            
            lbl_turno.Text = "Turno: " + turno;
           
            bt_alerta1.Visible= false;
            bt_alerta2.Visible= false;
            bt_alerta3.Visible= false;
            int diferencia = 0;
            if (num_usurio>numerox)
            {
                diferencia = num_usurio - numerox;
            }else
            {
                diferencia =  numerox - num_usurio ;
            }
           
            lbl_notas.Text = "Diferencia: "+diferencia+" numero secreto: "+ numerosecreto;
            if (Convert.ToInt32(num_usurio) > 100)
            {
                lbl_notas.Text = "Numero fuera de rango(Rango:1-100)";
                num_user = "";
                lbl_numero.Text = "";
            }

            if (diferencia> 50 & diferencia<101)
            {
                lbl_notas.Text = "¡Muy lejos!";
                num_user = "";
                lbl_numero.Text = "";
                bt_alerta1.Visible = true;
                bt_alerta1.BackColor = Color.Red;
                bt_alerta1.ForeColor = Color.Red;
                
                if (turno == 4)
                {
                    puntos = puntos + 30;
                    lbl_puntos.Text = "Puntos: "+puntos;
                }else
               if (turno == 3)
                {
                    puntos = puntos + 20;
                    lbl_puntos.Text = "Puntos: " + puntos;
                }
                else
                    if (turno == 2) {
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

            if (diferencia < 51 & diferencia>10)
            {
                lbl_notas.Text = "¡Medianamente cerca! "+numerosecreto;
                num_user = "";
                lbl_numero.Text = "";
                bt_alerta1.Visible = true;
                bt_alerta2.Visible= true;
                bt_alerta1.BackColor = Color.Yellow;
                bt_alerta2.BackColor = Color.Yellow;
                bt_alerta1.ForeColor = Color.Yellow;
                bt_alerta2.ForeColor = Color.Yellow;
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

            if (diferencia < 11)
            {
                lbl_notas.Text = "¡Batante cerca!";
                num_user = "";
                lbl_numero.Text = "";
                bt_alerta1.Visible = true;
                bt_alerta2.Visible = true;
                bt_alerta3.Visible = true;
                bt_alerta1.BackColor = Color.Green;
                bt_alerta2.BackColor = Color.Green;
                bt_alerta3.BackColor = Color.Green;
                bt_alerta1.ForeColor = Color.Green;
                bt_alerta2.ForeColor = Color.Green;
                bt_alerta3.ForeColor = Color.Green;
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

            if (num_usurio == numerox)
            {           
                   
                    lbl_notas.Text = "Felicidades a adivinado el numero secreto ("+numerox+").\n Has ganado 150 puntos adicionales.";
                verx = numerox;
                lbl_x.Text = Convert.ToString(verx);
                    Generar_x();
                    puntos=puntos + 150;
                    turno = 1;
                continuar = 1;
                
                bt_alerta1.Visible = false;
                bt_alerta2.Visible = false;
                bt_alerta3.Visible = false;
                bt_continuar.Visible = true;
               
                

               

              //  lbl_x.Text = Convert.ToString(numerosecreto);

                num_user = "";
                lbl_numero.Text = num_user;
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
            
            turno = turno - 1;
            lbl_turno.Text = "Turno: " + turno;
            if (turno == 0)
            {

                ronda = ronda + 1;
                turno = 4;
                lbl_turno.Text = "Turno: " + turno;
              
            }

            if (ronda > 2 & turno==4)
            {
                continuar = 2;
                bt_continuar.Visible=true;
                lbl_notas.Text = "Has llegado al final del juego.\n Puntaje final:" + puntos;
                lbl_turno.Text = "Turno: 0 ";
                lbl_ronda.Text = "ronda: 0 ";
                lbl_puntos.Text = "Puntos: 0 ";
                gb_teclado.Enabled=false;
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
            Generar_x();
            gb_teclado.Enabled = true;
            puntos = 0;
            turno=4;
            ronda=1;
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
            if(continuar== 0) {    
                lbl_notas.Text = "";
                Generar_x();
                continuar = 0;
            }else if(continuar== 1)
            {
                lbl_x.Text = "X";
                lbl_notas.Text = "";
            }else if (continuar== 2)
            {
            lbl_notas.Text= "";
            }

            bt_continuar.Visible = false;

        }

        private void lbl_ronda_Click(object sender, EventArgs e)
        {

        }

        private void bt_ayuda_Click(object sender, EventArgs e)
        {
            frm_ayuda frm_Ayuda= new frm_ayuda();
            frm_Ayuda.Show();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          

        }
    }
}
