using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wings.Framework.Shared.Dtos.Admin;

namespace Wings.Examples.UseCase.Client.Pages.Developer.interfaceCodePage.CodeGenerator
{
    public class TreeViewCodeGeneratorService
    {
        public PageData PageData { get; set; }
        public TabsViewCodeGeneratorService tabsViewCodeGenerator { get; set; }

        public TreeViewCodeGeneratorService(TabsViewCodeGeneratorService _tabsViewCodeGeneratorService)
        {
            tabsViewCodeGenerator = _tabsViewCodeGeneratorService;

        }

        public string GetImportCode()
        {
            return @"
@page ""{PageData.PageLink}""
@namespace Wings.Examples.UseCase.Client.Pages
@inject HttpClient HttpClient
@inject ModalService _modalService
@inject IMapper mapper
";

        }

        public string GetSourceCode()
        {
            return $@"{GetImportCode() }

<DataSourceManager TModel=""{PageData.MainViewType.Name}"" @ref=""DataSource""> </DataSourceManager>

    ";
        }


        public string GetMainViewCode()
        {
            return @$"<Row Gutter=""16"">
    <Col Span=""8"">
<AntTreeView TModel=""{PageData.MainViewType.Name}"" @bind-SelectedData=""SelectedData"" @ref=""table""></AntTreeView>

</Col>
    <Col Span=""12"" Push=""2"">
   
  @if(SelectedData != null)
    {{
        <div>
            <Button Type=""primary"" Size=""small"" OnClick=""() => createForm.ShowModal(new {PageData.CreateViewType.Name} {{ ParentId = SelectedData.ParentId }})"">添加同级</Button>
            <Button Type=""primary"" Size=""small"" OnClick=""() => createForm.ShowModal(new {PageData.CreateViewType.Name} {{ ParentId = SelectedData.Id }})"">添加下级</Button>
            <Button Type=""primary"" Size=""small"" OnClick=""() => updateForm.ShowModal(mapper.Map<{PageData.MainViewType.Name},{PageData.UpdateViewType.Name}>(SelectedData))"">编辑</Button>
            <Button Type=""danger"" Size=""small"" OnClick=""OpenDeleteConfirmModal"" Disabled=""SelectedData == null"">删除</Button>
        </div>

    <Tabs>
        <TabPane Key=""1"">
            <Tab>基本信息</Tab>
            <ChildContent>
                <AntDetailView TModel=""{PageData.DetailViewType.Name}"" Value=""mapper.Map<{PageData.MainViewType.Name},{PageData.DetailViewType.Name}>(SelectedData)""></AntDetailView>
            </ChildContent>
        </TabPane>
    
      {tabsViewCodeGenerator.GetAllDetailTabCodes()}

    </Tabs>


   
        }}
   </Col>
</Row>";
        }
    }
}
