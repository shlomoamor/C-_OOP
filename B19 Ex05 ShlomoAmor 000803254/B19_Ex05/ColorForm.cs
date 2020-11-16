using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;


namespace B19_Ex05
{
    public class ColorForm : Form
    {
        private Color[] m_ColorArray;
        private readonly int r_ButtonSize;
        private readonly int r_SpaceSize;
        private List<Color> m_UsedColors = null;
        private Button m_Button;

        public ColorForm(Color[] i_ColorArray, Button i_Button, int i_ButtonSize, int i_SpaceSize, List<Color> i_UsedColors)
        {
            r_ButtonSize = i_ButtonSize;
            r_SpaceSize = i_SpaceSize;
            m_ColorArray = i_ColorArray;
            m_Button = i_Button;
            Size = new Size((r_ButtonSize + r_SpaceSize) * 5, (r_ButtonSize + r_SpaceSize) * 4);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            StartPosition = FormStartPosition.CenterScreen;
            m_UsedColors = i_UsedColors;
            Text = "Pick A Color:";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initControls();
        }

        private void initControls()
        {
            for (int j = 0; j < 2; j ++)
                for (int i  = 0; i < 4; i++)
                {
                    Button currButton = new Button();
                    currButton.Size = new Size(r_ButtonSize, r_ButtonSize);
                    currButton.Location = new Point(r_SpaceSize + (r_SpaceSize + r_ButtonSize) * i , r_SpaceSize + (r_SpaceSize + r_ButtonSize) * j);
                    currButton.BackColor = m_ColorArray[i + 4 * j];
                    if (m_UsedColors.Contains(currButton.BackColor))
                        currButton.Enabled = false;
                    this.Controls.Add(currButton);
                    currButton.Click += new EventHandler(m_Color_Button_Click);
                }
        }

        protected void m_Color_Button_Click(object i_Buttom, EventArgs i_Click)
        {
            m_Button.BackColor = (i_Buttom as Button).BackColor;
            m_UsedColors.Add(m_Button.BackColor);
            this.Close();
        }
    }
}