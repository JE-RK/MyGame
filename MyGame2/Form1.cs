using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLibrary;

namespace MyGame2
{
    public partial class Form1 : Form
    {
        Form2 form2;
        Game game;
        public Form1(Form2 form2, Game game)
        {
            this.form2 = form2;
            this.game = game;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormPlayer p1 = new FormPlayer(textBox1.Text, game);
                FormPlayer p2 = new FormPlayer(textBox2.Text, game);
                p1.StepMethod = RegStep;
                p2.StepMethod = RegStep;
                game.CreatePlayers(p1, p2);
                richTextBox1.Text = "Игроки созданы\n";
                richTextBox1.Text += $"Игрок {game.Chek}  ходит первым\n";
                textBox1.Hide();
                textBox2.Hide();
                label1.Hide();
                label2.Hide();
                label3.Text = textBox1.Text;
                label4.Text = textBox2.Text;
                button1.Hide();
                domainUpDown1.Enabled = true;
                domainUpDown2.Enabled = true;
                button2.Show();
                button3.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int RegStep()
        {
            if (game.Chek == game.player1.Name)
            {
                return int.Parse(domainUpDown1.Text);
            }
            else
            {
                return int.Parse(domainUpDown2.Text);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Счет - " + game.Score + "\n";
            richTextBox1.Text += "Ходит игрок " + game.Chek + "\n";
            if (game.Chek == game.player1.Name)
            {
                game.player1.Step();
            }
            else
            {
                game.player2.Step();
            }
            if (game.EndGame() == true)
            {
                richTextBox1.Text = "Счет - " + game.Score + "\n";
                richTextBox1.Text = "Выиграл - " + game.Last + "\n";
                button2.Hide();
                button3.Hide();
                textBox1.Show();
                textBox2.Show();
                label1.Show();
                label2.Show();
                label3.Text = "";
                label4.Text = "";
                button1.Show();
                domainUpDown1.Enabled = false;
                domainUpDown2.Enabled = false;
                domainUpDown1.Text = "1";
                domainUpDown2.Text = "1";
                game.ResetScore();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            form2.Show();
        }
    }
}
