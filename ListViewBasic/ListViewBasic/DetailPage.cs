using Xamarin.Forms;

namespace ListViewBasic
{
	public class DetailPage:ContentPage
	{
		public DetailPage (Personnage personnage)
		{
			Title = personnage.Name;
			Image image = new Image { Source = personnage.Image };
			Label titre = new Label { 
				Text = personnage.Name, 
				XAlign = TextAlignment.Center, 
				FontAttributes = FontAttributes.Bold 
			};
			Label description = new Label{ Text = personnage.Description };

			StackLayout stackLayout = new StackLayout {
				Padding = new Thickness (10, 0, 10, 0),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = { titre, image, description }
			};
			Content = new ScrollView{ Content = stackLayout };
		}
	}

}

