using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Israel_Survival
{
    internal class flecha
    {
        public string direcao; // armazena a direção
        public int velocFlecha = 20; // vai armazenar a velocidade da flecha 
        PictureBox Flecha = new PictureBox(); // instancia uma pictureBox com o nome de flecha
        Timer tm = new Timer(); // cria o temporizador 

        public int flechaHorizontal; // vai armazenar a coordenada horizontal
        public int flechaVertical; // vai armazenar a coordenada vertical


        public void criaFlecha(Form form)
        {
            // essa funçaõ vai adicionara a flecha no jogo que necessita ser chamado pela classe principal

            Flecha.BackColor = System.Drawing.Color.Brown; // define a cor da flecha
            Flecha.Size = new Size(5, 5);
            Flecha.Tag = "flecha"; // define a tag "flecha" para a pictureBox flecha
            Flecha.Left = flechaHorizontal; // define a coordenada horizontal 
            Flecha.Top = flechaVertical; // define a coordenada vertical
            Flecha.BringToFront(); // traz a visualização da flecha para frente dos outros objetos
            form.Controls.Add(Flecha); // adiciona a flecha na tela

            tm.Interval = velocFlecha; // define o intervalo de tempo de velocidade
            tm.Tick += new EventHandler(tm_Tick); // atribui o temporizador com o evento Tick
            tm.Start(); // inicia o temporizador
        }

        public void tm_Tick(object sender, EventArgs e)
        {
            // se a direção for igual a esquerda
            if (direcao == "esquerda")
            {
                Flecha.Size = new Size(25, 5);
                Flecha.Left -= velocFlecha; // move a flecha para a esquerda dna tela
            }
            // se a direção for igual a direita
            if (direcao == "direita")
            {
                Flecha.Size = new Size(25, 5);
                Flecha.Left += velocFlecha; //  move a flecha para a direita na tela
            }
            // se a direção for igual a cima
            if (direcao == "cima")
            {

                Flecha.Size = new Size(5, 25);
                Flecha.Top -= velocFlecha; //  move a flecha para cima na tela
            }
            // se a direção for igual a baixo
            if (direcao == "baixo")
            {
                Flecha.Size = new Size(5, 25);
                Flecha.Top += velocFlecha; //  move a flecha para baixo na tela
            }

            // se a flecha está a menos de 16 pixels da borda a esquerda OU
            // se a flecha está a mais de 860 pixels da borda adireita OU
            // se a flecha esta a 10 pixels da borda do topo OU
            // se a flecha está a 616 pixels da bordo do fundo
            // SE QUALQUER UMA DESSAS CONDIÇÕES FOR VERDADEIRO, O COMANDO ABAIXO SERÁ EXECUTADO
            if (Flecha.Left < 16 || Flecha.Left > 860 || Flecha.Top < 10 || Flecha.Top > 616)
            {
                tm.Stop(); // para de contar o tempo no temporizador
                tm.Dispose(); // descarta o evento de tempo e a componente timer do programa 
                Flecha.Dispose(); // descarta a flecha 
                tm = null; // anula o objeto temporizador
                Flecha = null; // anula o objeto flecha
            }
        }
    }
}
