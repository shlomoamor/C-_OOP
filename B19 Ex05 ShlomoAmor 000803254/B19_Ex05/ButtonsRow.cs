using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace B19_Ex05
{
    internal class ButtonsRow
    {
        private int m_RowNumber = 0;
        private readonly int r_ButtonSize = 0;
        private readonly int r_SpaceSize = 0;
        private readonly int r_SequenceLength = 0;
        private List<Button> m_Buttons;
        private List<Color> m_UsedColor = new List<Color>();
        private Color[] m_ColorArray = { Color.Purple, Color.Red, Color.Green, Color.LightBlue, Color.Blue, Color.Yellow, Color.Brown, Color.White };

        public ButtonsRow(int i_RowNumber, int i_ButtonSize, int i_SpaceSize, int i_SequenceLength)
        {
            m_RowNumber = i_RowNumber;
            r_ButtonSize = i_ButtonSize;
            r_SpaceSize = i_SpaceSize;
            r_SequenceLength = i_SequenceLength;
            m_Buttons = new List<Button>();
            addSequenceButtons();
            addResultButtons();
        }

        private void addSequenceButtons()
        {
            for (int i = 0; i < r_SequenceLength; i++)
            {
                Button currButton = new Button();
                currButton.Enabled = false;
                currButton.Size = new Size(r_ButtonSize, r_ButtonSize );
                currButton.Location = new Point(r_SpaceSize + (r_SpaceSize + r_ButtonSize) * i, r_SpaceSize + (r_SpaceSize + r_ButtonSize) * (m_RowNumber + 1));
                currButton.Click += new EventHandler(m_One_Step_Click);
                m_Buttons.Add(currButton);
            }
        }
        private void addResultButtons()
        {
            int baseLocationWidth = r_SpaceSize + (r_SpaceSize + r_ButtonSize) * r_SequenceLength;
            int baseLocationHight = (r_SpaceSize + r_ButtonSize) * (m_RowNumber + 1) + r_SpaceSize;
            int fifthButtonSize = r_ButtonSize / 5;
            for (int i = 0; i < r_SequenceLength + 1; i++)
            {
                Button currButton = new Button();
                currButton.Enabled = false;
                currButton.Size = new Size(fifthButtonSize * 2, fifthButtonSize * 2);
                m_Buttons.Add(currButton);
            }
            m_Buttons.ElementAt(r_SequenceLength + 1).Location = new Point(baseLocationWidth + r_SpaceSize * 3 + r_ButtonSize , baseLocationHight);
            m_Buttons.ElementAt(r_SequenceLength + 2).Location = new Point(baseLocationWidth + r_SpaceSize * 3 + r_ButtonSize + fifthButtonSize * 3, baseLocationHight);
            m_Buttons.ElementAt(r_SequenceLength + 3).Location = new Point(baseLocationWidth + r_SpaceSize * 3 + r_ButtonSize, baseLocationHight + fifthButtonSize * 3);
            m_Buttons.ElementAt(r_SequenceLength + 4).Location = new Point(baseLocationWidth + r_SpaceSize * 3 + r_ButtonSize + fifthButtonSize * 3, baseLocationHight + fifthButtonSize * 3);

            m_Buttons.ElementAt(r_SequenceLength).Location = new Point(baseLocationWidth, baseLocationHight + fifthButtonSize);
            m_Buttons.ElementAt(r_SequenceLength).Size = new Size(r_ButtonSize + fifthButtonSize * 2, fifthButtonSize * 3);
            m_Buttons.ElementAt(r_SequenceLength).Text = "-->>";
        }

        public List<Button> Buttons
        {
            get { return m_Buttons; }
            set { m_Buttons = value; }
        }

        protected void m_One_Step_Click(object i_Buttom, EventArgs i_Click)
        {
            int currentButtonIndex = m_Buttons.IndexOf((i_Buttom as Button));
            m_UsedColor.Remove((i_Buttom as Button).BackColor);
            ColorForm colorForm = new ColorForm(m_ColorArray, (Button)i_Buttom, r_ButtonSize, r_SpaceSize, m_UsedColor);
            colorForm.ShowDialog();
            m_Buttons.ElementAt(currentButtonIndex + 1).Enabled = true;
        }
    }
}