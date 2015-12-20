using System;
using Xamarin.Forms;
using Android.Widget;
using System.Collections.Generic;
using Xamarin.Forms.Platform.Android;

using CustomPiker.Droid;

[assembly: ExportRenderer (typeof(Picker), typeof(CustomPickerRenderer))]
namespace CustomPiker.Droid
{
	public class CustomPickerRenderer : ViewRenderer<Picker,Spinner>
	{
		Picker picker;

		protected override void OnElementChanged (ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement != null || Element == null) {
				return;
			}
			picker = e.NewElement;
			IList<string> scaleNames = e.NewElement.Items;
			Spinner spinner = new Spinner (this.Context);

			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);

			var scaleAdapter = new  ArrayAdapter<string> (this.Context, Android.Resource.Layout.SimpleSpinnerItem, scaleNames);

			scaleAdapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);

			spinner.Adapter = scaleAdapter;

			base.SetNativeControl (spinner);
		}

		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			picker.SelectedIndex = (e.Position);
		}
	}
}