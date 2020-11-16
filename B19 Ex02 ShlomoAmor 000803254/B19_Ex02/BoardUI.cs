using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex02
{
    /** This class is responsible for the user interface i.e. printing the board and results and communicating with the user. */
    public class BoardUI
    {
        private Board m_GameBoard = null; 
        private readonly int r_NumberOfGuesses = 0; 
        private readonly int r_LengthOfSequence = 0; 
        private int i_NumberOfRoundPlayed = 0; 

        /**Class constructor 
         * @param i_GameBoard current board
           @param i_NumberOfGeusses the amount of guesses
           @param i_LengthOfSequence the length of a Sequence*/
        public BoardUI(Board i_GameBoard, out int io_NumberOfGuesses, int i_LengthOfSequence)
        {
            m_GameBoard = i_GameBoard;
            io_NumberOfGuesses = getNumberOfGuesses();
            r_NumberOfGuesses = io_NumberOfGuesses;
            r_LengthOfSequence = i_LengthOfSequence;
            i_NumberOfRoundPlayed = 0;
        }

        public int NumberOfGuesses
        {
            get { return r_NumberOfGuesses; }
        }

        private int getNumberOfGuesses()
        {
            Console.WriteLine("What is your desired number of guesses: ");
            int numberOfGuesses = 0; 
            bool validInput  = int.TryParse(Console.ReadLine(), out numberOfGuesses);
            while (!validInput | (numberOfGuesses < 4 | numberOfGuesses > 10))
            {
                Console.WriteLine("Invalid number of guesses. Enter again: ");
                validInput = int.TryParse(Console.ReadLine(), out numberOfGuesses);
            }
            return numberOfGuesses;
        }

        /**This method prints the board, using the ConsoleUtils.Screen.Clear() to clear the board every round. */
        internal void PrintBoard()
        {
            StringBuilder currentBoard = new StringBuilder(); 
            currentBoard.Append(boardHeadLine());
            for (int i = 0; i < i_NumberOfRoundPlayed; i++)
            {
                currentBoard.AppendFormat("| {0}|{1}|", m_GameBoard.Guesses.ElementAt(i).ToString(), m_GameBoard.Results.ElementAt(i).ToString()); 
                currentBoard.Append(Environment.NewLine);
               
                currentBoard.Append(lineSpacing());
            }
            for (int i = 0; i < r_NumberOfGuesses - i_NumberOfRoundPlayed; i++)
            {
                currentBoard.Append(emptyLine());
                currentBoard.Append(lineSpacing());
            }

            currentBoard.Append(Environment.NewLine);
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(currentBoard.ToString());
        }

        /**This method prints the board headline. */
        private string boardHeadLine() 
        {
            StringBuilder headLine = new StringBuilder(); 
            headLine.AppendFormat("Current board status: {0} {0}", Environment.NewLine); 
            headLine.Append("|Pins:");
            int LengthOfCell = r_LengthOfSequence * 2 + 1 - 5;
            for (int i = 0; i < LengthOfCell; i++)
            {
                headLine.Append(" ");
            }
            headLine.Append("|Result:"); 
            for (int i = 0; i < r_LengthOfSequence * 2 - 1 - 7; i++)
            {
                headLine.Append(" ");
            }
            headLine.Append("|");
            headLine.Append(Environment.NewLine);
            headLine.Append(lineSpacing());
            headLine.Append("| ");
            for (int i = 0; i < r_LengthOfSequence; i++)
            {
                headLine.Append("# ");
            }
            headLine.Append("|");
            for (int i = 0; i < r_LengthOfSequence * 2 - 1; i++)
            {
                headLine.Append(" ");
            }
            headLine.Append("|");
            headLine.Append(Environment.NewLine);
            headLine.Append(lineSpacing());

            return headLine.ToString();
        }

        /**This method creates line spaces for within the board. */
        private string lineSpacing() 
        {
            StringBuilder lineSpace = new StringBuilder(); 
            lineSpace.Append("|");
            for (int i = 0; i < r_LengthOfSequence * 2 + 1; i++)
            {
                lineSpace.Append("=");
            }
            lineSpace.Append("|");
            for (int i = 0; i < r_LengthOfSequence * 2 - 1; i++)
            {
                lineSpace.Append("=");
            }
            lineSpace.Append("|");
            lineSpace.Append(Environment.NewLine);
            return lineSpace.ToString();
        }

        /**This method creates empty lines within the board. */
        private string emptyLine() 
        {
            StringBuilder emptyLine = new StringBuilder(); 
            emptyLine.Append("|");
            for (int i = 0; i < r_LengthOfSequence * 2 + 1; i++)
            {
                emptyLine.Append(" ");
            }
            emptyLine.Append("|");
            for (int i = 0; i < r_LengthOfSequence * 2 - 1; i++)
            {
                emptyLine.Append(" ");
            }
            emptyLine.Append("|");
            emptyLine.Append(Environment.NewLine);
            return emptyLine.ToString();
        }

        /** This method handles every user request and input, dealing with quitting to updating the rounds played.
            @param i_GameBoard current game board
            @param i_PlayerWantToPlay boolean varible represnting if the player wants to continue playing. */
        internal bool ReceiveAction( Board i_GameBoard, ref bool i_PlayerWantToPlay)
        {
            string UserInput = this.getUserInput();
            if (UserInput != "Q")
            {
                Sequence userSequence = new Sequence(r_LengthOfSequence);
                userSequence.GetUserGuess(UserInput);
                i_GameBoard.Guesses.Add(userSequence);
                Results UserResult = new Results(r_LengthOfSequence);
                UserResult.CalculateResult(userSequence, i_GameBoard.ComputerSequence);
                i_GameBoard.Results.Add(UserResult);
                i_GameBoard.IsWon = (UserResult.Bulls == 4);
                i_NumberOfRoundPlayed++;
            }
            else
            {
                i_PlayerWantToPlay = false;
            }
            if (i_GameBoard.IsWon)
            {
                this.PrintBoard();
                Console.WriteLine("You guessed after " + i_NumberOfRoundPlayed + " steps!");

            }
            return i_GameBoard.IsWon;
        }

        /**This method asks the user if they want to play another game and returns the boolean variable. */
        internal bool AnotherGame()
        {
            Console.WriteLine("Would you like to start a new game? <Y/N>");
            char UserDecision = receiveYOrN();
            return (UserDecision == 'Y');
        }

        /**This method parses the user input to a Yes or No */
        private char receiveYOrN()
        {
            string inputFromUser = Console.ReadLine();
            while (inputFromUser != "Y" && inputFromUser != "N")
            {
                Console.WriteLine("Ileagal entry! Please type in 'Y' for Yes and 'N' for No.");
                inputFromUser = Console.ReadLine();
            }
            return char.Parse(inputFromUser);
        }

        /**This method prints out the necessary message informing the user the game is lost. */
        internal void GameLost()
        {
            Console.WriteLine("No more guesses allowed. You Lost.");
        }

        /**This method asks the user for a guess and keep's asking until in a case where the input is invalid. */
        private string getUserInput()
        {
            string UserInput = "";

            do
            {

                Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
                UserInput = Console.ReadLine();

            } while ((!this.isSyntaxValidated(UserInput)) | (!this.isLogicValidated(UserInput)));

            return UserInput;
        }

        /**This method checks the userInput to see that it meets the necessary syntax requirements.
         * @param i_UserInput the user guess conole input.*/
        private bool isSyntaxValidated(string i_UserInput)
        {
            bool SyntaxValidation = true;
            if (i_UserInput.Length != ((r_LengthOfSequence * 2) - 1))
            {
                SyntaxValidation = false;
            }
            for (int i = 0; i < r_LengthOfSequence; i++)
            {
                if (i_UserInput.Length < r_LengthOfSequence * 2 - 1)
                {
                    break;
                }
                char Letter = i_UserInput.ElementAt(i * 2);
                if(!Char.IsUpper(Letter))
                {
                    SyntaxValidation = false;
                }
            }
            if (i_UserInput == "Q")
            {
                SyntaxValidation = true;
            }
            if (!SyntaxValidation)
            {

                Console.WriteLine("Invalid Syntax!");
            }

            return SyntaxValidation;
        }

        /**This method checks the userInput to see that it meets the necessary Logic requirements.
         * @param i_UserInput the user guess conole input.*/
        private bool isLogicValidated(string i_UserInput)
        {
            bool LogicValidation = true;
            char Letter = ' ';
            string SubUserString = "";
            for (int i = 0; i < r_LengthOfSequence; i++)
            {
                 if (i_UserInput.Length < r_LengthOfSequence * 2 - 1)
                {
                    break;
                }
                Letter = i_UserInput.ElementAt(i * 2);
                SubUserString = i_UserInput.Substring(i * 2 + 1);
                if (SubUserString.Contains(Letter))
                {
                    LogicValidation = false;
                }
                if (Char.ToUpper(Letter) < 'A' || Char.ToUpper(Letter) > 'H')
                {
                    LogicValidation = false;
                }
            }
            if (i_UserInput == "Q")
            {
                LogicValidation = true;
            }

            if (!LogicValidation)
            {

                Console.WriteLine("Invalid Logic!");
            }
            return LogicValidation;

        }
    }
}
