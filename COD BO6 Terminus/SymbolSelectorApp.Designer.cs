using System;
using System.Windows.Forms;

namespace COD_BO6_Terminus
{
    public partial class SymbolSelectorApp : Form
    {
        public string SelectedSymbol { get; private set; }

        public SymbolSelectorApp()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Select a Symbol";
            this.Size = new System.Drawing.Size(200, 250);

            // Create PictureBoxes for symbols
            PictureBox[] symbolBoxes = new PictureBox[6];
            for (int i = 0; i < symbolBoxes.Length; i++)
            {
                symbolBoxes[i] = new PictureBox
                {
                    Size = new System.Drawing.Size(50, 50),
                    Location = new System.Drawing.Point(10 + (i % 3) * 60, 10 + (i / 3) * 60),
                    BorderStyle = BorderStyle.FixedSingle,
                    
                };
                symbolBoxes[i].Click += SymbolBox_Click;
                this.Controls.Add(symbolBoxes[i]);
            }

            // Load images (replace "path_to_image" with actual image paths or resources)
            symbolBoxes[0].Image = Properties.Resources._0; // Load your image here
            symbolBoxes[0].Tag = "0";
            symbolBoxes[1].Image = Properties.Resources._10;
            symbolBoxes[1].Tag = "10";
            symbolBoxes[2].Image = Properties.Resources._11;
            symbolBoxes[2].Tag = "11";
            symbolBoxes[3].Image = Properties.Resources._22;
            symbolBoxes[3].Tag = "22";
            symbolBoxes[4].Image = Properties.Resources._21;
            symbolBoxes[4].Tag = "21";
            symbolBoxes[5].Image = Properties.Resources._20;
            symbolBoxes[5].Tag = "20";

            // Cancel button
            Button cancelButton = new Button
            {
                Text = "Cancel",
                Location = new System.Drawing.Point(60, 180),
                Size = new System.Drawing.Size(75, 23)
            };
            cancelButton.Click += (s, e) => this.Close();
            this.Controls.Add(cancelButton);
        }

        private void SymbolBox_Click(object sender, EventArgs e)
        {
            // Set SelectedSymbol to the Tag or identifier of the clicked symbol
            var pictureBox = sender as PictureBox;
            SelectedSymbol = pictureBox.Tag.ToString();
            this.DialogResult = DialogResult.OK; // Close the form with OK result
            this.Close();
        }
    }
}
