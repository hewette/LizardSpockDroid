using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LizardSpockDroid
{
    [Activity(Label = "LizardSpockDroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        GameController gameController = new GameController();
        string[] Choices = new string[] { "Rock", "Paper", "Scissors", "Lizard", "Spock", "Not Decided" };
        int ComputerChoice = 5;
        int HumanChoice = 5;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button btnReset = FindViewById<Button>(Resource.Id.btnReset);
            btnReset.Click += delegate { btnReset_Click(); };

            Button btnRock = FindViewById<Button>(Resource.Id.btnRock);
            btnRock.Click += delegate { btnRock_Click(); };

            Button btnPaper = FindViewById<Button>(Resource.Id.btnPaper);
            btnPaper.Click += delegate { btnPaper_Click(); };

            Button btnScissors = FindViewById<Button>(Resource.Id.btnScissors);
            btnScissors.Click += delegate { btnScissors_Click(); };

            Button btnLizard = FindViewById<Button>(Resource.Id.btnLizard);
            btnLizard.Click += delegate { btnLizard_Click(); };

            Button btnSpock = FindViewById<Button>(Resource.Id.btnSpock);
            btnSpock.Click += delegate { btnSpock_Click(); };

            Button btnHiScore = FindViewById<Button>(Resource.Id.btnHiScore);
            btnHiScore.Click += delegate {StartActivity(typeof(HiScoreView));};
        } 

        private void btnReset_Click()
        {
            EditText edtHumanName = FindViewById<EditText>(Resource.Id.edtName);
            gameController.ResetGame(edtHumanName.Text);
            TextView txtWinnerDesc = FindViewById<TextView>(Resource.Id.txtWinnerDesc);
            txtWinnerDesc.Text = "";
            ComputerChoice = 5;
            HumanChoice = 5;
            displayChoices();
            TextView txtAllHail = FindViewById<TextView>(Resource.Id.txtAllHail);
            edtHumanName.Text = "";
            txtAllHail.Visibility = ViewStates.Visible;
        }

        private void btnRock_Click()
        {
            HumanChoice = (int)GameController.Options.Rock;
            ComputerChoice = gameController.HumanTurn(HumanChoice);
            displayChoices();
        }

        private void btnScissors_Click()
        {
            HumanChoice = (int)GameController.Options.Scissors;
            ComputerChoice = gameController.HumanTurn(HumanChoice);
            displayChoices();
        }

        private void btnPaper_Click()
        {
            HumanChoice = (int)GameController.Options.Paper;
            ComputerChoice = gameController.HumanTurn(HumanChoice);
            displayChoices();
        }

        private void btnLizard_Click()
        {
            HumanChoice = (int)GameController.Options.Lizard;
            ComputerChoice = gameController.HumanTurn(HumanChoice);
            displayChoices();
        }

        private void btnSpock_Click()
        {
            HumanChoice = (int)GameController.Options.Spock;
            ComputerChoice = gameController.HumanTurn(HumanChoice);
            displayChoices();
        }

        private void displayChoices()
        {
            TextView txtWinnerDesc = FindViewById<TextView>(Resource.Id.txtWinnerDesc);
            TextView txtHumanScore = FindViewById<TextView>(Resource.Id.txtHumanScore);
            TextView txtComputerScore = FindViewById<TextView>(Resource.Id.txtComputerScore);
            TextView txtHumanChoice = FindViewById<TextView>(Resource.Id.txtHumanChoice);
            TextView txtComputerChoice = FindViewById<TextView>(Resource.Id.txtComputerChoice);
            TextView txtAllHail = FindViewById<TextView>(Resource.Id.txtAllHail);

            if (gameController.WinnerIndex >= 0)
            {
                txtWinnerDesc.Text = gameController.GameCombinations[gameController.WinnerIndex].WinnerDescription;
            }
            else
                txtWinnerDesc.Text = "";

            txtComputerChoice.Text = Choices[ComputerChoice];
            txtHumanChoice.Text = Choices[HumanChoice];
            txtHumanScore.Text = gameController.HumanScore.ToString();
            txtComputerScore.Text = gameController.ComputerScore.ToString();
            txtAllHail.Visibility = ViewStates.Invisible;
        }

    }
}

