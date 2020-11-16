using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace B19_Ex05
{
    /** This class is responsible for generating computer "guess" and handling user's guess.*/
    public class Sequence
    {
        private Color[] m_ColorArray = {Color.Purple, Color.Red, Color.Green, Color.LightBlue, Color.Blue, Color.Yellow, Color.Brown, Color.White};
        private readonly int r_LengthOfSequence;
        private List<Color> m_SequenceList = null;
        private Random m_RandomColor = new Random();

        /**Class constructor @param i_LengthOfSequence the length of the current guess*/
        public Sequence(int i_LengthOfSequence)
        {
            r_LengthOfSequence = i_LengthOfSequence;
            m_SequenceList = new List<Color>(r_LengthOfSequence);

        }

        /**Guess get and set*/
        public List<Color> SequenceList
        {
            get { return m_SequenceList; }
            set { m_SequenceList = value; }
        }

        /**This method generates a computer sequence using the Random class */
        internal void GenerateComputerSequence()
        {
            int ColorCounter = 0;
            Color ColorForSequence;
            while (ColorCounter < r_LengthOfSequence)
            {
                int random = (int)(m_RandomColor.Next(0, m_ColorArray.Length));
                ColorForSequence = m_ColorArray[random];
                if (!m_SequenceList.Contains(ColorForSequence))
                {
                    m_SequenceList.Add(ColorForSequence);
                    ColorCounter++;
                }
            }
            // signalling the garbage collector that we are done
            m_RandomColor = null;
        }
    }
}
