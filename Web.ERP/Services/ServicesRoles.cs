using DominCore.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web.ERP.ViewModels;

namespace Web.ERP.Services
{
    public class ServicesRoles : IServices<RoleModel>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public ServicesRoles(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
       
        public async Task<bool> Delete(string Id)
        {
            try
            {
                var Result =await _roleManager.Roles.FirstOrDefaultAsync(r=>r.Id.Equals(Id));
                if (Result is null) return false;
                if((await _roleManager.DeleteAsync(Result)).Succeeded) return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RoleModel> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoleModel>> GetAll()
        {
            try
            {
                var roles = await _roleManager.Roles.ToListAsync();
                if (roles is null)
                    return null;
                return _mapper.Map<List<RoleModel>>(roles) ;
            }//Mapping between role model and identity model 
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> RoleExistsAsync(RoleModel entity)
        {
            if (await _roleManager.RoleExistsAsync(entity.RoleName)) 
                return true;
            return false;
        }
        public async Task<bool> Save(RoleModel entity)
        {
            try
            {
                if (entity is null) return false;
                if(entity.RoleId is null)//save
                {
                   
                    entity.RoleId = Guid.NewGuid().ToString();
                    var Result = _mapper.Map(entity, new IdentityRole());//3mlt mapping 
                    var role = await _roleManager.CreateAsync(Result);//hna 3mlt create 
                    if (role.Succeeded)
                        return true;
                    return false;
                }
                else//edit
                {
                    var RoleUpdate = await _roleManager.FindByIdAsync(entity.RoleId);
                    if (RoleUpdate is null) return false;
                    
                    RoleUpdate=_mapper.Map(entity,RoleUpdate);

                    var role = await _roleManager.UpdateAsync(RoleUpdate);
                    if (role.Succeeded) return true;
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Task<bool> IServices<RoleModel>.RoleExistsAsync(RoleModel entity)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IServices<RoleModel>.Delete(string Id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
