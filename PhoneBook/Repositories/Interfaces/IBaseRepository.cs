using PhoneBook.Models;

namespace PhoneBook.Repositories.Interfaces
{
    public interface IBaseRepository<TDbModel>
    {
        public List<TDbModel> Get();
        public TDbModel GetById(long id);
        public List<TDbModel> GetByQuery(string query);        
        public long Create(TDbModel model);
        public TDbModel Update(TDbModel model);
        public void Delete(long id);
    }
}
