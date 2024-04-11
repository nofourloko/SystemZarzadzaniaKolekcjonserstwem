using System;
using System.Collections.ObjectModel;
using SystemZarządzaniaKolekcjonerstwem.Models;

namespace SystemZarządzaniaKolekcjonerstwem
{
	public class FileHandler
	{
		public string filePath { get; set; } = Path.Combine(FileSystem.Current.AppDataDirectory, "Collections.txt");

		public void ReadingFile(ObservableCollection<UserCollection> userCollectionList)
		{
            Console.WriteLine($"------------------------------");
            Console.WriteLine($"Path for the file: {filePath}");
            Console.WriteLine($"------------------------------");

            try
			{
				if (!File.Exists(filePath))
				{
					File.Create(filePath).Close();
                    Console.WriteLine("File was created");
                    return;
				}

				StreamReader reader = new StreamReader(filePath);
				string line;

				while ((line = reader.ReadLine()) != null)
				{
					string[] lineSplited = line.Split('/');
					string kind = lineSplited[0];
					string title = lineSplited[1];
					string additionalName = lineSplited[5];
					string additionalValue = lineSplited[6];

                    int rate = 0;

                    int price = 0;

					if(title != null)
					{
						if (Int32.TryParse(lineSplited[3], out int valPrice)) price = valPrice;
						if (Int32.TryParse(lineSplited[4], out int valRate)) rate = valRate;

						UserCollection collection = new UserCollection
						{
							Kind = kind,
							Title = title,
							Status = lineSplited[2],
							Price = price,
							Rate = rate,
							AdditionalName = additionalName,
							AdditionalValue = additionalValue
                        };

						userCollectionList.Add(collection);
					}

				}

			}
			catch (Exception error)
			{
				Console.WriteLine($"Problem accured during file reading : {error}");
				throw error;

            }
		}

		public void SavingFile(ObservableCollection<UserCollection> userCollectionsList)
		{
			try
			{
				List<string> content = new List<string>();

				foreach(UserCollection item in userCollectionsList)
				{
					content.Add($"{item.Kind}/{item.Title}/{item.Status}/{item.Price}/{item.Rate}/{item.AdditionalName}/{item.AdditionalValue}");
				}

				File.WriteAllLines(filePath, content);
			}
			catch(Exception error)
			{
                Console.WriteLine($"Problem accured during file saving : {error}");
                throw error;
            }
		}
	}
}

