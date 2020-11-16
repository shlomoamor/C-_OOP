using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex05
{
    /** This class is responsible for logging the board data */
    public class Board
    {
        private readonly Sequence r_ComputerSequence = null;
        private List<Sequence> m_Guesses = null;
        private List<Results> m_Results = null;
        private int m_NumberOfDesiredGuesses = 0;
        private readonly int r_SequenceLength = 0;

        /**Class constructor 
         * @param i_NumberOfDesiredGuesses the max allowed guesses
         * @param i_SequenceLength the length of the Sequence */
        public Board( int i_SequenceLength)
        {
            r_SequenceLength = i_SequenceLength;
            r_ComputerSequence = new Sequence(r_SequenceLength);
            r_ComputerSequence.GenerateComputerSequence();
            m_Guesses = new List<Sequence>();
            m_Results = new List<Results>();
        }
        /**int NumberOfGuesses get and set*/
        public int NumberOfGuesses
        {
            get { return m_NumberOfDesiredGuesses; }
            set { m_NumberOfDesiredGuesses = value; }
        }

        /**Computer generated Sequence get and set*/
        public Sequence ComputerSequence
        {
            get { return r_ComputerSequence; }
        }

        /**Guess get and set*/
        public List<Sequence> Guesses
        {
            get { return m_Guesses; }
            set { m_Guesses = value; }
        }

        /**Results get and set*/
        public List<Results> Results
        {
            get { return m_Results; }
            set { m_Results = value; }
        }

    }
}
