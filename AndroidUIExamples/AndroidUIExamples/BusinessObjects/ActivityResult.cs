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
	public static class ActivityResult
	{
		private static Dictionary<Guid,Object> _objects = new Dictionary<Guid,Object> ();

		public static Guid GetKey(){
			return Guid.NewGuid ();
		}

		public static void SetResult(Guid key,Object obj){
			_objects.Add (key, obj);
		}

		public static Object GetResult(Guid key){
			return _objects.ContainsKey (key) ? _objects [key] : null;
		}
	}
}

