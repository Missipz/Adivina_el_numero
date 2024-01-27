using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adivina_el_numero
{
    public partial class frm_ayuda : Form
    {
        public frm_ayuda()
        {
            InitializeComponent();
        }

        private void bt_salir_Click(object sender, EventArgs e)
        {
          this.Close();
           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
