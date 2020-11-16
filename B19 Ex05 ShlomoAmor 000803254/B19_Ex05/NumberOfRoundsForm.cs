using System;
using System.Windows.Forms;
using System.Drawing;

namespace B19_Ex05
{
    public class NumberOfRoundsForm : Form
    {
        private Button m_ButtonStart = new Button();
        private Button m_ButtonRoundsNumber = new Button();

        private const int k_MaxNumberOfRounds = 10;
        private const int k_MinNumberOfRounds = 4;
        private const int k_ButtonHeight = 30; 

        private int m_NumberOfRounds = 0;
        private bool m_IsIncrease = true;


        public NumberOfRoundsForm()
        {
            this.Size = new Size(300, k_ButtonHeight * 5);
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bool Pgia";
            m_NumberOfRounds = k_MinNumberOfRounds;
        }

        public int Rounds
        {
            get { return m_NumberOfRounds; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initControls();
        }

        private void initControls()
        {
            m_ButtonRoundsNumber.Text = "Number of chances: " + m_NumberOfRounds;
            m_ButtonRoundsNumber.Size = new Size(150, k_ButtonHeight);
            m_ButtonRoundsNumber.Location = new Point((this.Width - m_ButtonRoundsNumber.Width) / 2, (this.ClientSize.Height - m_ButtonRoundsNumber.Height) / 4);


            m_ButtonStart.Text = "Start";
            m_ButtonStart.Size = new Size(50, k_ButtonHeight);
            m_ButtonStart.Location = new Point((this.Width - m_ButtonStart.Width) / 4 * 3, (this.ClientSize.Height - m_ButtonStart.Height) / 4 * 3);

            this.Controls.AddRange(new Control[] { m_ButtonRoundsNumber, m_ButtonStart });

            this.m_ButtonRoundsNumber.Click += new EventHandler(buttonRoundsNumberClick);
            this.m_ButtonStart.Click += new EventHandler(m_ButtonStart_Click);
        }

        protected void buttonRoundsNumberClick(object i_Buttom, EventArgs i_Click)
        {
            if (m_IsIncrease)
            {
                if (m_NumberOfRounds == k_MaxNumberOfRounds)
                {
                    m_IsIncrease = false;
                    m_NumberOfRounds = k_MinNumberOfRounds;
                }
                else
                {
                    m_NumberOfRounds++;
                }
            }
            else
            {
                if (m_NumberOfRounds == k_MinNumberOfRounds)
                {
                    m_IsIncrease = true;
                    m_NumberOfRounds++;
                }
                else
                {
                    m_NumberOfRounds = k_MinNumberOfRounds;
                }
            }
            (i_Buttom as Button).Text = "Number of chances: " + m_NumberOfRounds;
        }

        protected void m_ButtonStart_Click(object i_Buttom, EventArgs i_Click)
        {
            this.Close();
        }
    }
}