﻿using Ecomm_Project_11.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_Ecomm_Project_11.Data;

namespace Ecomm_Project_11.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
                _context = context;
            Category = new CategoryRepository(_context);
            CoverType = new CoverTypeRepository(_context);
            Product=new ProductRepository(_context);
            SPCall = new SPCall(_context);
            Company = new CompanyRepository(_context);
            ApplicationUser = new ApplicationUserRepository(_context);
            ShoppingCart= new ShoppingCartRepository(_context);
            OrderHeader= new OrderHeaderRepository(_context);
            OrderDetails= new OrderDetailsRepository(_context);
        }
        public ICategoryRepository Category { private set; get;  }

        public ICoverTypeRepository CoverType { private set; get; }
        public ISPCall SPCall { private set; get; }
        public IProductRepository Product { private set; get; }
        public ICompanyRepository Company {private set; get;  }
        public IApplicationUserRepository ApplicationUser { private set; get; }
        public IShoppingCartRepository ShoppingCart { private set; get; }
        public IOrderHeaderRepository OrderHeader { private set; get; }
        public IOrderDetailsRepository OrderDetails { private set; get; }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
