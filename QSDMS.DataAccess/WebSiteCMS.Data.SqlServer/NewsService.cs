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
    public class NewsService : BaseSqlDataService, INewsService<NewsEntity, NewsEntity, Pagination>
    {
        public int QueryCount(NewsEntity para)
        {
            throw new NotImplementedException();
        }

        public List<NewsEntity> GetPageList(NewsEntity para, ref Pagination pagination)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_News");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(pagination.sidx))
            {
                sql.AppendFormat(" order by {0} {1}", pagination.sidx, pagination.sord);
            }
            var currentpage = tbl_News.Page(pagination.page, pagination.rows, sql.ToString());
            //数据对象
            var pageList = currentpage.Items;
            //分页对象
            pagination.records = Converter.ParseInt32(currentpage.TotalItems);
            return EntityConvertTools.CopyToList<tbl_News, NewsEntity>(pageList.ToList());
        }

        public List<NewsEntity> GetList(NewsEntity para)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_News");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            var list = tbl_News.Query(sql.ToString());
            return EntityConvertTools.CopyToList<tbl_News, NewsEntity>(list.ToList());
        }

        public NewsEntity GetEntity(string keyValue)
        {
            var model = tbl_News.SingleOrDefault("where NewsId=@0", keyValue);
            return EntityConvertTools.CopyToModel<tbl_News, NewsEntity>(model, null);
        }

        public bool Add(NewsEntity entity)
        {
            var model = EntityConvertTools.CopyToModel<NewsEntity, tbl_News>(entity, null);
            model.Insert();
            return true;
        }

        public bool Update(NewsEntity entity)
        {

            var model = tbl_News.SingleOrDefault("where NewsId=@0", entity.NewsId);
            model = EntityConvertTools.CopyToModel<NewsEntity, tbl_News>(entity, model);
            int count = model.Update();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string keyValue)
        {
            int count = tbl_News.Delete("where NewsId=@0", keyValue);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public string ConverPara(NewsEntity para)
        {
            StringBuilder sbWhere = new StringBuilder();

            if (para == null)
            {
                return sbWhere.ToString();
            }
            if (para.NewsId != null)
            {
                sbWhere.AppendFormat(" and NewsId='{0}'", para.NewsId);
            }
            if (para.Title != null)
            {
                sbWhere.AppendFormat(" and Title like '%{0}%'", para.Title);
            }
            if (para.LanguageKey != null)
            {
                sbWhere.AppendFormat(" and LanguageKey='{0}'", para.LanguageKey);
            }
            if (para.Type != null)
            {
                sbWhere.AppendFormat(" and Type='{0}'", para.Type);
            }
            return sbWhere.ToString();
        }
    }
}
