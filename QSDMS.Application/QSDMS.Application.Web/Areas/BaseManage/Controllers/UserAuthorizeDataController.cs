using QSDMS.Application.Web.Controllers;
using QSDMS.Business;
using QSDMS.Model;
using QSDMS.Util.WebControl;
using RCHL.Business;
using RCHL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QSDMS.Application.Web.Areas.BaseManage.Controllers
{
    public class UserAuthorizeDataController : BaseController
    {
       
        private UserAuthorizeBLL userAuthorize = new UserAuthorizeBLL();

        

    }

    /// <summary>
    /// 机构对象 驾校 年检机构
    /// </summary>
    public class AuthorizeOrganizeEntity
    {
        public string ObjectId { get; set; }
        public string ObjectName { get; set; }
        public int ObjectType { get; set; }
        public string ParentId { get; set; }
        public int Level { get; set; }
    }
}
