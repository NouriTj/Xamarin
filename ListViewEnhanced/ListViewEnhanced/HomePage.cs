using Xamarin.Forms;

namespace ListViewEnhanced
{
	public class HomePage:ContentPage
	{
		public HomePage ()
		{
			// Les données avec lesquels on va remplir notre ListView
			//On distribue nos données dans des groupes selon un critère de notre choix.
			//1er groupe
			GroupFamily groupStark = new GroupFamily ("Stark");
			groupStark.Add (new Personnage ("Eddard Stark", "ned.png", "Eddard Stark, surnommé Ned, est le gouverneur du Nord et seigneur de Winterfell."));
			groupStark.Add (new Personnage ("Catelyn Stark Tully", "catelyn.png", "Lady Catelyn Stark, née Tully, est l'épouse de lord Eddard Stark avec qui elle a cinq enfants."));
			groupStark.Add (new Personnage ("Robb Stark", "robb.png", "Robb Stark est le fils ainé de lord Eddard Stark et de lady Catelyn Stark et est donc l'héritier de Winterfell et du Nord."));

			//2ème groupe
			GroupFamily groupLannister = new GroupFamily ("Lannister");
			groupLannister.Add (new Personnage ("Tyrion Lannister", "tayron.png", "Tyrion Lannister, surnommé le Lutin, le Nain, le Gnome ou encore le Mi-homme."));
			groupLannister.Add (new Personnage ("Jaime Lannister", "jaime.png", "Jaime Lannister, surnommé le Régicide, partageant une attirance réciproque pour sa sœur jumelle Cersei depuis leur plus tendre enfance."));
			groupLannister.Add (new Personnage ("Cersei Lannister", "cersei.png", "Cersei Lannister, femme très ambitieuse et réputée pour sa beauté, elle supporte mal les restrictions que lui impose son sexe et n'a que du mépris pour son mari."));

			//3ème groupe
			GroupFamily groupTargaryen = new GroupFamily ("Targaryen");
			groupTargaryen.Add (new Personnage ("Daenerys Targaryen", "daenerys.png", "Daenerys Targaryen, surnommé la mère des dragons , elle est la fille légitime du roi Aerys II Targaryen et de la reine Rhaella Targaryen."));
			groupTargaryen.Add (new Personnage ("Viserys Targaryen,", "viserys.png", "Viserys Targaryen,est un jeune homme cruel et vain qui veut à tout prix reconquérir le trône de ses ancêtres."));

			//tableau contenant les groupes créés
			GroupFamily[] gotFamilies = new GroupFamily[] {
				groupStark, groupLannister, groupTargaryen
			};
			//On créé un template pour notre ListaView & et on fait buinding 
			//entre l'objet Personnage et ImageCell
			DataTemplate dataTemplate = new DataTemplate (typeof(ImageCell));
			dataTemplate.SetBinding (ImageCell.TextProperty, "Name");
			dataTemplate.SetBinding (ImageCell.ImageSourceProperty, "Image");
			dataTemplate.SetBinding (ImageCell.DetailProperty, "Description");

			//Création de la ListView
			ListView listView = new ListView {
				ItemsSource = gotFamilies,//affectation des données
				IsGroupingEnabled = true,//Important: activation du groupement des données
				GroupDisplayBinding = new Binding ("FamilyName"),//faire le binding avec GroupFamily pour afficher l'entête correspondante
				ItemTemplate = dataTemplate,//affection du template de la liste
				RowHeight = 50,//fixation de la hauteur d'une cellule de la liste
			};

			//calcul du nombre des éléments de la liste
			int gotFalmiliesCount = 0;
			foreach (var familiy in gotFamilies) {
				gotFalmiliesCount += familiy.Count + 1;//le +1 est pour compter l'entête du groupe aussi ;)
			}
			//astuce: on fixe la taille d'une ligne de la ListView puis on réserve l'espace	nécessaire
			//pour afficher la totalité de la liste et elle ne soit pas tronqué
			listView.HeightRequest = listView.RowHeight * gotFalmiliesCount + 10;//padding de 10

			//On ourvre une nouvelle page lors du click sur un élément de la liste
			listView.ItemSelected += (sende, e) => Navigation.PushAsync (new DetailPage ((Personnage)e.SelectedItem));

			//titre de la page
			Title = "Game Of Thrones";
			Content = new ScrollView { 
				//padding gauche,haut,droite,bas
				Padding = new Thickness (10, 0, 10, 0),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Content = listView
			};
		}
	}
}

