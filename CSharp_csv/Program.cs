using System.Diagnostics;

namespace CSharp_csv
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Trace.WriteLine("Début programme.");

			// Préparation des données

			string[] enTete = new[]
			{
				"Colonne 1",
				"Col 2",
				"Autre donnée",
				"Date du jour"
			};

			Donnee[] donnees = new[]
			{
				new Donnee()
				{
					Entier = -1,
					Chaine = "Hélow",
					Booleen = true,
					DateJour = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.FFF"),
				},
				new Donnee()
				{
					Entier = 999,
					Chaine = "é'(-@çÂ $ù ぶらぼう !",
					Booleen = false,
					DateJour = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.FFF"),
				}
			};

			string cheminSortie = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"test_{DateTime.Now.ToString("yyyy-MM-dd_mmssfff")}.csv");

			Trace.WriteLine(cheminSortie);

			// Génération

			CSV genererCSV = new (enTete, donnees, cheminSortie);
			ContinuerSynchrone(genererCSV.Demarrer());
		}

		private static void ContinuerSynchrone(Task tache)
		{
			tache.GetAwaiter().OnCompleted(() =>
			{
				Trace.WriteLine("Génération terminée.");
			});
		}
	}
}
