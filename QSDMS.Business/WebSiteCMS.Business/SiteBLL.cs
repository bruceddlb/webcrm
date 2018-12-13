using QSDMS.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteCMS.Data.IServices;
using WebSiteCMS.Model;

namespace WebSiteCMS.Business
{

    public class SiteBLL : BaseBLL<ISiteService<SiteEntity, SiteEntity, Pagination>>
    {

        /// <summary>
        /// 访问实例
        /// </summary>
        public static SiteBLL m_Instance = new SiteBLL();

        /// <summary>
        /// 访问实例
        /// </summary>
        public static SiteBLL Instance
        {
            get { return m_Instance; }
        }

        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "SiteCache";


        /// <summary>
        /// 构造方法
        /// </summary>

        public int QueryCount(SiteEntity para)
        {
            return InstanceDAL.QueryCount(para);
        }

        public List<SiteEntity> GetPageList(SiteEntity para, ref Pagination pagination)
        {
            List<SiteEntity> list = InstanceDAL.GetPageList(para, ref pagination);

            return list;
        }

        public List<SiteEntity> GetList(SiteEntity para)
        {
            return InstanceDAL.GetList(para);
        }

        public bool Add(SiteEntity entity)
        {
            return InstanceDAL.Add(entity);
        }

        public bool Update(SiteEntity entity)
        {
            return InstanceDAL.Update(entity);
        }

        public bool Delete(string keyValue)
        {
            return InstanceDAL.Delete(keyValue);
        }
        /// <summary>
        /// 实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public SiteEntity GetEntity(string keyValue)
        {
            return InstanceDAL.GetEntity(keyValue);
        }
    }
}
