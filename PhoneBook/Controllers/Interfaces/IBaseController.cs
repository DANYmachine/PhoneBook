namespace PhoneBook.Controllers.Interfaces
{
    public interface IBaseController<TbModel>
    {
        public List<TbModel> Get();
        public TbModel Get(long id);
        public List<TbModel> Get(string query);
        public long Post(TbModel model);
        public TbModel Put(TbModel model);
        public void Delete(long id);
    }
}
