using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B19_Ex02
{
    /** This class is responsible for generating computer "guess" and handling user's guess.*/
    public class Sequence
    {
        private readonly int r_LengthOfSequence;
        List<char> m_SequenceList = null;

        /**Class constructor @param i_LengthOfSequence the length of the current guess*/
        public Sequence(int i_LengthOfSequence)
        {
            r_LengthOfSequence = i_LengthOfSequence;
            m_SequenceList = new List<char>(r_LengthOfSequence);

        }

        /**Guess get and set*/
        public List<char> SequenceList
        {
            get { return m_SequenceList; }
            set {m_SequenceList = value; }
        }
       
        /**This method generates a computer sequence using the Random class */
        internal void GenerateComputerSequence()
        {
            
            Random randomLetter = new Random();
            int CharCounter = 0;
            while(CharCounter < r_LengthOfSequence)
            {
                char CharForSequence = (char)(randomLetter.Next('A', 'H'));
                if (!m_SequenceList.Contains(CharForSequence))
                {
                    m_SequenceList.Add(CharForSequence);
                    CharCounter++;
                }
                
            }
            // signalling the garbage collector that we are done
            randomLetter = null;
 
        }

        /**This method converts a string to a Sequence @param i_UserInput the users console input*/
        internal void GetUserGuess(string i_UserInput)
        {
            for (int i = 0; i < r_LengthOfSequence; i++)
            {
                 m_SequenceList.Add(i_UserInput[2 * i]);
            }
        }


        /**This method converts Sequence to a string */
        public override string ToString()
        {
            StringBuilder sequenceString = new StringBuilder();
            for (int i = 0; i < r_LengthOfSequence; i++)
            {
                sequenceString.AppendFormat("{0} ", m_SequenceList.ElementAt(i));
            }
            return sequenceString.ToString();
        }

    }
}
