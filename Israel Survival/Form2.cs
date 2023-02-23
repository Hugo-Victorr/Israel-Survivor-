using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Israel_Survival
{
    public partial class FormMenu : Form
    {
        
        public FormMenu()
        {
            InitializeComponent();
        }

        
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                var form1 = new FormJogo();
                form1.SetNomeJogador(textBox1.Text);
                form1.Closed += (s, args) => this.Close();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Insira um nome de Jogador valido!!");
            }

          
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {

        }

        private void btnRank_Click(object sender, EventArgs e)
        {
            var form3 = new FrmRank();
            form3.Closed += (s, args) => this.Close();
            form3.CarregarRanking();
            form3.Show();
        }

        private void btnSair2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
