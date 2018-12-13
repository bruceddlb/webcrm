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
    /// 意见管理
    /// </summary>
    public class SiteService : BaseSqlDataService, ISiteService<SiteEntity, SiteEntity, Pagination>
    {
        public int QueryCount(SiteEntity para)
        {
            throw new NotImplementedException();
        }

        public List<SiteEntity> GetPageList(SiteEntity para, ref Pagination pagination)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_Site");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(pagination.sidx))
            {
                sql.AppendFormat(" order by {0} {1}", pagination.sidx, pagination.sord);
            }
            var currentpage = tbl_Site.Page(pagination.page, pagination.rows, sql.ToString());
            //数据对象
            var pageList = currentpage.Items;
            //分页对象
            pagination.records = Converter.ParseInt32(currentpage.TotalItems);
            return EntityConvertTools.CopyToList<tbl_Site, SiteEntity>(pageList.ToList());
        }

        public List<SiteEntity> GetList(SiteEntity para)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_Site");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            var list = tbl_Site.Query(sql.ToString());
            return EntityConvertTools.CopyToList<tbl_Site, SiteEntity>(list.ToList());
        }

        public SiteEntity GetEntity(string keyValue)
        {
            var model = tbl_Site.SingleOrDefault("where SiteId=@0", keyValue);
            return EntityConvertTools.CopyToModel<tbl_Site, SiteEntity>(model, null);
        }

        public bool Add(SiteEntity entity)
        {
            var model = EntityConvertTools.CopyToModel<SiteEntity, tbl_Site>(entity, null);
            model.Insert();
            return true;
        }

        public bool Update(SiteEntity entity)
        {

            var model = tbl_Site.SingleOrDefault("where SiteId=@0", entity.SiteId);
            model = EntityConvertTools.CopyToModel<SiteEntity, tbl_Site>(entity, model);
            int count = model.Update();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string keyValue)
        {
            int count = tbl_Site.Delete("where SiteId=@0", keyValue);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public string ConverPara(SiteEntity para)
        {
            StringBuilder sbWhere = new StringBuilder();

            if (para == null)
            {
                return sbWhere.ToString();
            }
           
            return sbWhere.ToString();
        }
    }
}
