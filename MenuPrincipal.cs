using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_medidas
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

      
        private void btnCalcinha_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ainda Não Disponivel!");
        }

        private void btnSutia_Click(object sender, EventArgs e)
        {            
            SUTIA sutia = new SUTIA();  
            sutia.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
