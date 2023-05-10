using DominCore.Constants;
using Infrastructure.BL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BL.Seeds
{
    public static class DefaultData
    {
        public static void SeedCompany(ApplicationDBContext context)
        {
            context.Database.EnsureCreated();//
            //check companies to see if there is data or not
            if (context.Companies.Any())
            {
                return;
            }
            context.Companies.AddRange(new Company
            {
                CompanyName = Helper.MainCompany,
                Address = Helper.MainCompany,
                Activity="  ",
                Email = Helper.EmailMainCompany,
                Logo = Helper.LogoComapny,
                PhoneNumber = "  ",
                TaxNumber = "   ",
                CreatedOn = DateTime.Now,
                TelNumber = "   ",
            }) ;
            context.SaveChanges();
        }

        public static void SeedBranch(ApplicationDBContext context)
        {
            context.Database.EnsureCreated(); 
            if (context.Branches.Any()) 
            {
                return;
            }
            var company = context.Companies.FirstOrDefault(c=>c.CompanyName.Equals(Helper.MainCompany));//
            if (company is null)
            {
                return;
            }
            ////////////////////////////////////////////
            ///

            context.Branches.AddRange(new Branch
            {
                BranchName= Helper.MainBranch,
                CompanyId=company.Id,
                Address="",
                PhoneNumber="",
                CreatedOn=DateTime.Now,

            });
            context.SaveChanges();
        }
    }
}
