using System;
using SystemZarządzaniaKolekcjonerstwem;
using System.Collections.ObjectModel;

namespace SystemZarządzaniaKolekcjonerstwem.Models
{
	public class UserCollectionListHandler
	{
		public ObservableCollection<UserCollection> userCollectionList { get; set; } = new ObservableCollection<UserCollection>();
		public ObservableCollection<CollectionKinds> collectionKinds { get; set; } = new ObservableCollection<CollectionKinds>();
		public FileHandler fileHandling { get; set; } = new FileHandler();

		public UserCollectionListHandler()
		{
			fileHandling.ReadingFile(userCollectionList);

            foreach(var item in userCollectionList)
            {
                bool noItems = false;

                if(item.Title == "")
                {
                    noItems = true;
                }

                IsKindInCollection(item.Kind, noItems);
            }
		}

        public void IsKindInCollection(string kind, bool noItems)
        {

            var colKindOrNull = collectionKinds.Where(item => item.Kind == kind).SingleOrDefault();

            if (colKindOrNull == null)
            {
                int appear = 1;

                if (noItems)
                {
                    appear = 0;
                }

                collectionKinds.Add(new CollectionKinds { Kind = kind, Appears = appear });
            }
            else
            {
                int index = collectionKinds.IndexOf(colKindOrNull);
                collectionKinds.ElementAt(index).Appears++;
            }
        }

        public void AddNewCollection(UserCollection content)
		{		
            IsKindInCollection(content.Kind, true);
            AddNewItem(content, true);
		}

        public int GetIndex(string kind)
        {
            int i = collectionKinds.IndexOf(collectionKinds.Where(item => item.Kind == kind).FirstOrDefault());
            return i;
        }

        public void AddNewItem(UserCollection content, bool newKind = false)
        {
            userCollectionList.Add(content);

            if(newKind == false)
            {
                collectionKinds[GetIndex(content.Kind)].Appears++;
            }
            
            fileHandling.SavingFile(userCollectionList);
        }

        public void DeleteItem(UserCollection content, string additionalColumn)
        {
            userCollectionList.Remove(content);
            int index = GetIndex(content.Kind);
            collectionKinds[index].Appears--;

            if(additionalColumn != "")
            {
                int i = userCollectionList.IndexOf(userCollectionList.Where(item => item.Kind == content.Kind).FirstOrDefault());
                userCollectionList[i].AdditionalName = additionalColumn;
            }

            fileHandling.SavingFile(userCollectionList);
        }

        public void DeleteItemCollectionKinds(CollectionKinds content)
        {
            collectionKinds.Remove(content);

            var itemsFromCollection = userCollectionList.Where(item => item.Kind == content.Kind).ToList();

            foreach (UserCollection item in itemsFromCollection)
            {
                userCollectionList.Remove(item);
            }

            fileHandling.SavingFile(userCollectionList);
        }

        public void ChangeItem()
        {
            fileHandling.SavingFile(userCollectionList);
        }

        public void NewCollectionColumnAdd(string kind, string additionalName)
        {
            foreach(var item in userCollectionList)
            {
                if(item.Kind == kind)
                {
                    item.AdditionalName = additionalName;
                }
            }

            fileHandling.SavingFile(userCollectionList);
        }
	}
}

