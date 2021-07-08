using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wings.Framework.Shared.Dtos;

namespace Wings.Examples.UseCase.Shared.Dto.Admin
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Phone { get; set; }
    }
    public class UserInfoDto
    {
        public List<MenuData> MenuDataList { get; set; }
        public List<PermissionListDvo> PermissionList { get; set; }
        public UserDto User { get; set; }
    }
}
