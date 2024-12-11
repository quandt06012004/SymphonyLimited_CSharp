using Data_DAL;
using Data_DAL.Data;
using Microsoft.EntityFrameworkCore;
using Services.IRepositoryMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Services
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _dataContext;

        public ContactRepository(DataContext dataContext) 
        {
            this._dataContext = dataContext;
        }
        public async Task<bool> Create(ContactUs data)
        {
            try
            {
                // Thêm đối tượng vào DbContext
                await this._dataContext.AddAsync(data);

                // Lưu thay đổi vào cơ sở dữ liệu
                await this._dataContext.SaveChangesAsync();

                return true; // Thành công
            }
            catch (Exception)
            {
                // Xử lý lỗi nếu có (có thể ghi log tại đây)
                return false; // Thất bại
            }

        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                // Tìm đối tượng cần xóa
                var contact = await this._dataContext.ContactUs.FindAsync(id);
                if (contact == null) return false;

                // Xóa đối tượng
                this._dataContext.ContactUs.Remove(contact);
                await this._dataContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                // Xử lý lỗi nếu có
                return false;
            }
        }

        public async Task<IPagedList<ContactUs>> GetAll(int page)
        {
            const int PageSize = 10; // Số lượng bản ghi trên mỗi trang
            try
            {
                // Truy vấn và sử dụng ToPagedList
                return await this._dataContext.ContactUs
                    .OrderBy(c => c.ContactID) // Sắp xếp theo Id hoặc một thuộc tính khác
                    .ToPagedListAsync(page, PageSize);
            }
            catch (Exception)
            {
                // Trả về danh sách phân trang rỗng nếu lỗi
                return new PagedList<ContactUs>(Enumerable.Empty<ContactUs>(), page, PageSize);
            }
        }

        public async Task<List<ContactUs>> GetAllOf()
        {
            try
            {
                return await this._dataContext.ContactUs.ToListAsync();
            }
            catch (Exception)
            {
                return new List<ContactUs>(); // Trả về danh sách rỗng nếu lỗi
            }
        }

        public async Task<ContactUs> GetById(int id)
        {
            try
            {
                return await this._dataContext.ContactUs.FindAsync(id);
            }
            catch (Exception)
            {
                return null; // Trả về null nếu lỗi
            }
        }

        public async Task<bool> Update(int id, ContactUs data)
        {
            try
            {
                // Tìm đối tượng cần cập nhật
                var contact = await this._dataContext.ContactUs.FindAsync(id);
                if (contact == null) return false;

                // Cập nhật thông tin
                contact.BranchName = data.BranchName; // Cập nhật từng thuộc tính
                contact.Address = data.Address;
                contact.Phone = data.Phone;
                contact.Email = data.Email;
                // ... cập nhật thêm các thuộc tính khác nếu có

                // Lưu thay đổi
                await this._dataContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
