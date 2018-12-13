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
    /// 医院资源
    /// </summary>
    public class HotelResourceService : BaseSqlDataService, IHotelResourceService<HotelResourceEntity, HotelResourceEntity, Pagination>
    {
        public int QueryCount(HotelResourceEntity para)
        {
            throw new NotImplementedException();
        }

        public List<HotelResourceEntity> GetPageList(HotelResourceEntity para, ref Pagination pagination)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_HotelResource");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(pagination.sidx))
            {
                sql.AppendFormat(" order by {0} {1}", pagination.sidx, pagination.sord);
            }
            var currentpage = tbl_HotelResource.Page(pagination.page, pagination.rows, sql.ToString());
            //数据对象
            var pageList = currentpage.Items;
            //分页对象
            pagination.records = Converter.ParseInt32(currentpage.TotalItems);
            return EntityConvertTools.CopyToList<tbl_HotelResource, HotelResourceEntity>(pageList.ToList());
        }

        public List<HotelResourceEntity> GetList(HotelResourceEntity para)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_HotelResource");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            var list = tbl_HotelResource.Query(sql.ToString());
            return EntityConvertTools.CopyToList<tbl_HotelResource, HotelResourceEntity>(list.ToList());
        }

        public HotelResourceEntity GetEntity(string keyValue)
        {
            var model = tbl_HotelResource.SingleOrDefault("where HotelResourceId=@0", keyValue);
            return EntityConvertTools.CopyToModel<tbl_HotelResource, HotelResourceEntity>(model, null);
        }

        public bool Add(HotelResourceEntity entity)
        {
            var model = EntityConvertTools.CopyToModel<HotelResourceEntity, tbl_HotelResource>(entity, null);
            model.Insert();
            return true;
        }

        public bool Update(HotelResourceEntity entity)
        {

            var model = tbl_HotelResource.SingleOrDefault("where HotelResourceId=@0", entity.HotelResourceId);
            model = EntityConvertTools.CopyToModel<HotelResourceEntity, tbl_HotelResource>(entity, model);
            int count = model.Update();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string keyValue)
        {
            int count = tbl_HotelResource.Delete("where HotelResourceId=@0", keyValue);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public string ConverPara(HotelResourceEntity para)
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
