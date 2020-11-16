using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex05
{
    /** This class is responsible for running the game, dictating the way the game runs.*/
    public class BullsAndCowsGame
    {
        private Board m_Board = null;
        private BoardUI m_BoardUI = null;
        private int m_NumberOfDesiredGuesses = 0;
        private readonly int r_SequenceLength = 4;

        /**Class constructor*/
        public BullsAndCowsGame()
        {
            m_Board = new Board(r_SequenceLength);
            m_BoardUI = new BoardUI(m_Board, out m_NumberOfDesiredGuesses, r_SequenceLength);
            m_Board.NumberOfGuesses = m_NumberOfDesiredGuesses;
        }
    }
}
