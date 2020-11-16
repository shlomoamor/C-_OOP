using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex02
{
    /** This class is responsible for collecting the results and allocating cows and bulls accordingly.*/
    public class Results
    {
        private readonly int r_LengthOfSequence = 0;
        private int m_Bulls = 0;
        private int m_cows = 0;

        /**Class constructor @param i_LengthOfSequence the length of the current guess*/
        public Results( int i_LengthOfSequence)
        {
            this.r_LengthOfSequence = i_LengthOfSequence;
            m_Bulls = 0;
            m_cows = 0;
        }

        /**Bulls get and set*/
        public int Bulls
        {
            get { return m_Bulls; }
            set { m_Bulls = value; }
        }

        /**Bulls get and set*/
        public int Cows
        {
            get { return m_cows; }
            set { m_cows = value; }
        }

        /** This method calculates how many cows and bulls for a given sequence.
            @param i_userSequence user guess.
            @param i_computerSequence computer generated sequence*/
        internal void CalculateResult(Sequence i_userSequence, Sequence i_computerSequence)
        {
            for (int CurrentUserGuess = 0; CurrentUserGuess < r_LengthOfSequence; CurrentUserGuess++)
            {
                for (int CurrentComputerSequence = 0; CurrentComputerSequence < r_LengthOfSequence; CurrentComputerSequence++)
                {
                    if (i_userSequence.SequenceList.ElementAt(CurrentUserGuess) == i_computerSequence.SequenceList.ElementAt(CurrentComputerSequence))
                    {
                        if (CurrentUserGuess == CurrentComputerSequence)
                        {
                            m_Bulls++;
                        }
                        else
                        {
                            m_cows++;
                        }
                    }
                }
            }
        }

        /**This method converts the amount of cows and bulls to V's and X's respectivley */
        public override string ToString()
        {
            StringBuilder resultsString = new StringBuilder(); 
   
            for(int i = 0; i < m_Bulls; i++)
            {
                resultsString.Append("V ");
            }
            for (int i = 0; i < m_cows; i++)
            {
                resultsString.Append("X ");
            }
            for (int i = 0; i < r_LengthOfSequence - m_cows - m_Bulls; i++)
            {
                resultsString.Append("  ");
            }
            resultsString.Remove(r_LengthOfSequence * 2 - 1, 1);
            return resultsString.ToString();
        }

    }
}
