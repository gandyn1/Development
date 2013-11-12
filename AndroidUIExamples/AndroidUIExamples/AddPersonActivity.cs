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

namespace AndroidUIExamples
{
	[Activity (Label = "PersonActivity")]			
	public class AddPersonActivity : Activity
	{
		private EditText _name, _dateOfBirth, _weight;
		private Button _save, _cancel;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.AddPerson);

			_name = FindViewById<EditText> (Resource.Id.AddPerson_Name);
			_dateOfBirth = FindViewById<EditText> (Resource.Id.AddPerson_DOB);
			_weight = FindViewById<EditText> (Resource.Id.AddPerson_Weight);
			_save = FindViewById<Button> (Resource.Id.AddPerson_btnSave);
			_cancel = FindViewById<Button> (Resource.Id.AddPerson_btnCancel);

			_save.Click += delegate {



				Finish();
			};

			_cancel.Click += delegate {
				Intent returnIntent = new Intent();
				SetResult(Result.Canceled, returnIntent);        
				Finish();
			};
		}
	}
}

