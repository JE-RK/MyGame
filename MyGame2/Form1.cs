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
        public Form1(Form2 form2)
        {
            this.form2 = form2;
            InitializeComponent();
        }

        public int Player1Step() => int.Parse(domainUpDown1.Text);

        public int Player2Step() => int.Parse(domainUpDown2.Text);

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (form2.GameWithBot)
                {
                    domainUpDown2.Enabled = false;
                    FormPlayer p1 = new FormPlayer(textBox1.Text, form2.game);
                    p1.StepMethod = Player1Step;
                    form2.game.CreatePlayers(p1);
                }
                else
                {
                    domainUpDown2.Enabled = true;
                    FormPlayer p1 = new FormPlayer(textBox1.Text, form2.game);
                    FormPlayer p2 = new FormPlayer(textBox2.Text, form2.game);
                    p1.StepMethod = Player1Step;
                    p2.StepMethod = Player2Step;
                    form2.game.CreatePlayers(p1, p2);
                }
                richTextBox1.Text = "Игроки созданы\n";
                richTextBox1.Text += $"Игрок {form2.game.StepNowPlayerName}  ходит первым\n";
                if (form2.GameWithBot && form2.game.StepNowPlayerName == form2.game.player2.Name)
                {
                    int lastscore = form2.game.Score;
                    form2.game.player2.Step();
                    richTextBox1.Text += "Бот выбрал число - " + (form2.game.Score - lastscore).ToString() + "\n";
                }
                textBox1.Hide();
                textBox2.Hide();
                label1.Hide();
                label2.Hide();
                label3.Text = textBox1.Text;
                label4.Text = textBox2.Text;
                button1.Hide();
                domainUpDown1.Enabled = true;
                button2.Show();
                button3.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (form2.game.StepNowPlayerName == form2.game.player1.Name)
                {
                    form2.game.player1.Step();
                    richTextBox1.Text = "Счет - " + form2.game.Score + "\n";

                }
                else
                {
                    form2.game.player2.Step();
                    richTextBox1.Text = "Счет - " + form2.game.Score + "\n";
                }
                if (form2.GameWithBot && form2.game.StepNowPlayerName == form2.game.player2.Name)
                {
                    int lastscore = form2.game.Score;
                    form2.game.player2.Step();
                    richTextBox1.Text = "Бот выбрал число - " + (form2.game.Score - lastscore).ToString() + "\n";
                    richTextBox1.Text += "Счет - " + form2.game.Score + "\n";
                }
                richTextBox1.Text += "Ходит игрок " + form2.game.StepNowPlayerName + "\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (form2.game.EndGame() == true)
            {
                richTextBox1.Text = "Счет - " + form2.game.Score + "\n";
                richTextBox1.Text = "Выиграл - " + form2.game.LastPlayerName + "\n";
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
                form2.game.ResetScore();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (form2.GameWithBot)
            {
                textBox2.Enabled = false;
            }
            button2.Hide();
            button3.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form2.game.ResetScore();
            this.Close();
            form2.Show();
        }
    }
}
