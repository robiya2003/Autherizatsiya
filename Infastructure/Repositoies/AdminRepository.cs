using Application.IRepositories;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositoies
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public AdminModel CreateAdmin(AdminModel adminModel)
        {
            var entiry=_context.admins.Add(adminModel);
            _context.SaveChanges();
            return entiry.Entity;
        }

        public AdminModel DeleteAdminNameAndPassword(AdminLogIn adminLogIn)
        {
            var entiry=_context.admins.Remove(_context.admins.FirstOrDefault(x=>x.Password==adminLogIn.Password && x.Adminname==adminLogIn.Adminname));

            _context.SaveChanges();
            return entiry.Entity;
        }

        public AdminLogIn EnterAdmin(AdminLogIn adminLogIn)
        {
            var entiry = _context.admins.
                FirstOrDefault(x => x.Password==adminLogIn.Password 
                && x.Adminname==adminLogIn.Adminname);
            _context.SaveChanges();
            return adminLogIn;

        }

        public AdminModel GetByAdminNameAndPassword(AdminLogIn adminLogIn)
        {
            var entiry = _context.admins.
                FirstOrDefault(x => x.Password == adminLogIn.Password
                && x.Adminname == adminLogIn.Adminname);
            _context.SaveChanges();
            return entiry;
        }

        public AdminModel UpdateAdmin(string username, string password, AdminModel adminModel)
        {
            var model = _context.admins.FirstOrDefault
                (x => x.Password==password && x.Adminname == username);
            model.Id = adminModel.Id;
            model.Password = password;
            model.Adminname = adminModel.Adminname;
            model.FullName = adminModel.FullName;
            model.PhoneNumber = adminModel.PhoneNumber;
            model.Gmail = adminModel.Gmail;
            model.Address = adminModel.Address;
            _context.SaveChanges();
            return model;
        }
    }
}
