using DominCore.Constants;
using Infrastructure.BL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BL.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedFullOwnerAsync(UserManager<ApplicationUser> userManager, ApplicationDBContext context)
        {
            var branch = await context.Branches.FirstOrDefaultAsync(b => b.BranchName.Equals(Helper.MainBranch));
            if (branch is null) 
            {
                return;
            }
            // ApplicationUser user = new();
            var FullOwner = new ApplicationUser
            {
                BranchId = branch.Id,
                CompanyId = branch.CompanyId,
                FullName = Helper.FullOwner,
                Email = Helper.EmailFullOwner,
                UserName= Helper.EmailFullOwner,
                StateTypeUser= (int)Helper.estateTypeUser.FullOwner,
                CreatedOn= DateTime.Now,
                EmailConfirmed =true ,
                IsActive= true,
                ImageUser= Helper.DefaultUsers


            };


            //check if user mwgod f data base wla la 
            var user = await userManager.FindByEmailAsync(FullOwner.Email); 
            if (user is null)
            {
                var result = await userManager.CreateAsync(FullOwner,Helper.PasswordFullOwner);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(FullOwner, Helper.FullOwner);// assign only one role for every user 
                    //await userManager.AddToRolesAsync(FullOwner, new List<string> { Helper.FullOwner });// if i want to add more than one role for user 

                    //code permission 
                }
            }
        }



        public static async Task SeedOwnerCompanyAsync(UserManager<ApplicationUser> userManager, ApplicationDBContext context)
        {
            var branch = await context.Branches.FirstOrDefaultAsync(b => b.BranchName.Equals(Helper.MainBranch));
            if (branch is null) 
                return;
            
            // ApplicationUser user = new();
            var OwnerCompany = new ApplicationUser
            {
                BranchId = branch.Id,
                CompanyId = branch.CompanyId,
                FullName = Helper.OwnerCompany,//owner company
                Email = Helper.EmailOwnerCompany,//email owner company 
                UserName= Helper.EmailOwnerCompany,//owner company 
                StateTypeUser= (int)Helper.estateTypeUser.OwnerCompany,//owner company 
                CreatedOn= DateTime.Now,
                EmailConfirmed =true ,
                IsActive= true,
                ImageUser= Helper.DefaultUsers


            };


            //check if user mwgod f data base wla la 
            var user = await userManager.FindByEmailAsync(OwnerCompany.Email); 
            if (user is null)
            {
                var result = await userManager.CreateAsync(OwnerCompany, Helper.PasswordOwnerCompany);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(OwnerCompany, Helper.OwnerCompany);// assign only one role for every user 
                    //await userManager.AddToRolesAsync(FullOwner, new List<string> { Helper.FullOwner });// if i want to add more than one role for user 

                    //code permission 
                }
            }
        }

        public static async Task SeedBranchManagerAsync(UserManager<ApplicationUser> userManager, ApplicationDBContext context)
        {
            var branch = await context.Branches.FirstOrDefaultAsync(b => b.BranchName.Equals(Helper.MainBranch));
            if (branch is null)
            {
                return;
            }
            // ApplicationUser user = new();
            var BranchManager = new ApplicationUser
            {
                BranchId = branch.Id,
                CompanyId = branch.CompanyId,
                FullName = Helper.BranchManager,//Branch Manager
                Email = Helper.EmailBranchManager,//email BranchManager
                UserName = Helper.EmailBranchManager,//BranchManager
                StateTypeUser = (int)Helper.estateTypeUser.BranchManager,//BranchManager
                CreatedOn = DateTime.Now,
                EmailConfirmed = true,
                IsActive = true,
                ImageUser = Helper.DefaultUsers


            };


            //check if user mwgod f data base wla la 
            var user = await userManager.FindByEmailAsync(BranchManager.Email);
            if (user is null)
            {
                var result = await userManager.CreateAsync(BranchManager, Helper.PasswordOwnerCompany);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(BranchManager, Helper.OwnerCompany);// assign only one role for every user 
                    //await userManager.AddToRolesAsync(FullOwner, new List<string> { Helper.FullOwner });// if i want to add more than one role for user 

                    //code permission 
                }
            }
        }
    }
}
