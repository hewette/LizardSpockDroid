using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LizardSpockDroid
{
    [Activity(Label = "HiScore", MainLauncher = false, Icon = "@drawable/icon")]
    public class HiScoreView : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            HiScores hiScores = new HiScores();
            List<string> allScores = hiScores.GetAllScores();
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, allScores);
            hiScores = null;
            Button btnClearAll = FindViewById<Button>(Resource.Id.btnClearAll);
            btnClearAll.Click += delegate { btnClearAllClick(); };

        }

        private void btnClearAllClick()
        {
            HiScores hiScores = new HiScores();
            hiScores.DeleteAllScores();
            hiScores = null;

        }
    }
}