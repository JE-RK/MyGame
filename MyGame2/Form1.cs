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
        public Form1()
        {
            InitializeComponent();
        }
        Game game = new Game();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                game.CreatePlayers(textBox1.Text, textBox2.Text);
                richTextBox1.Text = "Игроки созданы\n";
                richTextBox1.Text += $"Игрок {game.FirstMove()}  ходит первым";
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
            catch (Exception)
            {
                MessageBox.Show("Неверно введены имена.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (game.chek == game.player1.name)
            {
                richTextBox1.Text = game.Start(domainUpDown1.Text);
            }
            else
            {
                richTextBox1.Text = game.Start(domainUpDown2.Text);
            }

            if (game.score == 100)
            {
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
                game.score = 0;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "\n" + "/exit";
            richTextBox1.Text += game.AddScore(richTextBox1.Lines[richTextBox1.Lines.Length - 1]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
        }
    }
}
