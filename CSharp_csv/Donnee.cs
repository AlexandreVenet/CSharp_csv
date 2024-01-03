using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_csv
{
	internal class Donnee : IDonnee
	{
		public int Entier { get; set; }
		public string Chaine { get; set; }
		public bool Booleen { get; set; }
		public string DateJour { get; set; }

		public string[] ValeursCSV()
		{
			return new string[]
			{
				Entier.ToString(),
				Chaine,
				Booleen.ToString(),
				DateJour,
			};
		}
	}
}
