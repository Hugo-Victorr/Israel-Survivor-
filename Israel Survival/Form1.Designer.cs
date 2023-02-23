namespace Israel_Survival
{
    partial class FormJogo
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMunicao = new System.Windows.Forms.Label();
            this.lblPontos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prbSaude = new System.Windows.Forms.ProgressBar();
            this.TempoJogo = new System.Windows.Forms.Timer(this.components);
            this.Zombie3 = new System.Windows.Forms.PictureBox();
            this.Zombie2 = new System.Windows.Forms.PictureBox();
            this.Zombie1 = new System.Windows.Forms.PictureBox();
            this.jogador = new System.Windows.Forms.PictureBox();
            this.tbcMenu = new System.Windows.Forms.TabControl();
            this.tabMenu = new System.Windows.Forms.TabPage();
            this.btnRank = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.lblPontuacao = new System.Windows.Forms.Label();
            this.lblGameOver = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Zombie3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zombie2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zombie1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jogador)).BeginInit();
            this.tbcMenu.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMunicao
            // 
            this.lblMunicao.AutoSize = true;
            this.lblMunicao.BackColor = System.Drawing.Color.Transparent;
            this.lblMunicao.Font = new System.Drawing.Font("Old English Text MT", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMunicao.ForeColor = System.Drawing.Color.Tan;
            this.lblMunicao.Location = new System.Drawing.Point(10, 18);
            this.lblMunicao.Name = "lblMunicao";
            this.lblMunicao.Size = new System.Drawing.Size(120, 28);
            this.lblMunicao.TabIndex = 0;
            this.lblMunicao.Text = "Flechas: 0";
            // 
            // lblPontos
            // 
            this.lblPontos.AutoSize = true;
            this.lblPontos.BackColor = System.Drawing.Color.Transparent;
            this.lblPontos.Font = new System.Drawing.Font("Old English Text MT", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontos.ForeColor = System.Drawing.Color.Tan;
            this.lblPontos.Location = new System.Drawing.Point(397, 18);
            this.lblPontos.Name = "lblPontos";
            this.lblPontos.Size = new System.Drawing.Size(112, 28);
            this.lblPontos.TabIndex = 1;
            this.lblPontos.Text = "Pontos: 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Old English Text MT", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Tan;
            this.label3.Location = new System.Drawing.Point(674, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Saúde:";
            // 
            // prbSaude
            // 
            this.prbSaude.BackColor = System.Drawing.Color.Red;
            this.prbSaude.ForeColor = System.Drawing.Color.Red;
            this.prbSaude.Location = new System.Drawing.Point(756, 19);
            this.prbSaude.Name = "prbSaude";
            this.prbSaude.Size = new System.Drawing.Size(156, 23);
            this.prbSaude.TabIndex = 3;
            this.prbSaude.Value = 100;
            // 
            // TempoJogo
            // 
            this.TempoJogo.Enabled = true;
            this.TempoJogo.Interval = 20;
            this.TempoJogo.Tick += new System.EventHandler(this.gameEngine);
            // 
            // Zombie3
            // 
            this.Zombie3.BackColor = System.Drawing.Color.Transparent;
            this.Zombie3.Image = global::Israel_Survival.Properties.Resources.zup;
            this.Zombie3.Location = new System.Drawing.Point(430, 570);
            this.Zombie3.Margin = new System.Windows.Forms.Padding(2);
            this.Zombie3.Name = "Zombie3";
            this.Zombie3.Size = new System.Drawing.Size(71, 71);
            this.Zombie3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Zombie3.TabIndex = 7;
            this.Zombie3.TabStop = false;
            this.Zombie3.Tag = "zumbi";
            // 
            // Zombie2
            // 
            this.Zombie2.BackColor = System.Drawing.Color.Transparent;
            this.Zombie2.Image = global::Israel_Survival.Properties.Resources.zdown;
            this.Zombie2.Location = new System.Drawing.Point(709, 285);
            this.Zombie2.Margin = new System.Windows.Forms.Padding(2);
            this.Zombie2.Name = "Zombie2";
            this.Zombie2.Size = new System.Drawing.Size(71, 71);
            this.Zombie2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Zombie2.TabIndex = 6;
            this.Zombie2.TabStop = false;
            this.Zombie2.Tag = "zumbi";
            // 
            // Zombie1
            // 
            this.Zombie1.BackColor = System.Drawing.Color.Transparent;
            this.Zombie1.Image = global::Israel_Survival.Properties.Resources.zdown;
            this.Zombie1.Location = new System.Drawing.Point(74, 285);
            this.Zombie1.Margin = new System.Windows.Forms.Padding(2);
            this.Zombie1.Name = "Zombie1";
            this.Zombie1.Size = new System.Drawing.Size(71, 71);
            this.Zombie1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Zombie1.TabIndex = 5;
            this.Zombie1.TabStop = false;
            this.Zombie1.Tag = "zumbi";
            // 
            // jogador
            // 
            this.jogador.BackColor = System.Drawing.Color.Transparent;
            this.jogador.Image = global::Israel_Survival.Properties.Resources.up;
            this.jogador.Location = new System.Drawing.Point(430, 407);
            this.jogador.Margin = new System.Windows.Forms.Padding(2);
            this.jogador.Name = "jogador";
            this.jogador.Size = new System.Drawing.Size(71, 100);
            this.jogador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.jogador.TabIndex = 4;
            this.jogador.TabStop = false;
            // 
            // tbcMenu
            // 
            this.tbcMenu.Controls.Add(this.tabMenu);
            this.tbcMenu.Location = new System.Drawing.Point(178, 115);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.SelectedIndex = 0;
            this.tbcMenu.Size = new System.Drawing.Size(353, 340);
            this.tbcMenu.TabIndex = 8;
            this.tbcMenu.Visible = false;
            // 
            // tabMenu
            // 
            this.tabMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabMenu.Controls.Add(this.btnRank);
            this.tabMenu.Controls.Add(this.btn);
            this.tabMenu.Controls.Add(this.btnReiniciar);
            this.tabMenu.Controls.Add(this.lblPontuacao);
            this.tabMenu.Controls.Add(this.lblGameOver);
            this.tabMenu.Location = new System.Drawing.Point(4, 22);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tabMenu.Size = new System.Drawing.Size(345, 314);
            this.tabMenu.TabIndex = 0;
            this.tabMenu.Text = "Menu";
            // 
            // btnRank
            // 
            this.btnRank.BackColor = System.Drawing.Color.Tan;
            this.btnRank.Font = new System.Drawing.Font("Old English Text MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRank.Location = new System.Drawing.Point(102, 225);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(169, 38);
            this.btnRank.TabIndex = 4;
            this.btnRank.Text = "Rank";
            this.btnRank.UseVisualStyleBackColor = false;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.Color.Tan;
            this.btn.Font = new System.Drawing.Font("Old English Text MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn.Location = new System.Drawing.Point(102, 270);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(169, 38);
            this.btn.TabIndex = 3;
            this.btn.Text = "Sair";
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.Tan;
            this.btnReiniciar.Font = new System.Drawing.Font("Old English Text MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.Location = new System.Drawing.Point(102, 181);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(169, 38);
            this.btnReiniciar.TabIndex = 2;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click_1);
            // 
            // lblPontuacao
            // 
            this.lblPontuacao.Font = new System.Drawing.Font("Baskerville Old Face", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontuacao.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.lblPontuacao.Location = new System.Drawing.Point(107, 107);
            this.lblPontuacao.Name = "lblPontuacao";
            this.lblPontuacao.Size = new System.Drawing.Size(242, 34);
            this.lblPontuacao.TabIndex = 1;
            this.lblPontuacao.Text = "PONTOS: 0";
            // 
            // lblGameOver
            // 
            this.lblGameOver.Font = new System.Drawing.Font("Baskerville Old Face", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.lblGameOver.Location = new System.Drawing.Point(20, 20);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(319, 67);
            this.lblGameOver.TabIndex = 0;
            this.lblGameOver.Text = "GAME OVER";
            // 
            // FormJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(20)))));
            this.BackgroundImage = global::Israel_Survival.Properties.Resources.mapa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(924, 661);
            this.Controls.Add(this.tbcMenu);
            this.Controls.Add(this.Zombie3);
            this.Controls.Add(this.Zombie2);
            this.Controls.Add(this.Zombie1);
            this.Controls.Add(this.jogador);
            this.Controls.Add(this.prbSaude);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPontos);
            this.Controls.Add(this.lblMunicao);
            this.Name = "FormJogo";
            this.Text = "Israel Survivor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.Zombie3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zombie2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zombie1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jogador)).EndInit();
            this.tbcMenu.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMunicao;
        private System.Windows.Forms.Label lblPontos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar prbSaude;
        private System.Windows.Forms.PictureBox jogador;
        private System.Windows.Forms.Timer TempoJogo;
        private System.Windows.Forms.PictureBox Zombie1;
        private System.Windows.Forms.PictureBox Zombie2;
        private System.Windows.Forms.PictureBox Zombie3;
        private System.Windows.Forms.TabControl tbcMenu;
        private System.Windows.Forms.TabPage tabMenu;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Label lblPontuacao;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Button btnRank;
    }
}

