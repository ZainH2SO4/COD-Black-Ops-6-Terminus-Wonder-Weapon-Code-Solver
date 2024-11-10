using System;
using System.Windows.Forms;

namespace COD_BO6_Terminus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Set default button texts
            buttonX.Text = "";
            buttonY.Text = "";
            buttonZ.Text = "";
            textBoxCode.Text = "Please Select All Symbols";
        }

        private void InitializeComponent()
        {
            this.labelInputSymbols = new Label();
            this.labelX = new Label();
            this.labelY = new Label();
            this.labelZ = new Label();
            this.labelCode = new Label();

            this.buttonX = new Button();
            this.buttonY = new Button();
            this.buttonZ = new Button();
            this.buttonReset = new Button();
            this.textBoxCode = new TextBox();

            // Form Properties
            this.Text = "Symbol Selector";
            this.Size = new System.Drawing.Size(400, 300);

            // Label for Input Symbols
            labelInputSymbols.Text = "Input Symbols";
            labelInputSymbols.Location = new System.Drawing.Point(150, 20);
            labelInputSymbols.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            // X Symbol Label
            labelX.Text = "X Symbol:";
            labelX.Location = new System.Drawing.Point(50, 60);

            // Y Symbol Label
            labelY.Text = "Y Symbol:";
            labelY.Location = new System.Drawing.Point(150, 60);

            // Z Symbol Label
            labelZ.Text = "Z Symbol:";
            labelZ.Location = new System.Drawing.Point(250, 60);

            // Buttons for Symbols
            buttonX.Location = new System.Drawing.Point(50, 90);
            buttonX.Click += new EventHandler(this.ButtonX_Click);

            buttonY.Location = new System.Drawing.Point(150, 90);
            buttonY.Click += new EventHandler(this.ButtonY_Click);

            buttonZ.Location = new System.Drawing.Point(250, 90);
            buttonZ.Click += new EventHandler(this.ButtonZ_Click);

            // Code Label
            labelCode.Text = "Your Code:";
            labelCode.Location = new System.Drawing.Point(50, 150);

            // TextBox for Code
            textBoxCode.Location = new System.Drawing.Point(50, 180);
            textBoxCode.Width = 300;
            textBoxCode.ReadOnly = true;

            // Reset Button
            buttonReset.Text = "Reset All";
            buttonReset.Location = new System.Drawing.Point(150, 220);
            buttonReset.Click += new EventHandler(this.ButtonReset_Click);

            // Add Controls to Form
            this.Controls.Add(labelInputSymbols);
            this.Controls.Add(labelX);
            this.Controls.Add(labelY);
            this.Controls.Add(labelZ);
            this.Controls.Add(buttonX);
            this.Controls.Add(buttonY);
            this.Controls.Add(buttonZ);
            this.Controls.Add(labelCode);
            this.Controls.Add(textBoxCode);
            this.Controls.Add(buttonReset);
        }

        private void ButtonX_Click(object sender, EventArgs e)
        {
            using (var symbolForm = new SymbolSelectorApp())
            {
                if (symbolForm.ShowDialog() == DialogResult.OK)
                {
                    buttonX.Text = symbolForm.SelectedSymbol;
                    UpdateCode();
                }
            }
        }

        private void ButtonY_Click(object sender, EventArgs e)
        {
            using (var symbolForm = new SymbolSelectorApp())
            {
                if (symbolForm.ShowDialog() == DialogResult.OK)
                {
                    buttonY.Text = symbolForm.SelectedSymbol;
                    UpdateCode();
                }
            }
        }

        private void ButtonZ_Click(object sender, EventArgs e)
        {
            using (var symbolForm = new SymbolSelectorApp())
            {
                if (symbolForm.ShowDialog() == DialogResult.OK)
                {
                    buttonZ.Text = symbolForm.SelectedSymbol;
                    UpdateCode();
                }
            }
        }



        private void ButtonReset_Click(object sender, EventArgs e)
        {
            buttonX.Text = "";
            buttonY.Text = "";
            buttonZ.Text = "";
            textBoxCode.Text = "Please Select All Symbols";
        }

        private void UpdateCode()
        {
            try
            {
                int x = int.Parse(buttonX.Text);
                int y = int.Parse(buttonY.Text);
                int z = int.Parse(buttonZ.Text);
                textBoxCode.Text = $"Code: {x * 2 + 11} {(2 * z + y) - 5} {Math.Abs(y + z - x)}";
            }
            catch (Exception)
            {
                textBoxCode.Text = "Please Select All Symbols";


            }
        }

        private string ShowSymbolDialog()
        {
            // This is a simple input dialog for selecting a symbol
            using (var dialog = new Form())
            {
                var inputBox = new TextBox { Width = 100, Location = new System.Drawing.Point(10, 10) };
                var buttonOK = new Button { Text = "OK", Location = new System.Drawing.Point(120, 10) };

                dialog.Controls.Add(inputBox);
                dialog.Controls.Add(buttonOK);

                string symbol = null;
                buttonOK.Click += (s, e) => { symbol = inputBox.Text; dialog.Close(); };

                dialog.ShowDialog();
                return symbol;
            }
        }

        // Declare UI elements
        private Label labelInputSymbols, labelX, labelY, labelZ, labelCode;
        private Button buttonX, buttonY, buttonZ, buttonReset;
        private TextBox textBoxCode;
    }
}
