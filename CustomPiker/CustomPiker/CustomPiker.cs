using System;

using Xamarin.Forms;

namespace CustomPiker
{
	public class App : Application
	{
		public App ()
		{
			Picker pickerArrival = new Picker ();
			pickerArrival.Items.Add ("Android");
			pickerArrival.Items.Add ("iOS");
			pickerArrival.Items.Add ("Windows Phone");

			Button bt = new Button {
				Text = "Select OS",
			};

			bt.Clicked += (e, sender) => {
				Console.WriteLine ("Selected item: " + pickerArrival.Items [pickerArrival.SelectedIndex] +
				" - index: " + pickerArrival.SelectedIndex);
			};

			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						pickerArrival,
						bt
					}
				}
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

