using System.Collections.Generic;
using Xamarin.Forms;

namespace ListViewBasic
{
	public class HomePage:ContentPage
	{
		public HomePage ()
		{
			//un tableau de personnage
			Personnage[] personnage = new Personnage[] {
				new Personnage ("Eddard Stark", "ned.png", "Eddard Stark, surnommé Ned, est le gouverneur du Nord et seigneur de Winterfell."),
				new Personnage ("Catelyn Stark Tully", "catelyn.png", "Lady Catelyn Stark, née Tully, est l'épouse de lord Eddard Stark avec qui elle a cinq enfants."),
				new Personnage ("Robb Stark", "robb.png", "Robb Stark est le fils ainé de lord Eddard Stark et de lady Catelyn Stark et est donc l'héritier de Winterfell et du Nord."),
				new Personnage ("Sansa Stark", "sansa.png", "Sansa Stark est le second enfant d'Eddard Stark et de Catelyn Stark."),
				new Personnage ("Arya Stark", "arya.png", "Arya Stark est le troisième enfant d'Eddard Stark et de Catelyn Stark."),
				new Personnage ("Bran Stark", "bran.png", "Brandon Stark dit Bran Stark est le quatrième enfant d'Eddard Stark et de Catelyn Stark."),
				new Personnage ("Rickon Stark", "rickon.png", "Rickon Stark est le plus jeune fils de lord Eddard Stark et de lady Catelyn Stark"),
				new Personnage ("Jon Snow", "jon.png", "Il est le fils illégitime de lord Eddard Stark et d'une femme inconnue.")
			};

			// Les données avec lesquels on va remplir notre ListView
			List<Personnage> listSource = new List<Personnage> ();
			foreach (var stark in personnage) {
				listSource.Add (stark);
			}

			//On créé un template pour notre ListaView & et on fait buinding 
			//entre l'objet Personnage et ImageCell
			DataTemplate dataTemplate = new DataTemplate (typeof(ImageCell));
			dataTemplate.SetBinding (ImageCell.TextProperty, "Name");
			dataTemplate.SetBinding (ImageCell.ImageSourceProperty, "Image");
			dataTemplate.SetBinding (ImageCell.DetailProperty, "Description");

			//Création de la ListView & affectation des données
			ListView listView = new ListView ();
			listView.ItemsSource = listSource;
			listView.ItemTemplate = dataTemplate;
			//astuce: on fixe la taille d'une ligne de la ListView puis on réserve l'espace	nécessaire
			//pour afficher la totalité de la liste et elle ne soit pas tronqué
			listView.RowHeight = 60;
			listView.HeightRequest = listView.RowHeight * listSource.Count + 10;//padding de 10

			//On ourvre une nouvelle page lors du click sur un élément de la liste
			listView.ItemSelected += (sende, e) => Navigation.PushAsync (new DetailPage ((Personnage)e.SelectedItem));

			Title = "La Maison Stark";

			StackLayout stackLayout = new StackLayout {
				//padding gauche,haut,droite,bas
				Padding = new Thickness (10, 0, 10, 0),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = { listView }
			};
			Content = new ScrollView{ Content = stackLayout };
		}
	}
}

