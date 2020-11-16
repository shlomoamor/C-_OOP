using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace B19_Ex05
{
    /** This class is responsible for the user interface i.e. printing the board and results and communicating with the user. */
    public class BoardUI
    {
        private Board m_GameBoard = null;

        /**Class constructor 
         * @param i_GameBoard current board
           @param i_NumberOfGeusses the amount of guesses
           @param i_LengthOfSequence the length of a Sequence*/
        public BoardUI(Board i_GameBoard, out int io_NumberOfGuesses, int i_LengthOfSequence)
        {
            NumberOfRoundsForm numberOfRoundsForm = new NumberOfRoundsForm();
            m_GameBoard = i_GameBoard;
            numberOfRoundsForm.ShowDialog();
            io_NumberOfGuesses = numberOfRoundsForm.Rounds;
            i_GameBoard.NumberOfGuesses = io_NumberOfGuesses;
            BoardForm m_MyBoard = new BoardForm(io_NumberOfGuesses, i_GameBoard);
            m_MyBoard.ShowDialog();
        }
    }
}
