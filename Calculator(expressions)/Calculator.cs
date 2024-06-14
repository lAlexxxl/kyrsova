using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator_expressions_
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
            this.KeyPreview = true; //підключаємо клавіатуру
            this.KeyDown += new KeyEventHandler(Calculator_KeyDown);
        }

        #region SettingForm
        private bool isClickMouse = false;
        private Point currentPosition = new Point(0, 0);

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isClickMouse = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isClickMouse = true;
            currentPosition = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isClickMouse) return;
            this.Location = new Point(this.Location.X + e.X - currentPosition.X, this.Location.Y + e.Y - currentPosition.Y);
        }
        #endregion

        private void buttonNumberClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            textHistory.Text += button.Text;
        }

        private void buttonOperationClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            textHistory.Text += " " + button.Text + " ";
        }

        private void buttonClear(object sender, EventArgs e)
        {
            textHistory.Text = string.Empty;
            textResult.Text = string.Empty;
        }

        private void buttonResultClick(object sender, EventArgs e)
        {
            try
            {
                var result = EvaluateExpression(textHistory.Text);
                textResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                textResult.Text = "Ошибка";
            }
        }

        private double EvaluateExpression(string expression)
        {
            var dataTable = new DataTable();
            var result = dataTable.Compute(expression, string.Empty);
            return Convert.ToDouble(result);
        }

        private void buttonResetNumber(object sender, EventArgs e)
        {
            if (textHistory.Text.Length <= 0) return;
            textHistory.Text = textHistory.Text.Substring(0, textHistory.Text.Length - 1);
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                //верхні цифри і нампад
                textHistory.Text += (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ? ((char)e.KeyValue).ToString() : ((char)(e.KeyValue - 48)).ToString();
            }
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                textHistory.Text += " + ";
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                textHistory.Text += " - ";
            }
            else if (e.KeyCode == Keys.Multiply || e.KeyCode == Keys.D8 && e.Shift)
            {
                textHistory.Text += " * ";
            }
            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemQuestion)
            {
                textHistory.Text += " / ";
            }
            else if (e.KeyCode == Keys.Enter)
            {
                buttonResultClick(this, new EventArgs());
            }
            else if (e.KeyCode == Keys.Back)
            {
                buttonResetNumber(this, new EventArgs());
            }
            else if (e.KeyCode == Keys.Escape)
            {
                buttonClear(this, new EventArgs());
            }
        }
    }
}
