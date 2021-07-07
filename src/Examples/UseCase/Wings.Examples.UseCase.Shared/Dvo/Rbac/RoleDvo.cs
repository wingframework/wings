using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wings.Examples.UseCase.Shared.Attributes;
using Wings.Framework.Shared.Attributes;
using Wings.Framework.Shared.Attributes.ViewAttributes;
using Wings.Framework.Shared.Dtos;
using Wings.Framework.Shared.Dtos.Admin;

namespace Wings.Examples.UseCase.Shared.Dvo
{
    public class RolePage : PageDesign
    {


        public override PageData Design()
        {
            return SetPageTitle("角色管理")
                    .SetPageLink("/rbac/role2")
                  .SetMainView<RoleListView>()
                  .SetCreateViewType<RoleListView>()
                  .SetCreateViewTabs(ManyToMany<MenuListDvo>(nameof(RoleListView.Menus), "角色菜单"), ManyToMany<PermissionListDvo>(nameof(RoleListView.Permissions), "角色权限"))
                  .SetUpdateViewTabs(ManyToMany<MenuListDvo>(nameof(RoleListView.Menus), "角色菜单"), ManyToMany<PermissionListDvo>(nameof(RoleListView.Permissions), "角色权限"))
                  .SetUpdateViewType<RoleListView>()
                  .SetDetailViewType<RoleListView>()
                  .SetDetailViewTabs(ManyToMany<MenuListDvo>(nameof(RoleListView.Menus), "角色菜单"), ManyToMany<PermissionListDvo>(nameof(RoleListView.Permissions), "角色权限"))
                  .Commit();
        }
    }



    [SearchBar(typeof(RoleListSearchBar))]
    [DataSource("/api/RoleView")]
    [TablePage("角色管理")]
    [Display(Name = "角色管理")]
    public class RoleListView
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

    public class RoleListSearchBar
    {
        [Display(Name = "角色名")]
        [Where(WhereCondition.Contains)]
        public string Name { get; set; }
        [Display(Name = "角色代码")]
        [Where(WhereCondition.Contains)]
        public string Code { get; set; }
        [Display(Name = "创建时间")]
        public DateRange CreateDateBetween
        {
            get { return new DateRange(CreateAtStart, CreateAtEnd); }
            set { CreateAtStart = value.Start; CreateAtEnd = value.End; }
        }
        [Ignore]
        [Where(WhereCondition.GreatThen, nameof(RoleListDvo.CreateAt))]
        public DateTime? CreateAtStart { get; set; }
        [Ignore]
        [Where(WhereCondition.LessThen, nameof(RoleListDvo.CreateAt))]
        public DateTime? CreateAtEnd { get; set; }
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