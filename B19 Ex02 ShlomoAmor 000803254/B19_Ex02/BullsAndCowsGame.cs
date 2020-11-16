using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex02
{
    /** This class is responsible for running the game, dictating the way the game runs.*/
    public class BullsAndCowsGame
    {
        private bool m_Won = false;
        private bool m_PlayerWantToPlay = true;
        private Board m_Board = null;
        private BoardUI m_BoardUI = null;
        private int m_NumberOfDesiredGuesses = 0;
        private int m_NumberOfTrys;
        private readonly int r_SequenceLength = 4;

        /**Class constructor*/
        public BullsAndCowsGame()
        {
            m_Won = false;
            m_PlayerWantToPlay = true;
            m_Board = new Board(m_NumberOfDesiredGuesses, r_SequenceLength);
            m_BoardUI = new BoardUI(m_Board, out m_NumberOfDesiredGuesses,  r_SequenceLength);
            m_Board.NumberOfGuesses = m_NumberOfDesiredGuesses;
            m_NumberOfTrys = 0;    
        }

        /** This method is called upon request to restart the game.*/
        internal void Restart()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            this.m_Won = false;
            this.m_Board = new Board(m_NumberOfDesiredGuesses, r_SequenceLength);
            this.m_BoardUI = new BoardUI(m_Board, out m_NumberOfDesiredGuesses, r_SequenceLength);
            this.m_Board.NumberOfGuesses = m_NumberOfDesiredGuesses;
            this.m_NumberOfTrys = 0;
        }

        /** This method is dictates the game, calling up the necessary methods.*/
        internal void RunGame()
        {

           
            while (m_NumberOfTrys < m_NumberOfDesiredGuesses  && m_PlayerWantToPlay)
            {
                m_PlayerWantToPlay = this.playARound(ref m_Won);
                if (m_Won)
                {
                    if (m_BoardUI.AnotherGame())
                    {
                        this.Restart();
                    }
                    else
                    {
                        m_PlayerWantToPlay = false;
                        break;
                    }
                }  
            }
            if (m_PlayerWantToPlay)
            {
                m_BoardUI.PrintBoard();
                m_BoardUI.GameLost();
                if (m_BoardUI.AnotherGame())
                {
                    this.Restart();
                    this.RunGame();
                }
                else
                {
                    m_PlayerWantToPlay = false;
                }
            }
            
        }

        /** This method is called upon by the round game.
         @param i_won boolean variable representing if the game has been won.*/
        private bool playARound(ref bool i_Won)
        {
           
                m_BoardUI.PrintBoard();
                m_Won = m_BoardUI.ReceiveAction( m_Board, ref m_PlayerWantToPlay);
                m_NumberOfTrys++;
            return m_PlayerWantToPlay;   
        }
    }
}
