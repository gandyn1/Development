using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace AndroidUIExamples
{
	[Activity (Label = "AndroidUIExamples", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;
		private List<Person> _people = new List<Person> ();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			Button btnAddPerson = FindViewById<Button> (Resource.Id.Main_btnAddPerson);

			btnAddPerson.Click += delegate {
				int key = new Random().Next(9999999);
				//_people.Add(ActivityResult.GetResult<Person>(key));
			};

			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};
		}
	}
}


