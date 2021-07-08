using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wings.Examples.UseCase.Shared.Attributes;
using Wings.Framework.Shared.Attributes;
using Wings.Framework.Shared.Attributes.ViewAttributes;
using Wings.Framework.Shared.Dtos;
using Wings.Framework.Shared.Dtos.Admin;

namespace Wings.Examples.UseCase.Shared.Dto.Admin
{
    /// <summary>
    /// 声明一个类 角色页面 继承 页面设计
    /// </summary>
    public class RolePage : PageDesign
    {
        public override PageData Design()
        {
            return SetPageTitle("角色管理")
            .SetPageLink("/rbac/role2")
            .SetCreateViewType<RoleListView>()
            .SetMainView<RoleListView>()
            .SetUpdateViewType<RoleListView>()
            .SetDetailViewType<RoleListView>()
            .SetCreateViewTabs(ManyToMany<MenuListDvo>(nameof(RoleListView.Menus), "角色菜单"), ManyToMany<PermissionListDvo>("Permissions", "角色权限"))
            .SetUpdateViewTabs(ManyToMany<MenuListDvo>(nameof(RoleListView.Menus), "角色菜单"), ManyToMany<PermissionListDvo>("Permissions", "角色权限"))
            .SetDetailViewTabs(ManyToMany<MenuListDvo>(nameof(RoleListView.Menus), "角色菜单"), ManyToMany<PermissionListDvo>("Permissions", "角色权限"))
            .Commit();
        }
    }
    [DataSource("/api/roleView")]
    [SearchBar(typeof(RoleListSearchBar))]

    public class RoleListView
    {
        [Key]
        [FormField(Edit = false)]
        public int Id { get; set; }
        [Display(Name = "角色代码")]
        [Required]
        public string Code { get; set; }
        [Display(Name = "角色名")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "规范化名称")]
        [Required]
        public string NormalizedName { get; set; }
        [Ignore]
        public List<MenuListDvo> Menus { get; set; } = new List<MenuListDvo>();
        [Ignore]
        public List<PermissionListDvo> Permissions { get; set; }
    }

    public class RoleListSearchBar
    {
        [Where(WhereCondition.Contains)]
        public string Name { get; set; }

    }




    [SearchBar(typeof(RoleListSearchBar))]
    [DataSource("/api/Role")]
    [TablePage("角色管理")]
    [Display(Name = "角色管理")]
    public class RoleListDvo
    {
        [Key]
        [FormField(Edit = false)]
        public int Id { get; set; }


        [Display(Name = "角色名")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "角色代码")]
        [Required]

        public string Code { get; set; }

        [Ignore]
        [Display(Name = "创建时间")]
        public DateTime CreateAt { get; set; } = DateTime.Now;

        [Ignore]
        public List<MenuListDvo> Menus { get; set; }
        [Ignore]
        public List<PermissionListDvo> Permissions { get; set; }
    }


}