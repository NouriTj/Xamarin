using System.Collections.ObjectModel;

namespace ListViewEnhanced
{
	public class GroupFamily:ObservableCollection<Personnage>
	{
		//attribue qui sera bindé à l'entête de notre ListView
		public string FamilyName { get; private set; }

		public GroupFamily (string FamilyName)
		{
			this.FamilyName = FamilyName;
		}
	}
}

