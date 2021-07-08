using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wings.Examples.UseCase.Shared.Dto;
using Wings.Framework.Shared.Attributes;
using Wings.Framework.Shared.Attributes.FieldAttributes;
using Wings.Framework.Shared.Dtos;
using Wings.Framework.Shared.Dtos.Admin;

namespace Wings.Examples.UseCase.Shared.Dto.Admin
{
    public class RbacCategory : PageDesign
    {
        public override PageData Design()
        {
            return SetMainViewName(MainViewName.AntTreeView)
            .SetPageTitle("分类管理")
            .SetPageLink("/rbac/category2")
            .SetMainView<CategoryListDvo>()
            .SetCreateViewType<CategoryListDvo>()
            .SetUpdateViewType<CategoryListDvo>()
            .SetDetailViewType<CategoryListDvo>()
            .Commit();
        }
    }
    [DataSource("/api/Category")]

    public class CategoryListDvo : BasicTree<CategoryListDvo>
    {
        [FormField(Edit = false, Span = 12)]
        public int Id { get; set; }

        [FormField(Span = 12)]
        [Display(Name = "封面描述")]
        public string FrontDesc { get; set; }
        [FormField(Edit = false, Span = 12)]
        [Display(Name = "上级id")]
        public int? ParentId { get; set; } = 0;
        [Display(Name = "排序")]
        [FormField(Span = 12)]
        public int SortOrder { get; set; }
        [Display(Name = "显示下标")]
        [FormField(Span = 12)]
        public int ShowIndex { get; set; }

        [FormField(Span = 12)]
        [Display(Name = "是否展示")]
        public bool IsShow { get; set; }

        [FormFieldUploadImage(Span = 12)]
        [Display(Name = "预览图片")]
        public string BannerUrl { get; set; }

        [FormField(Span = 12)]
        [Display(Name = "图标")]
        public string IconUrl { get; set; }

        [FormField(Span = 12)]
        [Display(Name = "图片")]
        public string ImgUrl { get; set; }

        [FormField(Span = 12)]
        [Display(Name = "网页横幅地址")]
        public string WapBannerUrl { get; set; }

        [FormField(Span = 12)]
        [Display(Name = "等级")]
        public string Level { get; set; }

        [FormField(Span = 12)]
        [Display(Name = "类型")]
        public int Type { get; set; }
        [FormField(Span = 12)]
        [Display(Name = "封面名字")]
        public string FrontName { get; set; }

        [FormField(Span = 12)]
        [Display(Name = "树路径")]
        public string TreePath { get; set; }

        [FormField(Span = 12)]
        [Display(Name = "标题")]

        public string Title { get; set; }
        [Ignore]
        public List<CategoryListDvo> Children { get; set; }
    }

    public class CategoryCreateDvo
    {

    }
    public class CategoryUpdateDvo
    {

    }
}

