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
    /// 服务资源文章
    /// </summary>
    public class HealthAticleService : BaseSqlDataService, IHealthAticleService<HealthAticleEntity, HealthAticleEntity, Pagination>
    {
        public int QueryCount(HealthAticleEntity para)
        {
            throw new NotImplementedException();
        }

        public List<HealthAticleEntity> GetPageList(HealthAticleEntity para, ref Pagination pagination)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_HealthAticle");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(pagination.sidx))
            {
                sql.AppendFormat(" order by {0} {1}", pagination.sidx, pagination.sord);
            }
            var currentpage = tbl_HealthAticle.Page(pagination.page, pagination.rows, sql.ToString());
            //数据对象
            var pageList = currentpage.Items;
            //分页对象
            pagination.records = Converter.ParseInt32(currentpage.TotalItems);
            return EntityConvertTools.CopyToList<tbl_HealthAticle, HealthAticleEntity>(pageList.ToList());
        }

        public List<HealthAticleEntity> GetList(HealthAticleEntity para)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_HealthAticle");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            var list = tbl_HealthAticle.Query(sql.ToString());
            return EntityConvertTools.CopyToList<tbl_HealthAticle, HealthAticleEntity>(list.ToList());
        }

        public HealthAticleEntity GetEntity(string keyValue)
        {
            var model = tbl_HealthAticle.SingleOrDefault("where HealthAticleId=@0", keyValue);
            return EntityConvertTools.CopyToModel<tbl_HealthAticle, HealthAticleEntity>(model, null);
        }

        public bool Add(HealthAticleEntity entity)
        {
            var model = EntityConvertTools.CopyToModel<HealthAticleEntity, tbl_HealthAticle>(entity, null);
            model.Insert();
            return true;
        }

        public bool Update(HealthAticleEntity entity)
        {

            var model = tbl_HealthAticle.SingleOrDefault("where HealthAticleId=@0", entity.HealthAticleId);
            model = EntityConvertTools.CopyToModel<HealthAticleEntity, tbl_HealthAticle>(entity, model);
            int count = model.Update();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string keyValue)
        {
            int count = tbl_HealthAticle.Delete("where HealthAticleId=@0", keyValue);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public string ConverPara(HealthAticleEntity para)
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
            if (para.HealthClassId != null)
            {
                sbWhere.AppendFormat(" and HealthClassId='{0}'", para.HealthClassId);
            }
            return sbWhere.ToString();
        }
    }
}
