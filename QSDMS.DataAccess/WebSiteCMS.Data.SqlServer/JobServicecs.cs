using QSDMS.Util;
using QSDMS.Util.WebControl;
using WebSiteCMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteCMS.Data.IServices;

namespace WebSiteCMS.Data.SqlServer
{
    /// <summary>
    /// 新闻管理
    /// </summary>
    public class JobService : BaseSqlDataService, IJobService<JobEntity, JobEntity, Pagination>
    {
        public int QueryCount(JobEntity para)
        {
            throw new NotImplementedException();
        }

        public List<JobEntity> GetPageList(JobEntity para, ref Pagination pagination)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_Job");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(pagination.sidx))
            {
                sql.AppendFormat(" order by {0} {1}", pagination.sidx, pagination.sord);
            }
            var currentpage = tbl_Job.Page(pagination.page, pagination.rows, sql.ToString());
            //数据对象
            var pageList = currentpage.Items;
            //分页对象
            pagination.records = Converter.ParseInt32(currentpage.TotalItems);
            return EntityConvertTools.CopyToList<tbl_Job, JobEntity>(pageList.ToList());
        }

        public List<JobEntity> GetList(JobEntity para)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_Job");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            var list = tbl_Job.Query(sql.ToString());
            return EntityConvertTools.CopyToList<tbl_Job, JobEntity>(list.ToList());
        }

        public JobEntity GetEntity(string keyValue)
        {
            var model = tbl_Job.SingleOrDefault("where JobId=@0", keyValue);
            return EntityConvertTools.CopyToModel<tbl_Job, JobEntity>(model, null);
        }

        public bool Add(JobEntity entity)
        {
            var model = EntityConvertTools.CopyToModel<JobEntity, tbl_Job>(entity, null);
            model.Insert();
            return true;
        }

        public bool Update(JobEntity entity)
        {

            var model = tbl_Job.SingleOrDefault("where JobId=@0", entity.JobId);
            model = EntityConvertTools.CopyToModel<JobEntity, tbl_Job>(entity, model);
            int count = model.Update();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string keyValue)
        {
            int count = tbl_Job.Delete("where JobId=@0", keyValue);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public string ConverPara(JobEntity para)
        {
            StringBuilder sbWhere = new StringBuilder();

            if (para == null)
            {
                return sbWhere.ToString();
            }
            if (para.JobId != null)
            {
                sbWhere.AppendFormat(" and JobId='{0}'", para.JobId);
            }
            if (para.Title != null)
            {
                sbWhere.AppendFormat(" and Title like '%{0}%'", para.Title);
            }
            if (para.LanguageKey != null)
            {
                sbWhere.AppendFormat(" and LanguageKey='{0}'", para.LanguageKey);
            }
            return sbWhere.ToString();
        }
    }
}
