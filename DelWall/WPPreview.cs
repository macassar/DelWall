using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelWall
{
    public partial class WPPreview : Form
    {
        public WPPreview()
        {
            InitializeComponent();
        }

        private void WPPreview_Load(object sender, EventArgs e)
        {
            setPicture(Program.registryLocationWin7, Program.wallpaperKeyName);
            labelLocation.Text = Program.readLocation(Program.registryLocationWin7, Program.wallpaperKeyName);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            setPicture(Program.registryLocationWin7, Program.wallpaperKeyName);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            setPicture(Program.registryLocationWin7, Program.wallpaperKeyName);
        }        
        
        private Boolean setPicture(string registryLocation, string wallpaperKeyName)
        {
            string pictureLocation = Program.readLocation(registryLocation, wallpaperKeyName);

            pictureBox.Image = Image.FromFile(pictureLocation);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
