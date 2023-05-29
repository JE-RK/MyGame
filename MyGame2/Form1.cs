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
                game.CreatePlayers(textBox1.Text, textBox2.Text);
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
                if (game.Chek == game.player2.Name && game.player2 is Computer computer)
                {
                    computer.Think();
                    richTextBox1.Text += game.player2.Step() + "\n";
                    game.NextStep(game.player2.Step());
                    richTextBox1.Text += "Счет - " + game.Score + "\n";
                    richTextBox1.Text += "Ходит игрок " + game.Chek + "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (game.Chek == label3.Text)
            {
                game.player1.SetStep(int.Parse(domainUpDown1.Text));
                game.NextStep(game.player1.Step());
            }
            else
            {
                int step;
                step = int.Parse(domainUpDown2.Text);
                game.player2.SetStep(step);
                game.NextStep(game.player2.Step());
            }
            richTextBox1.Text = "Счет - " + game.Score + "\n";
            richTextBox1.Text += "Ходит игрок " + game.Chek + "\n";
            if (game.Chek == game.player2.Name && game.GameWithBot)
            {
                richTextBox1.Text += game.player2.Step() + "\n";
                game.NextStep(game.player2.Step());
                richTextBox1.Text += "Счет - " + game.Score + "\n";
                richTextBox1.Text += "Ходит игрок " + game.Chek + "\n";
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
            if (game.GameWithBot)
            {
                button2.Hide();
                button3.Hide();
                textBox2.Enabled = false;
                domainUpDown2.Enabled = false;

            }
            else
            {
                button2.Hide();
                button3.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            form2.Show();
        }
    }
}
