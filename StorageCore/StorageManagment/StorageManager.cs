using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageCore.Enums;
using StorageModel;

namespace StorageCore
{
    public static class StorageManager
    {
        public static Storage<Book> BookStorage { get; set; }
        public static Storage<Jornal> JornalStorage { get; set; }
        public static Storage<NewsPaper> NewsPaperStorage { get; set; }

        static StorageManager()
        {
            BookStorage = new Storage<Book>(RepositoryTypeEnum.SQLRepository);
            NewsPaperStorage = new Storage<NewsPaper>(RepositoryTypeEnum.TxtRepository);
            JornalStorage = new Storage<Jornal>(RepositoryTypeEnum.XMLRepository);
        }

        public static void Add(TextPaper item)
        {
            if(item.GetType() == typeof(Book))
            {
                BookStorage.AddItem(item as Book);
                return;
            }

            if(item.GetType() == typeof(Jornal))
            {
                JornalStorage.AddItem(item as Jornal);
                return;
            }

            if(item.GetType() == typeof(NewsPaper))
            {
                NewsPaperStorage.AddItem(item as NewsPaper);
                return;
            }
        }

        public static TextPaper Read(PaperType paperType, int id)
        {
            switch (paperType)
            {
                case PaperType.Book:
                    return BookStorage.GetById(id) as TextPaper;
                    break;
                case PaperType.Jornal:
                    return JornalStorage.GetById(id) as TextPaper;
                    break;
                case PaperType.NewsPaper:
                    return NewsPaperStorage.GetById(id) as TextPaper;
                    break;
            }
            return null;
        }

        public static void Delete(PaperType paperType, int id)
        {
            switch (paperType)
            {
                case PaperType.Book:
                    BookStorage.DeleteById(id);
                    break;
                case PaperType.Jornal:
                    JornalStorage.DeleteById(id);
                    break;
                case PaperType.NewsPaper:
                    NewsPaperStorage.DeleteById(id);
                    break;
            }
        }

        public static void Save()
        {
            BookStorage.SaveToRepository();
            JornalStorage.SaveToRepository();
            NewsPaperStorage.SaveToRepository();
        }
    }
}
