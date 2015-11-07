
namespace ListViewBasic
{
	public class Personnage
	{
		public string Name{ get; }

		public string Image{ get; }

		public string Description{ get; }

		public Personnage (string Name, string Image, string Description)
		{
			this.Name = Name;
			this.Image = Image;
			this.Description = Description;

		}
	}

}

