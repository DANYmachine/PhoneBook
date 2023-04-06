using PhoneBook.Models;

namespace PhoneBook.Repositories.Interfaces
{
    public interface IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        public List<TDbModel> Get();
        public TDbModel GetById(Guid id);
        public List<TDbModel> GetByQuery(string query);
        public TDbModel Create(TDbModel model);
        public TDbModel Update(TDbModel model);
        public void Delete(Guid id);
    }
}
