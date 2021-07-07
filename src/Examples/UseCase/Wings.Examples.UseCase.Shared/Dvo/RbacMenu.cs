using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wings.Examples.UseCase.Shared.Attributes;
using Wings.Framework.Shared.Attributes;
using Wings.Framework.Shared.Dtos;
using Wings.Framework.Shared.Dtos.Admin;


namespace Wings.Examples.UseCase.Shared.Dvo
{
    /// <summary>
    /// 公开声明一个  菜单页 的类，然后继承 页面设计 这个类
    /// 公开（声明）一个覆盖 页面数据 设计
    /// 返回 设置主要的主视图名称（主要主视图名称.ant树形视图) 
    /// 设置页面标题（菜单管理）
    /// 设置页面链接（/rbac/menu2）   rbac:基于角色权限控制
    /// 设置主要的视图<菜单列表Dvo>()
    /// 设置创建视图类型<菜单创建Dvo>()
    /// 设置更新视图类型<菜单创建Dvo>()
    /// 设置详情视图类型<菜单列表Dvo>()
    /// 提交
    /// </summary>
    public class MenuPage : PageDesign
    {
        public override PageData Design()
        {
            return SetMainViewName(MainViewName.AntTreeView)
            .SetPageTitle("菜单管理")
            .SetPageLink("/rbac/menu2")
            .SetMainView<MenuListDvo>()
            .SetCreateViewType<MenuCreateDvo>()
            .SetUpdateViewType<MenuUpdateDvo>()
            .SetDetailViewType<MenuListDvo>()
            .Commit();
        }
    }

    /// <summary>
    /// 接口  [数据来源("/api/menu",)]
    /// 公开声明一个  菜单列表Dvo 的类，然后继承 基本树<菜单列表Dvo> 这个类   basic：基本
    /// 公开声明一个列表<菜单列表Dvo> 类型的 小孩（下级） = 新的表<菜单列表Dvo>();
    /// </summary>

    [AutoMapper.AutoMap(typeof(MenuCreateDvo), ReverseMap = true)]
    [AutoMapper.AutoMap(typeof(MenuUpdateDvo), ReverseMap = true)]
    //[AutoMapper.AutoMap(typeof(MenuDetailDvo), ReverseMap = true)]

    [DataSource("/api/menu")]
    public class MenuListDvo : BasicTree<MenuListDvo>
    {
        public int Id { get; set; }
        [Display(Name = "排序")]
       
        public int Order { get; set; }
        [Display(Name = "菜单编码")]

        public string Code { get; set; }
        [Display(Name = "地址")]

        public string Url { get; set; }
        [Display(Name = "树路径")]

        /// <summary>
        /// 菜单的树路径
        /// </summary>
        /// <value></value>
        public string TreePath { get; set; }
        [Display(Name = "上级id")]

        public int? ParentId { get; set; }
        [Display(Name = "创建时间")]

        public DateTime CreateAt { get; set; } = DateTime.Now;
        [Display(Name = "最后时间")]

        public DateTime LastUpdateAt { get; set; } = DateTime.Now;
        [Display(Name = "图标")]

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        [Display(Name = "菜单管理")]

        public string Title { get; set; }
        public List<MenuListDvo> Children { get; set; }
    }

    [DataSource("/api/menu")]
    public class MenuCreateDvo
    {
        public int Id { get; set; }
        [Display(Name = "排序")]
        public int Order { get; set; }
        [Display(Name = "菜单编码")]
        [Required]
        [StringLength(10,MinimumLength =1)]
        public string Code { get; set; }
        [Display(Name = "地址")]

        public string Url { get; set; }
        [Display(Name = "树路径")]

        /// <summary>
        /// 菜单的树路径
        /// </summary>
        /// <value></value>
        public string TreePath { get; set; }
        [Display(Name = "上级id")]

        public int? ParentId { get; set; }

        [Display(Name = "图标")]

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        [Display(Name = "菜单管理")]

        public string Title { get; set; }
    }
    [DataSource("/api/menu")]
    public class MenuUpdateDvo
    {
        public int Id { get; set; }
        [Display(Name = "排序")]
        public int Order { get; set; }

        [Display(Name = "地址")]

        public string Url { get; set; }
        [Display(Name = "树路径")]

        /// <summary>
        /// 菜单的树路径
        /// </summary>
        /// <value></value>
        public string TreePath { get; set; }
        [Display(Name = "上级id")]

        public int? ParentId { get; set; }

        [Display(Name = "图标")]

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        [Display(Name = "菜单管理")]

        public string Title { get; set; }
    }




}