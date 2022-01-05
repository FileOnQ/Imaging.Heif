using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileOnQ.Imaging.Heif;

namespace WinformsApp.net48
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		private void btnProcess_Click(object sender, EventArgs e)
		{

			OpenFileDialog fileDialog = new OpenFileDialog();
			var result = fileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				try
				{
					var file = fileDialog.FileName;
					using (var image = new HeifImage(file))
					{
						try
						{
							using (var thumb = image.Thumbnail())
							{
								pbPicture.Image = byteArrayToImage(thumb.ToArray());

							}
						}
						catch (HeifException ex)
						{
							if (ex.ErrorCode != LibHeif.ErrorCode.NoThumbnail)
								throw;

							using (var primaryImage = image.PrimaryImage())
							{
								pbPicture.Image = byteArrayToImage(primaryImage.ToArray());

							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error Processing Image", ex.Message, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
				}
			}

		}
		public Image byteArrayToImage(byte[] byteArrayIn)
		{
			Image returnImage = null;
			using (MemoryStream ms = new MemoryStream(byteArrayIn))
			{
				returnImage = Image.FromStream(ms);
			}
			return returnImage;
		}
	}
}
