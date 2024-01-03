using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharp_csv
{
	internal class CSV
	{
		private StringBuilder _sb;
		private string[] _enTete;
		private IDonnee[] _iDonnee;
		private string _cheminSortie;

		public CSV(string[] enTete, IDonnee[] iDonnee, string cheminSortie)
        {
			_enTete = enTete;
			_iDonnee = iDonnee;
			_cheminSortie = cheminSortie;
			_sb = new StringBuilder();
        }

		public async Task Demarrer()
		{
			CreerLigneEntete();
			AjouterLignesDonnees();
			await CreerFichierCSV();
		}

		private void CreerLigneEntete()
		{
			int longueurEntete = _enTete.Length;
			for (int i = 0; i < longueurEntete; i++)
			{
				_sb.Append(_enTete[i]);
				if (i < longueurEntete - 1)
				{
					_sb.Append(';');
				}
			}

			StringBuilderAjouterRetourLigne();
		}

		private void StringBuilderAjouterRetourLigne()
		{
			_sb.Append(Environment.NewLine);
		}

		private void AjouterLignesDonnees()
		{
			for (int i = 0; i < _iDonnee.Length; i++)
			{
				string[] valeurs = _iDonnee[i].ValeursCSV();

				int nbreValeurs = valeurs.Length;
				StringBuilder format = new ();
				for (int j = 0; j < nbreValeurs; j++)
				{
					format.Append('{');
					format.Append(j);
					format.Append('}');
					if (j < nbreValeurs - 1)
					{
						format.Append(';');
					}
				}

				string ligne = string.Format(format.ToString(), valeurs);

				_sb.Append(ligne);

				StringBuilderAjouterRetourLigne();
			}
		}


		private async Task CreerFichierCSV()
		{
			FileStream fichier = File.Create(_cheminSortie);

			using (StreamWriter writer = new(fichier, Encoding.UTF8))
			{
				await writer.WriteAsync(_sb.ToString());
			}
		}
	}
}
