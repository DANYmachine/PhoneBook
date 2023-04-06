namespace PhoneBook.Controllers.Interfaces
{
    public interface IBaseController<TbModel>
    {
        public List<TbModel> Get();
        public TbModel Get(Guid id);
        public List<TbModel> Get(string query);
        public TbModel Post(TbModel model);
        public TbModel Put(TbModel model);
        public void Delete(Guid id);
    }
}
