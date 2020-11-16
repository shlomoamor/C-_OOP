using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace B19_Ex05
{
    public class BoardForm : Form
    {
       

        private const int k_ButtonSize = 30;
        private const int k_SpaceSize = 5;
        private const int k_SequenceLength = 4;

        private Board m_GameBoard = null;
        private List<Button> m_ComputerSequence = new List<Button>(k_SequenceLength);
        private readonly int r_NumberOfRounds = 0;
        private List<ButtonsRow> m_Guesses = null;
        private int m_NumberOfRoundPlayed = 0;

        public BoardForm(int i_NumberOfRound, Board i_GameBoard)
        {
            r_NumberOfRounds = i_NumberOfRound;
            m_GameBoard = i_GameBoard;
            m_Guesses = new List<ButtonsRow>(i_NumberOfRound);
            this.Size = new Size((k_SequenceLength + 3) * (k_ButtonSize + k_SpaceSize) + k_SequenceLength , (r_NumberOfRounds + 3) * (k_ButtonSize + k_SpaceSize));
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bool Pgia";
        }

        private void addComputerSequence()
        {
            for (int i = 0; i < k_SequenceLength; i++)
            {
                Button currButton = new Button();
                currButton.BackColor = Color.Black;
                currButton.Enabled = false;
                currButton.Size = new Size(k_ButtonSize, k_ButtonSize);
                currButton.Location = new Point(k_SpaceSize + (k_SpaceSize + k_ButtonSize) * i, k_SpaceSize);
                this.Controls.Add(currButton);
                m_ComputerSequence.Add(currButton);
            }
        }
        private void addButtons()
        {
            for (int i = 0; i < r_NumberOfRounds; i++)
            {
                ButtonsRow currRow = new ButtonsRow(i, k_ButtonSize, k_SpaceSize, k_SequenceLength);
                m_Guesses.Add(currRow);
                foreach (Button curButton in currRow.Buttons)
                {
                    this.Controls.Add(curButton);
                }
                currRow.Buttons.ElementAt(k_SequenceLength).Click += new EventHandler(m_Result_Click);
            }
        }

        private void m_Result_Click(object i_Buttom, EventArgs i_Click)
        {
            Sequence currSequence = new Sequence(k_SequenceLength);
            for(int i = 0; i < k_SequenceLength; i++)
            {
                currSequence.SequenceList.Add(m_Guesses.ElementAt(m_NumberOfRoundPlayed).Buttons.ElementAt(i).BackColor);
            }
            m_GameBoard.Guesses.Add(currSequence);
            Results currResult = new Results(k_SequenceLength);
            currResult.CalculateResult(currSequence, m_GameBoard.ComputerSequence);
            m_GameBoard.Results.Add(currResult);
            colorResult(currResult);
            foreach(Button currButton in m_Guesses.ElementAt(m_NumberOfRoundPlayed).Buttons)
            {
                currButton.Enabled = false;
            }
            checkForWin(currResult);
        }

        private void checkForWin(Results currResult)
        {
            m_NumberOfRoundPlayed++;
            if (currResult.Bulls == k_SequenceLength || m_NumberOfRoundPlayed == r_NumberOfRounds)
            {
                showAnswer();   
            }
            else
            {
                m_Guesses.ElementAt(m_NumberOfRoundPlayed).Buttons.ElementAt(0).Enabled = true;
            }
        }

        private void showAnswer()
        {
            for(int i = 0; i < k_SequenceLength; i++)
            {
                m_ComputerSequence.ElementAt(i).BackColor = m_GameBoard.ComputerSequence.SequenceList.ElementAt(i);
            }
        }

        private void colorResult(Results i_CurrResult)
        {
            int count = 0;
            for(int i = 0; i < i_CurrResult.Bulls; i++)
            {
                count++;
                m_Guesses.ElementAt(m_NumberOfRoundPlayed).Buttons.ElementAt(k_SequenceLength + count).BackColor = System.Drawing.Color.Black;
            }
            for (int i = 0; i < i_CurrResult.Cows; i++)
            {
                count++;
                m_Guesses.ElementAt(m_NumberOfRoundPlayed).Buttons.ElementAt(k_SequenceLength + count).BackColor = System.Drawing.Color.Yellow;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initControls();
            runGame();
        }

        private void runGame()
        {
            m_Guesses.ElementAt(m_NumberOfRoundPlayed).Buttons.ElementAt(0).Enabled = true;
        }

        private void initControls()
        {
            addButtons();
            addComputerSequence();
        }
    }
}