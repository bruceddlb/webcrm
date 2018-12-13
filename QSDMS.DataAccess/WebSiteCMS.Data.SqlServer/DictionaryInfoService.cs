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
    /// 意见管理
    /// </summary>
    public class DictionaryInfoService : BaseSqlDataService, IDictionaryInfoService<DictionaryInfoEntity, DictionaryInfoEntity, Pagination>
    {
        public int QueryCount(DictionaryInfoEntity para)
        {
            throw new NotImplementedException();
        }

        public List<DictionaryInfoEntity> GetPageList(DictionaryInfoEntity para, ref Pagination pagination)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_DictionaryInfo");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(pagination.sidx))
            {
                sql.AppendFormat(" order by {0} {1}", pagination.sidx, pagination.sord);
            }
            var currentpage = tbl_DictionaryInfo.Page(pagination.page, pagination.rows, sql.ToString());
            //数据对象
            var pageList = currentpage.Items;
            //分页对象
            pagination.records = Converter.ParseInt32(currentpage.TotalItems);
            return EntityConvertTools.CopyToList<tbl_DictionaryInfo, DictionaryInfoEntity>(pageList.ToList());
        }

        public List<DictionaryInfoEntity> GetList(DictionaryInfoEntity para)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_DictionaryInfo");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            var list = tbl_DictionaryInfo.Query(sql.ToString());
            return EntityConvertTools.CopyToList<tbl_DictionaryInfo, DictionaryInfoEntity>(list.ToList());
        }

        public DictionaryInfoEntity GetEntity(string keyValue)
        {
            var model = tbl_DictionaryInfo.SingleOrDefault("where DictionaryInfoId=@0", keyValue);
            return EntityConvertTools.CopyToModel<tbl_DictionaryInfo, DictionaryInfoEntity>(model, null);
        }

        public bool Add(DictionaryInfoEntity entity)
        {
            var model = EntityConvertTools.CopyToModel<DictionaryInfoEntity, tbl_DictionaryInfo>(entity, null);
            model.Insert();
            return true;
        }

        public bool Update(DictionaryInfoEntity entity)
        {

            var model = tbl_DictionaryInfo.SingleOrDefault("where DictionaryInfoId=@0", entity.DictionaryInfoId);
            model = EntityConvertTools.CopyToModel<DictionaryInfoEntity, tbl_DictionaryInfo>(entity, model);
            int count = model.Update();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string keyValue)
        {
            int count = tbl_DictionaryInfo.Delete("where DictionaryInfoId=@0", keyValue);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool ExistKey(string key, string lankey, string keyValue)
        {
            var sql = PetaPoco.Sql.Builder.Append(@"select * from tbl_DictionaryInfo where 1=1 ");
            if (!string.IsNullOrEmpty(key))
            {
                sql.Append(" and DictKey=@0", key);
            }
            if (!string.IsNullOrEmpty(lankey))
            {
                sql.Append(" and LanguageKey=@0", lankey);
            }
            if (!string.IsNullOrEmpty(keyValue))
            {
                sql.Append(" and DictionaryInfoId!=@0", keyValue);
            }
            return tbl_DictionaryInfo.Query(sql).Count() == 0 ? true : false;
        }
        public string ConverPara(DictionaryInfoEntity para)
        {
            StringBuilder sbWhere = new StringBuilder();

            if (para == null)
            {
                return sbWhere.ToString();
            }
            if (para.DictionaryInfoId != null)
            {
                sbWhere.AppendFormat(" and DictionaryInfoId='{0}'", para.DictionaryInfoId);
            }
            if (para.DictKey != null)
            {
                sbWhere.AppendFormat(" and DictKey='{0}'", para.DictKey);
            }
            if (para.Name != null)
            {
                sbWhere.AppendFormat(" and Name like '%{0}%'", para.Name);
            }
            if (para.LanguageKey != null)
            {
                sbWhere.AppendFormat(" and LanguageKey='{0}'", para.LanguageKey);
            }
            if (para.ChannelInfoId != null)
            {
                sbWhere.AppendFormat(" and ChannelInfoId='{0}'", para.ChannelInfoId);
            }
            return sbWhere.ToString();
        }
    }
}
