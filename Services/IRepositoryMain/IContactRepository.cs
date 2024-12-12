using Data_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Services.IRepositoryMain
{
    public interface IContactRepository
    {
        Task<List<ContactUs>> GetAllOf();
        Task<IPagedList<ContactUs>> GetAll(int page);
        Task<ContactUs> GetById(int id);
        Task<bool> Create(ContactUs data);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, ContactUs data);
    }
}
