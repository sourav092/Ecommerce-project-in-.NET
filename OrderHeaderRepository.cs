﻿using Ecomm_Project_11.DataAccess.Repository.IRepository;
using Ecomm_Project_11.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_Ecomm_Project_11.Data;

namespace Ecomm_Project_11.DataAccess.Repository
{
    public class OrderHeaderRepository:Repository<OrderHeader>,IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderHeaderRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
    }
}
