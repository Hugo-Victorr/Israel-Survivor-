using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data.SqlClient;

namespace Israel_Survival
{
    public partial class FrmRank : Form
    {
        public FrmRank()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("NOME", 175, HorizontalAlignment .Center);
            listView1.Columns.Add("PONTUAÇÃO", 200, HorizontalAlignment.Center);
        }

        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public String mensagem = "";
        public Label teste = new Label();

        public void CarregarRanking()
        {
 

            try
            {
                //conectar com banco -- conexao
                cmd.Connection = conexao.conectar();

                cmd.CommandText = "select NomeJogador Nome, Pontuacao Pontos from pontuacao order by Pontos DESC";

                SqlDataReader reader = cmd.ExecuteReader();

                listView1.Items.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        Convert.ToString(reader.GetInt32(1)),
                    };

                    var linha_listview = new ListViewItem(row);

                    listView1.Items.Add(linha_listview);

                    //mostrar mensagem de erro ou sucesso --variavel
                }
            }
            catch (SqlException f)
            {
                MessageBox.Show(f.Message);
            }
            finally
            {

            }
        }

        public void EscreverRank(string nomeJogador, string pontos)
        {
            //comando sql - sqlCommand
            cmd.CommandText = "insert into pontuacao (NomeJogador, Pontuacao) values (@nomeJogador, @pontos) ";

            //parametros
            cmd.Parameters.AddWithValue("@nomeJogador", nomeJogador);
            cmd.Parameters.AddWithValue("@pontos", pontos);

            //conectar com o banco de dados
            try
            {
                //conectar com banco -- conexao
                cmd.Connection = conexao.conectar();

                //executar comando de enviar dados para o banco
                cmd.ExecuteNonQuery();

                //desconectar
                conexao.desconectar();

                //mostrar mensagem de erro ou sucesso --variavel
                this.mensagem = "Cadastro com Sucesso";
            }
            catch (SqlException e)
            {
                this.mensagem = "erro ao tentar se conectar com o banco de Dados";
            }
            
        }

        private void FrmRank_Load(object sender, EventArgs e)
        {

            

        }

        private void ltbRank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lwRank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void SetLista(string nome)
        {
            
        }
    }
}
