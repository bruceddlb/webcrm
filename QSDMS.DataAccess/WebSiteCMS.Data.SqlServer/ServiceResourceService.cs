using QSDMS.Util;
using QSDMS.Util.WebControl;
using WebSiteCMS.Data.IServices;
using WebSiteCMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WebSiteCMS.Data.SqlServer
{

    /// <summary>
    /// 服务团队资源
    /// </summary>
    public class ServiceResourceService : BaseSqlDataService, IServiceResourceService<ServiceResourceEntity, ServiceResourceEntity, Pagination>
    {
        public int QueryCount(ServiceResourceEntity para)
        {
            throw new NotImplementedException();
        }

        public List<ServiceResourceEntity> GetPageList(ServiceResourceEntity para, ref Pagination pagination)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_ServiceResource");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(pagination.sidx))
            {
                sql.AppendFormat(" order by {0} {1}", pagination.sidx, pagination.sord);
            }
            var currentpage = tbl_ServiceResource.Page(pagination.page, pagination.rows, sql.ToString());
            //数据对象
            var pageList = currentpage.Items;
            //分页对象
            pagination.records = Converter.ParseInt32(currentpage.TotalItems);
            return EntityConvertTools.CopyToList<tbl_ServiceResource, ServiceResourceEntity>(pageList.ToList());
        }

        public List<ServiceResourceEntity> GetList(ServiceResourceEntity para)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_ServiceResource");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            var list = tbl_ServiceResource.Query(sql.ToString());
            return EntityConvertTools.CopyToList<tbl_ServiceResource, ServiceResourceEntity>(list.ToList());
        }

        public ServiceResourceEntity GetEntity(string keyValue)
        {
            var model = tbl_ServiceResource.SingleOrDefault("where ServiceResourceId=@0", keyValue);
            return EntityConvertTools.CopyToModel<tbl_ServiceResource, ServiceResourceEntity>(model, null);
        }

        public bool Add(ServiceResourceEntity entity)
        {
            var model = EntityConvertTools.CopyToModel<ServiceResourceEntity, tbl_ServiceResource>(entity, null);
            model.Insert();
            return true;
        }

        public bool Update(ServiceResourceEntity entity)
        {

            var model = tbl_ServiceResource.SingleOrDefault("where ServiceResourceId=@0", entity.ServiceResourceId);
            model = EntityConvertTools.CopyToModel<ServiceResourceEntity, tbl_ServiceResource>(entity, model);
            int count = model.Update();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string keyValue)
        {
            int count = tbl_ServiceResource.Delete("where ServiceResourceId=@0", keyValue);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public string ConverPara(ServiceResourceEntity para)
        {
            StringBuilder sbWhere = new StringBuilder();

            if (para == null)
            {
                return sbWhere.ToString();
            }

            if (para.LanguageKey != null)
            {
                sbWhere.AppendFormat(" and LanguageKey='{0}'", para.LanguageKey);
            }
            if (para.ClassId != null)
            {
                sbWhere.AppendFormat(" and ClassId='{0}'", para.ClassId);
            }
            return sbWhere.ToString();
        }
    }
}
