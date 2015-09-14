using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManager.Web.Models
{
    public enum JsonTypeEnym
    {
        Redirect,
        AsynData,
        Reload
    }

    public enum RoleEnum
    {
        经销商用户=1,
        公司大区经理=2,
        公司业务员=3,
        客户=4,
        内勤人员
    }

}