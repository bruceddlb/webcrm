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
    /// 语言
    /// </summary>
    public class LanguageInfoService : BaseSqlDataService, ILanguageInfoService<LanguageInfoEntity, LanguageInfoEntity, Pagination>
    {
        public int QueryCount(LanguageInfoEntity para)
        {
            throw new NotImplementedException();
        }

        public List<LanguageInfoEntity> GetPageList(LanguageInfoEntity para, ref Pagination pagination)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_LanguageInfo");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(pagination.sidx))
            {
                sql.AppendFormat(" order by {0} {1}", pagination.sidx, pagination.sord);
            }
            var currentpage = tbl_LanguageInfo.Page(pagination.page, pagination.rows, sql.ToString());
            //数据对象
            var pageList = currentpage.Items;
            //分页对象
            pagination.records = Converter.ParseInt32(currentpage.TotalItems);
            return EntityConvertTools.CopyToList<tbl_LanguageInfo, LanguageInfoEntity>(pageList.ToList());
        }

        public List<LanguageInfoEntity> GetList(LanguageInfoEntity para)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_LanguageInfo");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            var list = tbl_LanguageInfo.Query(sql.ToString());
            return EntityConvertTools.CopyToList<tbl_LanguageInfo, LanguageInfoEntity>(list.ToList());
        }

        public LanguageInfoEntity GetEntity(string keyValue)
        {
            var model = tbl_LanguageInfo.SingleOrDefault("where LanguageInfoId=@0", keyValue);
            return EntityConvertTools.CopyToModel<tbl_LanguageInfo, LanguageInfoEntity>(model, null);
        }

        public bool Add(LanguageInfoEntity entity)
        {
            var model = EntityConvertTools.CopyToModel<LanguageInfoEntity, tbl_LanguageInfo>(entity, null);
            model.Insert();
            return true;
        }

        public bool Update(LanguageInfoEntity entity)
        {

            var model = tbl_LanguageInfo.SingleOrDefault("where LanguageInfoId=@0", entity.LanguageInfoId);
            model = EntityConvertTools.CopyToModel<LanguageInfoEntity, tbl_LanguageInfo>(entity, model);
            int count = model.Update();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string keyValue)
        {
            int count = tbl_LanguageInfo.Delete("where LanguageInfoId=@0", keyValue);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public string ConverPara(LanguageInfoEntity para)
        {
            StringBuilder sbWhere = new StringBuilder();

            if (para == null)
            {
                return sbWhere.ToString();
            }
            if (para.LanguageInfoId != null)
            {
                sbWhere.AppendFormat(" and LanguageInfoId='{0}'", para.LanguageInfoId);
            }
            if (para.Name != null)
            {
                sbWhere.AppendFormat(" and Name='{0}'", para.Name);
            }
            if (para.LanguageKey != null)
            {
                sbWhere.AppendFormat(" and LanguageKey='{0}'", para.LanguageKey);
            }
            return sbWhere.ToString();
        }
    }
}
