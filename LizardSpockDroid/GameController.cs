using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LizardSpockDroid
{
    public class GameController
    {
        public int HumanScore { get; private set; }
        public int ComputerScore { get; private set;}
        public int WinnerIndex { get; private set; }
        public enum Options {Rock=0, Paper=1, Scissors=2, Lizard=3, Spock=4 }
        public List<GameCombination> GameCombinations = new List<GameCombination>();
        public GameController()
        {
            HumanScore = 0;
            ComputerScore = 0;
            BuildGameCombinations();
        }

        public void ResetGame(string HumanName)
        {
            SaveScore(HumanScore, ComputerScore, HumanName);
            HumanScore = 0;
            ComputerScore = 0;
            WinnerIndex = -9;
        }

        public int HumanTurn(int Choice)
        {
            int ComputerChoice = ComputerTurn();
            WinnerIndex = -9;
            WinnerIndex = DetermineHumanWinner(Choice, ComputerChoice);
            if (WinnerIndex < 0)
                WinnerIndex = DetermineComputerWinner(Choice, ComputerChoice);
            return ComputerChoice;
        }

        private int DetermineHumanWinner(int HumanChoice, int ComputerChoice)
        {
            int winnerIndex = GameCombinations.FindIndex(g => g.WinnerChoice == HumanChoice && g.LooserChoice == ComputerChoice);
            if (winnerIndex >= 0)
                HumanScore++;
            return winnerIndex;
        }

        private int DetermineComputerWinner(int HumanChoice, int ComputerChoice)
        {
            int winnerIndex = GameCombinations.FindIndex(g => g.WinnerChoice == ComputerChoice && g.LooserChoice == HumanChoice);
            if (winnerIndex >= 0)
                ComputerScore++;
            return winnerIndex;
        }

        private int ComputerTurn()
        {
            Random r = new Random();
            return r.Next(0, 4);
        }

        private void BuildGameCombinations()
        {
            GameCombinations.Add(new GameCombination() { WinnerChoice = 0, LooserChoice = 2, WinnerDescription = "Rock crushes Scissors" });
            GameCombinations.Add(new GameCombination() { WinnerChoice = 0, LooserChoice = 3, WinnerDescription = "Rock crushes Lizard" });
            GameCombinations.Add(new GameCombination() { WinnerChoice = 1, LooserChoice = 0, WinnerDescription = "Paper covers Rock" });
            GameCombinations.Add(new GameCombination() { WinnerChoice = 1, LooserChoice = 4, WinnerDescription = "Paper disproves Spock" });
            GameCombinations.Add(new GameCombination() { WinnerChoice = 2, LooserChoice = 1, WinnerDescription = "Scissors cut Paper" });
            GameCombinations.Add(new GameCombination() { WinnerChoice = 2, LooserChoice = 3, WinnerDescription = "Scissors decapitate Lizard" });
            GameCombinations.Add(new GameCombination() { WinnerChoice = 3, LooserChoice = 1, WinnerDescription = "Lizard eats Paper" });
            GameCombinations.Add(new GameCombination() { WinnerChoice = 3, LooserChoice = 4, WinnerDescription = "Lizard poisons Spock" });
            GameCombinations.Add(new GameCombination() { WinnerChoice = 4, LooserChoice = 2, WinnerDescription = "Spock smashes Scissors" });
            GameCombinations.Add(new GameCombination() { WinnerChoice = 4, LooserChoice = 0, WinnerDescription = "Spock vaporises Rock" });
        }

        private void SaveScore(int HumanScore, int ComputerScore, string HumanName)
        {
            int newHiScore = 0;
            string WinnerName = DateTime.Now.ToString();
            if (HumanScore > ComputerScore)
            { 
                newHiScore = HumanScore;
                WinnerName = HumanName;
            }
            else if (HumanScore < ComputerScore)
                newHiScore = ComputerScore;

            if (newHiScore>0)
            {
                HiScores hiScores = new HiScores();
                hiScores.AddScore(WinnerName, newHiScore);
                hiScores = null;
            }
        }
    }
}
