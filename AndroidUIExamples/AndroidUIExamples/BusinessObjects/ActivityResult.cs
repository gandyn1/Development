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
		private static Dictionary<int,Object> _objects = new Dictionary<int,Object> ();

		public static void SetResult(int key,Object obj){
			_objects.Add (key, obj);
		}

		public static Object GetResult<TData>(int key){

			Object obj = null;

			if (_objects.ContainsKey (key)) {
				obj = _objects [key];
				_objects.Remove (key);
			}

			return (TData) obj;
		}
	}
}

