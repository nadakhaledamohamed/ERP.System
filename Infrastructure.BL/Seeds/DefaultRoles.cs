using DominCore.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BL.Seeds
{
    public static class DefaultRoles // static to be public without refrence 
    {
        public static async Task SeedsRolesAsync(RoleManager<IdentityRole> roleManager) ///mdam class static lazm methode gwah tkon static zyu 
        {
            //first check if there is roles or not lw mfech roles ebd2 create roles
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Helper.FullOwner));
                await roleManager.CreateAsync(new IdentityRole(Helper.OwnerCompany));
                await roleManager.CreateAsync(new IdentityRole(Helper.BranchManager));
            }
        }
    }
}
