using System;
using System.Windows.Forms;

namespace Wyswietlacz7seg
{

    partial class Form1
    {
        public Wyswietlacz wyswietlacz1, wyswietlacz2, wyswietlacz3, wyswietlacz4;
        public Label label;
        public TextBox textBox;

        public void InitializeComponent()
        {
            this.wyswietlacz4 = new Wyswietlacz();
            this.wyswietlacz3 = new Wyswietlacz();
            this.wyswietlacz2 = new Wyswietlacz();
            this.wyswietlacz1 = new Wyswietlacz();
            this.textBox = new TextBox();
            this.label = new Label();
            this.SuspendLayout();
            // 
            // wyswietlacz4
            // 
            this.wyswietlacz4.BackColor = System.Drawing.Color.Black;
            this.wyswietlacz4.Location = new System.Drawing.Point(31, 93);
            this.wyswietlacz4.Name = "wyswietlacz4";
            this.wyswietlacz4.Size = new System.Drawing.Size(100, 200);
            this.wyswietlacz4.TabIndex = 1;
            // 
            // wyswietlacz3
            // 
            this.wyswietlacz3.BackColor = System.Drawing.Color.Black;
            this.wyswietlacz3.Location = new System.Drawing.Point(137, 93);
            this.wyswietlacz3.Name = "wyswietlacz3";
            this.wyswietlacz3.Size = new System.Drawing.Size(100, 200);
            this.wyswietlacz3.TabIndex = 2;
            // 
            // wyswietlacz2
            // 
            this.wyswietlacz2.BackColor = System.Drawing.Color.Black;
            this.wyswietlacz2.Location = new System.Drawing.Point(243, 93);
            this.wyswietlacz2.Name = "wyswietlacz2";
            this.wyswietlacz2.Size = new System.Drawing.Size(100, 200);
            this.wyswietlacz2.TabIndex = 3;
            // 
            // wyswietlacz1
            // 
            this.wyswietlacz1.BackColor = System.Drawing.Color.Black;
            this.wyswietlacz1.Location = new System.Drawing.Point(349, 93);
            this.wyswietlacz1.Name = "wyswietlacz1";
            this.wyswietlacz1.Size = new System.Drawing.Size(100, 200);
            this.wyswietlacz1.TabIndex = 5;
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox.Location = new System.Drawing.Point(31, 36);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(150, 30);
            this.textBox.TabIndex = 4;
            this.textBox.TextChanged += new System.EventHandler(this.PodajLiczbeTextBox_TextChanged);
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PodajLiczbeTextBox_KeyPress);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label.Location = new System.Drawing.Point(28, 16);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(183, 20);
            this.label.TabIndex = 0;
            this.label.Text = "Podaj 4-cyfrową liczbę:";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(479, 353);
            this.Controls.Add(this.label);
            this.Controls.Add(this.wyswietlacz4);
            this.Controls.Add(this.wyswietlacz3);
            this.Controls.Add(this.wyswietlacz2);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.wyswietlacz1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Wyświetlacz 7-SEG";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PodajLiczbeTextBox_TextChanged(object sender, EventArgs e)
        {
            WyswietlajLiczbeZTextField();
        }

        private void PodajLiczbeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!CzyLiczbaHex(e.KeyChar) || textBox.Text.Length >= 4) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void WyswietlajLiczbeZTextField()
        {
            String wpisanyTekst = textBox.Text;
            bool czyHex = false;

            if (wpisanyTekst != null && wpisanyTekst.Length != 0)
            {
                czyHex = CzyLiczbaHex(wpisanyTekst[wpisanyTekst.Length - 1]);
            }

            if (wpisanyTekst.Length <= 4)
            {
                if (czyHex)
                {
                    WypiszLiczbeNaWyswietlaczach(wpisanyTekst);
                }
                else if (wpisanyTekst.Length == 0){
                    wyswietlacz1.WylaczWyswietlacz();
                    wyswietlacz2.WylaczWyswietlacz();
                    wyswietlacz3.WylaczWyswietlacz();
                    wyswietlacz4.WylaczWyswietlacz();
                }
            }
        }

        private bool CzyLiczbaHex(char z)
        {
            return (z == '0' || z == '1' || z == '2' || z == '3' || z == '4' || z == '5' || z == '6' || z == '7'
                  || z == '8' || z == '9' || z == 'A' || z == 'a' || z == 'B' || z == 'b' || z == 'C'
                  || z == 'c' || z == 'D' || z == 'd' || z == 'E' || z == 'e' || z == 'F' || z == 'f');
        }


        private void WypiszLiczbeNaWyswietlaczach(string podanaLiczba)
        {

            wyswietlacz1.WylaczWyswietlacz();
            wyswietlacz2.WylaczWyswietlacz();
            wyswietlacz3.WylaczWyswietlacz();
            wyswietlacz4.WylaczWyswietlacz();

            int dlugoscLiczby = podanaLiczba.Length;

            switch (dlugoscLiczby)
            {
                case 1:
                    wyswietlacz1.Ustaw(podanaLiczba[0]);
                    break;
                case 2:
                    wyswietlacz2.Ustaw(podanaLiczba[0]);
                    wyswietlacz1.Ustaw(podanaLiczba[1]);
                    break;
                case 3:
                    wyswietlacz3.Ustaw(podanaLiczba[0]);
                    wyswietlacz2.Ustaw(podanaLiczba[1]);
                    wyswietlacz1.Ustaw(podanaLiczba[2]);
                    break;
                case 4:
                    wyswietlacz4.Ustaw(podanaLiczba[0]);
                    wyswietlacz3.Ustaw(podanaLiczba[1]);
                    wyswietlacz2.Ustaw(podanaLiczba[2]);
                    wyswietlacz1.Ustaw(podanaLiczba[3]);
                    break;

                default:
                    Console.WriteLine("wypiszLiczbeNaWyswietlaczach: default?!?!?");
                    break;
            }
        }

    }
}


