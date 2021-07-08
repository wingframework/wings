using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Wings.Examples.UseCase.Shared.Attributes;
using Wings.Framework.Shared.Dtos.Admin;

namespace Wings.Examples.UseCase.Client.Pages.Developer.interfaceCodePage.CodeGenerator
{
    public class FormViewCodeGenerator
    {
        public PageData PageData { get; set; }

      



        public string GetCreateView()
        {
            if (PageData.CreateViewTabs != null)
            {
                if (PageData.CreateViewTabs.Count > 0)
                {
                    return GetCreateTabsViewCode();
                }
            }
            return GetCreateFormViewCode();


        }

        public string GetCreateFormViewCode()
        {
            return @$"<AntDynamicForm mode=""modal"" TModel=""{PageData.CreateViewType.Name}"" @ref=""createForm"" OnSubmit=""async () =>{{await createForm.InsertAsync();await table.Load(); }}""></AntDynamicForm>";
        }
        public bool IsCreateTabs()
        {
            if (PageData.CreateViewTabs != null)
            {
                if (PageData.CreateViewTabs.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetUpdateView()
        {
            if (PageData.UpdateViewTabs != null)
            {
                if (PageData.UpdateViewTabs.Count > 0)
                {
                    return GetUpdateTabsViewCode();
                }
            }
            return GetUpdateFormViewCode();


        }

        public bool IsUpdateTabs()
        {
            if (PageData.UpdateViewTabs != null)
            {
                if (PageData.UpdateViewTabs.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetUpdateFormViewCode()
        {
            return @$"<AntDynamicForm mode=""modal"" TModel=""{PageData.UpdateViewType.Name}"" @ref=""updateForm"" OnSubmit=""async () =>{{await updateForm.InsertAsync();await table.Load(); }}""></AntDynamicForm>";
        }
        public string GetCreateTabsViewCode()
        {
            var createTabs = PageData.CreateViewTabs;
            return @$"
@if(CreateData!=null)
{{

    <Modal Visible=""CreateData!=null"" Width=""900"" Title=""添加角色"" OnOk=""HandleOk"" OnCancel=""()=>{{CreateData = null;}}"">
        <Tabs>
            <TabPane Key=""1"">
                <Tab>基本信息</Tab>
                <ChildContent>
                    <AntDynamicForm TModel=""{PageData.CreateViewType.Name}"" Value=""CreateData""></AntDynamicForm>
                </ChildContent>
            </TabPane>
{string.Join('\n', createTabs.Select(tab => GetSubCreateTable(tab))) }
           
        </Tabs>

    </Modal>
}}";
        }

        public string GetSubCreateTable(TabConfig tab)
        {
            return @$"
<TabPane Key=""{tab.Title}"">
  <Tab>{tab.Title}</Tab>
<ChildContent>
{GetSubTablCreateCode(tab)}
   
</ChildContent>
</TabPane>
";
        }


        public string GetUpdateTabsViewCode()
        {
            var updateTabs = PageData.UpdateViewTabs;
            return @$"
@if(EditData!=null)
{{

    <Modal Visible=""EditData!=null"" Width=""900"" Title=""编辑角色"" OnOk=""HandleOk"" OnCancel=""()=>{{EditData = null;}}"">
        <Tabs>
            <TabPane Key=""1"">
                <Tab>基本信息</Tab>
                <ChildContent>
                    <AntDynamicForm TModel=""{PageData.UpdateViewType.Name}"" Value=""EditData""></AntDynamicForm>
                </ChildContent>
            </TabPane>
{string.Join('\n', updateTabs.Select(tab => GetSubUpdateTable(tab))) }
        </Tabs>

    </Modal>
}}";
        }
        public string GetSubTablCreateCode(TabConfig tab)
        {
            if (!IsTableType(tab.ModelType))
            {
                return @$"<AntTreeView Checkable=""true"" @bind-CheckedNodes=""CreateData.{tab.PropertyName}"" TModel=""{tab.ModelType.Name}""></AntTreeView>";
            }
            else
            {
                return @$"<AntTableView  @bind-CheckedNodes=""CreateData.{tab.PropertyName}"" TModel=""{tab.ModelType.Name}""></AntTableView>";
            }
        }


        public string GetSubUpdateTable(TabConfig tab)
        {
            return @$"
<TabPane Key=""{tab.Title}"">
  <Tab>{tab.Title}</Tab>
<ChildContent>
//GetSubTableUpdateCode(tab)}}
   
</ChildContent>
</TabPane>
";
        }

        public bool IsTableType(Type type)
        {
            return type.GetCustomAttribute<TablePageAttribute>(true) != null;
        }


    }
}
