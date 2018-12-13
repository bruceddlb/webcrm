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
    /// 医疗资源
    /// </summary>
    public class MedicalResourceService : BaseSqlDataService, IMedicalResourceService<MedicalResourceEntity, MedicalResourceEntity, Pagination>
    {
        public int QueryCount(MedicalResourceEntity para)
        {
            throw new NotImplementedException();
        }

        public List<MedicalResourceEntity> GetPageList(MedicalResourceEntity para, ref Pagination pagination)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_MedicalResource");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            if (!string.IsNullOrWhiteSpace(pagination.sidx))
            {
                sql.AppendFormat(" order by {0} {1}", pagination.sidx, pagination.sord);
            }
            var currentpage = tbl_MedicalResource.Page(pagination.page, pagination.rows, sql.ToString());
            //数据对象
            var pageList = currentpage.Items;
            //分页对象
            pagination.records = Converter.ParseInt32(currentpage.TotalItems);
            return EntityConvertTools.CopyToList<tbl_MedicalResource, MedicalResourceEntity>(pageList.ToList());
        }

        public List<MedicalResourceEntity> GetList(MedicalResourceEntity para)
        {
            var sql = new StringBuilder();
            sql.Append(@"select * from tbl_MedicalResource");
            string where = ConverPara(para);
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" where 1=1 {0}", where);
            }
            var list = tbl_MedicalResource.Query(sql.ToString());
            return EntityConvertTools.CopyToList<tbl_MedicalResource, MedicalResourceEntity>(list.ToList());
        }

        public MedicalResourceEntity GetEntity(string keyValue)
        {
            var model = tbl_MedicalResource.SingleOrDefault("where MedicalResourceId=@0", keyValue);
            return EntityConvertTools.CopyToModel<tbl_MedicalResource, MedicalResourceEntity>(model, null);
        }

        public bool Add(MedicalResourceEntity entity)
        {
            var model = EntityConvertTools.CopyToModel<MedicalResourceEntity, tbl_MedicalResource>(entity, null);
            model.Insert();
            return true;
        }

        public bool Update(MedicalResourceEntity entity)
        {

            var model = tbl_MedicalResource.SingleOrDefault("where MedicalResourceId=@0", entity.MedicalResourceId);
            model = EntityConvertTools.CopyToModel<MedicalResourceEntity, tbl_MedicalResource>(entity, model);
            int count = model.Update();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string keyValue)
        {
            int count = tbl_MedicalResource.Delete("where MedicalResourceId=@0", keyValue);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public string ConverPara(MedicalResourceEntity para)
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
