using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageCore.Enums;

namespace StorageCore
{
    public class Storage<T> where T : TextPaper
    {
        private List<T> _storage;
        private IRepository _repository;


        public Storage(RepositoryTypeEnum repositoryType)
        {
            _storage = new List<T>();

            switch (repositoryType)
            {
                case RepositoryTypeEnum.TxtRepository:
                    _repository = new TxtRepository();
                    break;
                case RepositoryTypeEnum.XMLRepository:
                    _repository = new XMLRepository(typeof(T));
                    break;
                case RepositoryTypeEnum.SQLRepository:
                    _repository = new SQLRepository();
                    break;
            }
            LoadFromRepository();
        }

        public List<T> GetStorage()
        {
            return _storage;
        }

        public void AddItem(T item)
        {
            _storage.Add(item);
        }

        public T GetById(int bookId)
        {
            return _storage[bookId];
        }

        public void DeleteById(int bookId)
        {
            _storage.RemoveAt(bookId);
        }

        public void SaveToRepository()
        {
            _repository.Put<T>(_storage);
        }

        public void LoadFromRepository()
        {
            _storage = _repository.Get<T>();
        }
    }
}
