﻿namespace Web.ERP.ViewModels
{
    public class RoleViewModel
    {
        public List<RoleModel> Roles { get; set; } = new();
        public RoleModel NewRole { get; set; } = new();
    }
    public class RoleModel
    {
        public string? RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
