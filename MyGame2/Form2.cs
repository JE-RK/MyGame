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
        public Game game = new Game();
        private bool _gamewithbot = false;
        public bool GameWithBot { get { return _gamewithbot; } }
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            _gamewithbot = false;
            new Form1(this).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _gamewithbot = true;
            new Form1(this).Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
