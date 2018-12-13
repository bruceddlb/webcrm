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
    /// 服务团队资源分类
    /// </summary>
    public class ServiceClassService : BaseSqlDataService, IServiceClassService<ServiceClassEntity, ServiceClassEntity, Pagination>
    {
        public int QueryCount(ServiceClassEntity para)
        {
            throw new NotImplementedException();
        }

        public List<ServiceClassEntity> GetPageList(ServiceClassEntity para, ref Pagination pagination)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_ServiceClass");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(pagination.sidx))
            {
                sql.AppendFormat(" order by {0} {1}", pagination.sidx, pagination.sord);
            }
            var currentpage = tbl_ServiceClass.Page(pagination.page, pagination.rows, sql.ToString());
            //数据对象
            var pageList = currentpage.Items;
            //分页对象
            pagination.records = Converter.ParseInt32(currentpage.TotalItems);
            return EntityConvertTools.CopyToList<tbl_ServiceClass, ServiceClassEntity>(pageList.ToList());
        }

        public List<ServiceClassEntity> GetList(ServiceClassEntity para)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_ServiceClass");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            var list = tbl_ServiceClass.Query(sql.ToString());
            return EntityConvertTools.CopyToList<tbl_ServiceClass, ServiceClassEntity>(list.ToList());
        }

        public ServiceClassEntity GetEntity(string keyValue)
        {
            var model = tbl_ServiceClass.SingleOrDefault("where ServiceClassId=@0", keyValue);
            return EntityConvertTools.CopyToModel<tbl_ServiceClass, ServiceClassEntity>(model, null);
        }

        public bool Add(ServiceClassEntity entity)
        {
            var model = EntityConvertTools.CopyToModel<ServiceClassEntity, tbl_ServiceClass>(entity, null);
            model.Insert();
            return true;
        }

        public bool Update(ServiceClassEntity entity)
        {

            var model = tbl_ServiceClass.SingleOrDefault("where ServiceClassId=@0", entity.ServiceClassId);
            model = EntityConvertTools.CopyToModel<ServiceClassEntity, tbl_ServiceClass>(entity, model);
            int count = model.Update();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string keyValue)
        {
            int count = tbl_ServiceClass.Delete("where ServiceClassId=@0", keyValue);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public string ConverPara(ServiceClassEntity para)
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
            return sbWhere.ToString();
        }
    }
}
