using DominCore.Constants;
using DominCore.IServices;
using Microsoft.AspNetCore.Mvc;
using Web.ERP.Languages;

namespace Web.ERP.Controllers
{
    public class AccountsController : Controller
    {

        private readonly IServices<RoleModel> _servicesRole;
        private readonly ResourceWebServices _Loc;
        public AccountsController(IServices<RoleModel> servicesRoleModel, ResourceWebServices loc)
        {
            _servicesRole = servicesRoleModel;
            _Loc = loc;
        }
        public async Task<IActionResult> Roles()
        {
            return View(new RoleViewModel
            {
                Roles = await _servicesRole.GetAll(),
                NewRole = new RoleModel()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SavRole(RoleViewModel model)
        {
            if (!ModelState.IsValid)
                return NotFound();
            //save
            if(model.NewRole.RoleId is null)
            {
                if (await _servicesRole.RoleExistsAsync(model.NewRole))
                {
                    SessionMsg(Helper.Error, _Loc["lbNot.RoleExists"]);
                    return RedirectToAction(nameof(Roles));
                }
                if (await _servicesRole.Save(model.NewRole))
                    SessionMsg(Helper.Success, _Loc["lb.Accounts.Roles.Saved"]);
                else
                    SessionMsg(Helper.Error,_Loc["lbNotSaved.GroupRole"]);
            }

            else //Edit
            {
                if (await _servicesRole.Save(model.NewRole))
                    SessionMsg(Helper.Success , _Loc["lbUpdate.GroupRole"]);
                else
                    SessionMsg(Helper.Error , _Loc["lbNotUpdate.GroupRole"]);
            }
            return RedirectToAction(nameof(Roles));


        }
        public async Task<IActionResult> DeleteRole(string Id)
        {
            if (await _servicesRole.Delete(Id))
                return RedirectToAction(nameof(Roles));
            return RedirectToAction(nameof(Roles));
        }
        public async Task<IActionResult> DeleteRoleSelected(List<string> Selected )
        {
            if (Selected.Count()>0)
            
                foreach (var item in Selected)
                    await _servicesRole.Delete(item);
             return RedirectToAction(nameof(Roles));
            
        }
        private void SessionMsg(string MsgType,string Msg)
        {
            HttpContext.Session.SetString(Helper.msgType, MsgType);
            HttpContext.Session.SetString(Helper.msg, Msg);
        }


    }
}
