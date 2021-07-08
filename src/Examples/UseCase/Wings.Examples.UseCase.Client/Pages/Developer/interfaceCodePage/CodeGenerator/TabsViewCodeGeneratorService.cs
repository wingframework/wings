using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Wings.Examples.UseCase.Shared.Attributes;
using Wings.Framework.Shared.Dtos.Admin;

namespace Wings.Examples.UseCase.Client.Pages.Developer.interfaceCodePage.CodeGenerator
{
    public class TabsViewCodeGeneratorService
    {
        public PageData PageData { get; set; }
        public string GetAllDetailTabCodes()
        {
            if (PageData.DetailViewTabs != null)
            {
                if (PageData.DetailViewTabs.Count > 0)
                {
                    return string.Join('\n', PageData.DetailViewTabs.Select(tab => GetSubDetailTable(tab)));
                }
            }

            return "";

        }

        public string GetSubDetailTable(TabConfig tab)
        {

            return @$"
<TabPane Key=""{tab.Title}"">
  <Tab>{tab.Title}</Tab>
<ChildContent>

{GetSubDetailTableCode(tab)}
   
</ChildContent>
</TabPane>
";
        }

        public string GetSubDetailTableCode(TabConfig tab)
        {
            if (!IsTableType(tab.ModelType))
            {
                return @$"<AntTreeView  DataListTItem=""SelectedData.{tab.PropertyName}"" TModel=""{tab.ModelType.Name}""></AntTreeView>";
            }
            else
            {
                return @$"<AntTableView  DataListTItem=""SelectedData.{tab.PropertyName}"" TModel=""{tab.ModelType.Name}""></AntTableView>";
            }
        }


        public bool IsTableType(Type type)
        {
            return type.GetCustomAttribute<TablePageAttribute>(true) != null;
        }

    }
}
