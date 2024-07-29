﻿using Ecomm_Project_11.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using WebApplication_Ecomm_Project_11.Data;
using Ecomm_Project_11.Model;
using Ecomm_Project_11.Utility;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication_Ecomm_Project_11.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        public UserController(IUnitOfWork unitOfWork,ApplicationDbContext context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll() 
        {
            var userList = _context.ApplicationUsers.ToList();  //AspNetUsers
            var roles = _context.Roles.ToList();                //AspNetRoles
            var userRoles= _context.UserRoles.ToList();         //AspNetUserRole
            foreach(var user in userList) 
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(r=>r.Id== roleId).Name;
                if(user.CompanyId==null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
                if(user.CompanyId!=null) 
                {
                    user.Company = new Company()
                    {
                        Name = _unitOfWork.Company.Get(Convert.ToInt32(user.CompanyId)).Name
                    };
                }
            }
            //Remove admin Role User
            var adminUser = userList.FirstOrDefault(u => u.Role == SD.Role_Admin);
            userList.Remove(adminUser);
            return Json(new {data=userList });
        }
        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id)
        {
            bool isLocked = false;
            var userInDb = _context.ApplicationUsers.FirstOrDefault(u=>u.Id==id);
            if (userInDb==null)
                return Json(new {success=false,message="something went wrong while lock or unlock user !!!" });
                    if (userInDb != null && userInDb.LockoutEnd>DateTime.Now)
            {
                userInDb.LockoutEnd = DateTime.Now;
                isLocked = false;
            }
            else
            {
                userInDb.LockoutEnd = DateTime.Now.AddYears(100);
                isLocked = true;
            }
            _context.SaveChanges();
            return Json(new{success=true,message=isLocked==true ? "User Successfully Locked" : "User Successfully Unlocked" });
        }
        #endregion
    }
}
