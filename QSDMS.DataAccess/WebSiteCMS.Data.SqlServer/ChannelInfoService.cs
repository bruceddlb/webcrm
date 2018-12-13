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
    /// 板块管理
    /// </summary>
    public class ChannelInfoService : BaseSqlDataService, IChannelInfoService<ChannelInfoEntity, ChannelInfoEntity, Pagination>
    {
        public int QueryCount(ChannelInfoEntity para)
        {
            throw new NotImplementedException();
        }

        public List<ChannelInfoEntity> GetPageList(ChannelInfoEntity para, ref Pagination pagination)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_ChannelInfo");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(pagination.sidx))
            {
                sql.AppendFormat(" order by {0} {1}", pagination.sidx, pagination.sord);
            }
            var currentpage = tbl_ChannelInfo.Page(pagination.page, pagination.rows, sql.ToString());
            //数据对象
            var pageList = currentpage.Items;
            //分页对象
            pagination.records = Converter.ParseInt32(currentpage.TotalItems);
            return EntityConvertTools.CopyToList<tbl_ChannelInfo, ChannelInfoEntity>(pageList.ToList());
        }

        public List<ChannelInfoEntity> GetList(ChannelInfoEntity para)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_ChannelInfo");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            var list = tbl_ChannelInfo.Query(sql.ToString());
            return EntityConvertTools.CopyToList<tbl_ChannelInfo, ChannelInfoEntity>(list.ToList());
        }

        public ChannelInfoEntity GetEntity(string keyValue)
        {
            var model = tbl_ChannelInfo.SingleOrDefault("where ChannelInfoId=@0", keyValue);
            return EntityConvertTools.CopyToModel<tbl_ChannelInfo, ChannelInfoEntity>(model, null);
        }

        public bool Add(ChannelInfoEntity entity)
        {
            var model = EntityConvertTools.CopyToModel<ChannelInfoEntity, tbl_ChannelInfo>(entity, null);
            model.Insert();
            return true;
        }

        public bool Update(ChannelInfoEntity entity)
        {

            var model = tbl_ChannelInfo.SingleOrDefault("where ChannelInfoId=@0", entity.ChannelInfoId);
            model = EntityConvertTools.CopyToModel<ChannelInfoEntity, tbl_ChannelInfo>(entity, model);
            int count = model.Update();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string keyValue)
        {
            int count = tbl_ChannelInfo.Delete("where ChannelInfoId=@0", keyValue);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="key"></param>
        /// <param name="lankey"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public bool ExistKey(string key, string lankey, string keyValue)
        {
            var sql = PetaPoco.Sql.Builder.Append(@"select * from tbl_ChannelInfo where 1=1 ");
            if (!string.IsNullOrEmpty(key))
            {
                sql.Append(" and ChanneKey=@0", key);
            }
            if (!string.IsNullOrEmpty(lankey))
            {
                sql.Append(" and LanguageKey=@0", lankey);
            }
            if (!string.IsNullOrEmpty(keyValue))
            {
                sql.Append(" and ChannelInfoId!=@0", keyValue);
            }
            return tbl_ChannelInfo.Query(sql).Count() == 0 ? true : false;
        }
        public string ConverPara(ChannelInfoEntity para)
        {
            StringBuilder sbWhere = new StringBuilder();

            if (para == null)
            {
                return sbWhere.ToString();
            }
            if (para.ChannelInfoId != null)
            {
                sbWhere.AppendFormat(" and ChannelInfoId='{0}'", para.ChannelInfoId);
            }
            if (para.ChanneKey != null)
            {
                sbWhere.AppendFormat(" and ChanneKey='{0}'", para.ChanneKey);
            }
            if (para.Name != null)
            {
                sbWhere.AppendFormat(" and Name like '%{0}%'", para.Name);
            }
            if (para.LanguageKey != null)
            {
                sbWhere.AppendFormat(" and LanguageKey='{0}'", para.LanguageKey);
            }
            return sbWhere.ToString();
        }
    }
}
