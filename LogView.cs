using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuittisovellus
{
    public partial class LogView : TabUC
    {

        private List<Point> _drawLines;
        private Pen _lineDrawer;
        public LogView(int tabHeight)
        {
            InitializeComponent();
            SetControlSizes();
            setUCSize(tabHeight);
            SetControls();
            
        }

        public void AddMessage(string message)
        {
            if (TextElement.InvokeRequired)
            {
                TextElement.BeginInvoke(() => AddMessage(message));
                return;
            }


            if (CheckMessageExceedingLimit(message, TextElement))
            {
                TextElement.Text += AddNewLinesToMessageForTextElement(message);
            }
            else
            {
                TextElement.Text += message + "\n";
            }           
            
            AdjustTextElementSize();
            DrawOnTextElement();

        }

        private void AdjustTextElementSize()
        {
            TextElement.Size = new Size(PanelForMessages.Width, Convert.ToInt16(TextElement.CreateGraphics().MeasureString
                (TextElement.Text, TextElement.Font).Height) + 3);
        }

        private void DrawOnTextElement()
        {
            _drawLines.Add(new Point(0, TextElement.Height - 4));
            TextElement.Invalidate();
        }

        private void SetControlSizes()
        {
            PanelForMessages.Size = new Size(Settings.Instance.UCSize.Width - 30, Settings.Instance.UCSize.Height - 100);

            TextElement.Size = new Size(PanelForMessages.Width - (TextElement.Location.X - 
                PanelForMessages.Location.X), TextElement.Size.Height);
        }

        private void SetControls()
        {
            TextElement.Text = string.Empty;
            _drawLines = new List<Point>();
            _lineDrawer = new Pen(Color.Blue, 1);
        }


        private bool CheckMessageExceedingLimit(string message, Control control)
        {
            if (control.CreateGraphics().MeasureString(message, control.Font).Width > control.Width)
            {
                return true;
            }
            return false;
        }

        private string AddNewLinesToMessageForTextElement(string message)
        {
            List<string> completeStrings = new List<string>();

            Graphics graphics = TextElement.CreateGraphics();

            if (graphics.MeasureString(message, TextElement.Font).Width < PanelForMessages.Width)
            {
                return message + "\r\n";
            }

            string[] strings = message.Split("\n");

            foreach (string sub in strings)
            {
                if (graphics.MeasureString(sub, TextElement.Font).Width > PanelForMessages.Width)
                {
                    completeStrings.Add(AddNewLinesToString(sub, PanelForMessages.Width, PanelForMessages.Font, graphics));
                    continue;
                }
                completeStrings.Add(sub);
            }

            

            return String.Join(string.Empty, completeStrings);

        }

        private string AddNewLinesToString(string partToConvert, int maxWidth, Font font, Graphics graphics)
        {


            int oneCharWidth = GetOneCharWidthInPixels(font, graphics);

            int excessWidth = Convert.ToInt16(graphics.MeasureString(partToConvert, font).Width) - maxWidth;



            int amountOfCharactersOver = excessWidth / oneCharWidth;

            amountOfCharactersOver++;

            string excessString = partToConvert.Substring(partToConvert.Length - 1 - amountOfCharactersOver);

            partToConvert = partToConvert.Remove(partToConvert.Length - 1 - amountOfCharactersOver);



            if (Convert.ToInt16(graphics.MeasureString(excessString, font).Width) > maxWidth)
            {
                excessString = AddNewLinesToString(excessString, maxWidth, font, graphics);
            }

            partToConvert += "\n";
            excessString += "\n";






            partToConvert += excessString;

            return partToConvert;
        }

        private int GetOneCharWidthInPixels(Font font, Graphics graphics)
        {
            return Convert.ToInt16(graphics.MeasureString("i", font).Width);
        }

        private int GetOneCharWidthInPixels(Font font, Graphics graphics, string character)
        {
            return Convert.ToInt16(graphics.MeasureString(character, font).Width);
        }


        private void TestButton_Click(object sender, EventArgs e)
        {
            AddMessage("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                "AAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        }

        private void TextElement_Paint(object sender, PaintEventArgs e)
        {
            foreach (Point point in _drawLines)
            {
                e.Graphics.DrawLine(_lineDrawer, point, new Point(TextElement.Width, point.Y));
            }
        }

    }
}
