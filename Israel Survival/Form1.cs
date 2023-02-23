using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Israel_Survival
{

    public partial class FormJogo : Form
    {

        // VARIAVEIS
        bool paraCima; // será usada para fazer o jogador andar para cima na tela 
        bool paraBaixo; // será usada para fazer o jogador andar para baixo na tela
        bool paraEsquerda; // será usada para fazer o jogador andar para a esquerda na tela
        bool paraDireita; // será usada para fazer o jogador andar para a direita na tela
        string sentido = "cima"; // sentido inicial padrao do jogador e vai indicar a direção dos disparos
        double saudeJogador = 100; // saúde do personagem
        int velocJogador = 10; // velocidade do jogador
        int municao = 10; // armazena a quantidade de flechas do jogador
        int velocZumbi = 3; // armazena a velocidade dos zumbis
        int pontos = 0; // armazena a pontuação do jogador ao decorrer do jogo
        bool gameOver = false; // por padrão é falso e será verdadeiro quando o jogo acabar
        string nomeJogador = "";

        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();

        Random rnd = new Random(); // vai gerar numeros aleatorios que serão usados em metodos

        List<PictureBox> zumbisList = new List<PictureBox>(); //lista para armazenar os zumbis criados
        List<PictureBox> municoesList = new List<PictureBox>(); //lista para armazenar os zumbis criados 

        public FormJogo()
        {

            InitializeComponent();
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (gameOver == true) return; // se o game over for verdadeiro entao nada acontece nesse evento

            // se a tecla A for pressionada o jogador se moverá para a esquerda
            if (e.KeyCode == Keys.A)
            {
                paraEsquerda = true; // direção esquerda para verdadeiro
                sentido = "esquerda"; //muda o sentido para a esquerda
                jogador.Image = Properties.Resources.left; // muda a imagem do jogador para a esquerda

            }

            // se a tecla D for pressionada o jogador se moverá para a direita
            if (e.KeyCode == Keys.D)
            {
                paraDireita = true; // direção direita para verdadeiro
                sentido = "direita"; // muda o sentido para a direita
                jogador.Image = Properties.Resources.right; // muda a imagem do jogador para a direita
            }

            // se a tecla W for pressionada o jogador se moverá para cima
            if (e.KeyCode == Keys.W)
            {
                paraCima = true; // direção pra cima para verdadeiro
                sentido = "cima"; // muda o sentido para cima
                jogador.Image = Properties.Resources.up; // muda a imagem do jogador para cima
            }

            // se a tecla S for pressionada o jogador se moverá para baixo
            if (e.KeyCode == Keys.S)
            {
                paraBaixo = true; // direção pra baixo para verdadeiro
                sentido = "baixo"; // muda o sentido para baixo
                jogador.Image = Properties.Resources.down; //muda a imagem do jogador para baixo
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (gameOver == true) return; //se o game over for verdadeiro entao nada acontece nesse evento

            // quando a tecla A deixa de ser pressionada
            if (e.KeyCode == Keys.A)
            {
                paraEsquerda = false; // direção esquerda para falso
            }

            // quando a tecla D deixa de ser pressionada
            if (e.KeyCode == Keys.D)
            {
                paraDireita = false; // direção direita para falso
            }
            // quando a tecla W deixa de ser pressionada
            if (e.KeyCode == Keys.W)
            {
                paraCima = false; // direção pra cima para falso
            }
            // quando a tecla S deixa de ser pressionada
            if (e.KeyCode == Keys.S)
            {
                paraBaixo = false; // direção pra baixo para falso
            }

            //quando a BARRA DE ESPAÇO deixa de ser pressionada
            if (e.KeyCode == Keys.Space && municao > 0) //aqui estamos verificando se a BARRA DE ESPAÇO não está pressionada e se Flechas são maior que 0

            {
                municao--; // reduz 1 da quantidade de flechas atual
                disparaFlecha(sentido); // chama a função shoot com a  variavel sentido como parâmetro;
                                        //O sentido vai indicar qual caminho o disparo vai seguir

                if (municao < 1) // se a quantidade de flechas for menor que 1
                {
                    Recarrega(); // chama a função criarFlechas
                }
            }
        }
        private void gameEngine(object sender, EventArgs e)
        {
            if (saudeJogador > 1) // se a saúde do jogador é maior que 1
            {
                prbSaude.Value = Convert.ToInt32(saudeJogador); // convert o status da barra de saude para um numero inteiro
            }
            else
            {
                var form3 = new FrmRank();
                // se a saude do jogador é menor que 1
                jogador.Image = Properties.Resources.dead; // mostra a imagem do jogador morto
                TempoJogo.Stop(); // para o timer
                gameOver = true; // muda o game over para verdadeiro
                form3.EscreverRank(GetNomeJogador(), Convert.ToString(pontos));
                tbcMenu.Visible = true; //mostrar o tabControl com as opções de reiniciar, sair e ver a pontuação
                tbcMenu.BringToFront(); //traz a visualização para frente dos outros objetos
                lblPontuacao.Text = "PONTOS: " + pontos;
            }

            lblMunicao.Text = "Flechas: " + municao; // mostra a quantidade de municao no lblMunicao
            lblPontos.Text = "Pontos: " + pontos; // mostra o total de mortes na pontuação

            // se a saude do jogador é menor que 20
            if (saudeJogador < 20)
            {
                prbSaude.ForeColor = System.Drawing.Color.Red; // muda a cor da barra de saude para vermelho 
            }

            if (paraEsquerda == true && jogador.Left > 0)
            {
                jogador.Left -= velocJogador;
                // se mover para esquerda for verdadeiro e estiver a 1 pixel do zumbi  
                // entao move o jogador para a esquerda
            }
            if (paraDireita && jogador.Left + jogador.Width < 930)
            {
                jogador.Left += velocJogador;
                // se mover para direita for verdadeiro e o jogador para a esquerda + a largura do jogador for menor que 930 pixels
                // entao move o jogador para a direita
            }
            if (paraCima && jogador.Top > 60)
            {
                jogador.Top -= velocJogador;
                // se mover para cima for verdadeiro e o jogador estiver mais de 60 pixels da parte superior
                // entao move o jogador para a cima
            }

            if (paraBaixo && jogador.Top + jogador.Height < 700)
            {
                jogador.Top += velocJogador;
                // se mover para baixo for verdadeiro e a parte superior do jogador + a altura do jogador for menor que 700 pixels
                // entao move o jogador para baixo
            }

            // roda o foreach para cada verificação no loop abaixo
            // X é uma variavel do tipo Control e vai passar por todas as verificações neste loop
            foreach (Control x in this.Controls)
            {
                // se X é uma pictureBox e se X tem a tag "municao"

                if (x is PictureBox && x.Tag == "municao")
                {
                    // verifica se X está colidindo com a pictureBox jogador

                    if (((PictureBox)x).Bounds.IntersectsWith(jogador.Bounds))
                    {
                        // após o jogador colidir com pictureBox X(municao) ele pega a municao

                        this.Controls.Remove(((PictureBox)x)); // remove a pictureBox municao

                        ((PictureBox)x).Dispose(); // discarta a pictureBox do programa
                        municao += 5; // adiciona 5 unidades de municao 
                    }
                }

                //se a municao acertar uma das 4 bordas do jogo 
                // se X é uma pictureBox e X tem a tag de "Flecha"

                if (x is PictureBox && x.Tag == "flecha")
                {
                    // se a flecha esta a menos de um pixel da borda da esquerda
                    // se a flecha esta mais de 930 pixels para a direita
                    // se a flecha esta a 10 pixels da borda do topo
                    // se a flecha esta a mais de 700 pixels para baixo

                    if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 930 || ((PictureBox)x).Top < 10 || ((PictureBox)x).Top > 700)
                    {
                        this.Controls.Remove(((PictureBox)x)); // remove a flecha da tela
                        ((PictureBox)x).Dispose(); // discarta a flecha do programa
                    }
                }

                // verifica se o zumbi está colidindo com o zumbi

                if (x is PictureBox && x.Tag == "zumbi")
                {

                    // a declaração abaixo verifica se os limites de contato entre o jogador e o zumbi foi ultrapassado 

                    if (((PictureBox)x).Bounds.IntersectsWith(jogador.Bounds))
                    {
                        saudeJogador -= 1; // se o zumbi acertar o nogador entao ocorre um drecremento de 1 na saude do jogador
                    }

                    //move o zumbi em direção a pictureBox jogador

                    if (((PictureBox)x).Left > jogador.Left)
                    {
                        ((PictureBox)x).Left -= velocZumbi; // move zumbie na direção à esquerda do jogador
                        ((PictureBox)x).Image = Properties.Resources.zleft; // muda a imagem do zumbi para a esquerda
                    }

                    if (((PictureBox)x).Top > jogador.Top)
                    {
                        ((PictureBox)x).Top -= velocZumbi; // move o zumbi para cima em direção ao jogador
                        ((PictureBox)x).Image = Properties.Resources.zup; // muda a imagem do zumbi para cima
                    }
                    if (((PictureBox)x).Left < jogador.Left)
                    {
                        ((PictureBox)x).Left += velocZumbi; // move zumbie na direção à direita do jogador
                        ((PictureBox)x).Image = Properties.Resources.zright; // change the image to the right image
                    }
                    if (((PictureBox)x).Top < jogador.Top)
                    {
                        ((PictureBox)x).Top += velocZumbi; // move o zumbi para baixo em direção ao jogador
                        ((PictureBox)x).Image = Properties.Resources.zdown; // change the image to the down zombie
                    }
                }

                // abaixo um segundo loop, que serve para diferenciar o zumbi da flecha e verificar se colidiram entre si
                foreach (Control j in this.Controls)
                {
                    // primeiro diferenciamos o zumbi da flecha utilizando a tag que foi atribuida a eles

                    if (j is PictureBox && j.Tag == "flecha" && x is PictureBox && x.Tag == "zumbi")
                    {
                        // verifica se a flecha colidiu com o zumbi
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            pontos++; // aumenta mais 1 na pontuação de mortes
                            this.Controls.Remove(j); // remove a flecha da tela
                            j.Dispose(); // tira a flecha do programa
                            this.Controls.Remove(x); // remove o zumbi da tela
                            x.Dispose(); // tira ao zumbi do programa
                            criaZumbi(); // chama a função criaZumbi para adicionar outro zumbi ao jogo
                        }
                    }
                }
            }
        }

        private void Recarrega()
        {
            // essa função faz a imagem da muniçao aparecer

            PictureBox municao = new PictureBox(); // instanciando uma nova pictureBox
            municao.Image = Properties.Resources.ammo_Image; // atribui a imagem da municao para a pictureBox
            municao.SizeMode = PictureBoxSizeMode.AutoSize; // define o mode size da picturaBox para "Auto Size"
            municao.Left = rnd.Next(10, 890); // gera um numero entre 10 e 890 e atribui para a coordenada horizontal
            municao.Top = rnd.Next(50, 600); // gera um numero entre 50 e 600 e atribui para a coordenada vertical
            municao.Tag = "municao"; // define a tag "municao" para a pictureBox
            municoesList.Add(municao);
            this.Controls.Add(municao); // adiciona a pictureBox de municao na tela
            municao.BringToFront(); // traz a visualização da pictureBox municao para frente
            jogador.BringToFront(); // traz a visualização do jogador para frente, para sobrepor a pictureBox municao
        }

        private void disparaFlecha(string direcao)
        {
            //essa funçao cria as flechas no jogo 

            flecha disparo = new flecha(); // instancia um objeto disparo da classe flecha
            disparo.direcao = direcao; // atribui a direção para a flecha
            disparo.flechaHorizontal = jogador.Left + (jogador.Width / 2); // posiciona a flecha no eixo horizontal do jogador 
            disparo.flechaVertical = jogador.Top + (jogador.Height / 2); // posiciona a flecha no eixo vertical do jogador
            disparo.criaFlecha(this); // chama a função criaFlecha da classe Flecha passando o form como parametro
        }

        private void criaZumbi()
        {
            //quando essa função é chamada vai criar os zumbis no jogo

            PictureBox zumbi = new PictureBox(); // instancia uma nova pictureBox chamada zumbi 
            zumbi.Tag = "zumbi"; // adiciona a tag "zumbi" na pictureBox criada
            zumbi.Image = Properties.Resources.zdown; // define que por padrão o zumbi vai ser criado na direção para baixo
            zumbi.Left = rnd.Next(0, 900); // gera um numero entre 0 e 900 e atribui para a coordenada horizontal 
            zumbi.Top = rnd.Next(0, 800); // gera um numero entre 0 e 900 e atribui para a coordenada vertical
            zumbi.SizeMode = PictureBoxSizeMode.AutoSize; // define o mode size da pictureBox para "AutoSize"
            zumbisList.Add(zumbi); //adiciona a pictureBox zumbi na lista
            this.Controls.Add(zumbi); // adiciona a pictureBox zumbi na tela
            jogador.BringToFront(); // traz a visualização do zumbi para frente
        }

        private void Reiniciar()
        {
            gameOver = false; //volta o game over para falso para o jogo rodar novamente
            tbcMenu.Visible = false; //deixa o tabControl não visivel novamente
            jogador.Image = Properties.Resources.up; //posiciona o jogador na direção padrão


            foreach (PictureBox i in zumbisList)
            {
                this.Controls.Remove(i); //remove cada zumbi que está na lista do form
            }

            zumbisList.Clear(); //Limpa a lista de zumbis 

            //cria a quantidade padrão inicial de zumbis
            for (int i = 0; i < 3; i++)
            {
                criaZumbi();
            }

            foreach (PictureBox i in municoesList)
            {
                this.Controls.Remove(i); // limpa a picture box que esta sendo exibida no form
            }

            municoesList.Clear(); //limpa a lista de municoes

            //retorna os valores abaixo para o padrão
            paraCima = false;
            paraBaixo = false;
            paraEsquerda = false;
            paraDireita = false;

            saudeJogador = 100;
            pontos = 0;
            municao = 10;

            TempoJogo.Start(); //reinicia a contagem e começa o evento Tick, onde ocorre a mecanica do jogo
            this.Focus(); //retornar o foco para o Form
        }

        public void SetNomeJogador(string nomeJogador)
        {
            this.nomeJogador = nomeJogador;
        }

        public string GetNomeJogador()
        {
            return this.nomeJogador;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReiniciar_Click_1(object sender, EventArgs e)
        {
            Reiniciar();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRank_Click(object sender, EventArgs e)
        {
            
            var form3 = new FrmRank();
            form3.Closed += (s, args) => this.Close();
            form3.CarregarRanking();
            form3.Show();
        }
    }
}
