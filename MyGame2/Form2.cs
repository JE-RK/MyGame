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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Game game = new Game();
        private void button2_Click(object sender, EventArgs e)
        {
            game.GameWithBot = false;
            new Form1(this, game).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.GameWithBot = true;
            new Form1(this, game).Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
