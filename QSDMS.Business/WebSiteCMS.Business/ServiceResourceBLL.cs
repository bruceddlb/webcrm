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

    public class ServiceResourceBLL : BaseBLL<IServiceResourceService<ServiceResourceEntity, ServiceResourceEntity, Pagination>>
    {

        /// <summary>
        /// 访问实例
        /// </summary>
        public static ServiceResourceBLL m_Instance = new ServiceResourceBLL();

        /// <summary>
        /// 访问实例
        /// </summary>
        public static ServiceResourceBLL Instance
        {
            get { return m_Instance; }
        }

        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "ServiceResourceCache";


        /// <summary>
        /// 构造方法
        /// </summary>

        public int QueryCount(ServiceResourceEntity para)
        {
            return InstanceDAL.QueryCount(para);
        }

        public List<ServiceResourceEntity> GetPageList(ServiceResourceEntity para, ref Pagination pagination)
        {
            List<ServiceResourceEntity> list = InstanceDAL.GetPageList(para, ref pagination);

            return list;
        }

        public List<ServiceResourceEntity> GetList(ServiceResourceEntity para)
        {
            return InstanceDAL.GetList(para);
        }

        public bool Add(ServiceResourceEntity entity)
        {
            return InstanceDAL.Add(entity);
        }

        public bool Update(ServiceResourceEntity entity)
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
        public ServiceResourceEntity GetEntity(string keyValue)
        {
            return InstanceDAL.GetEntity(keyValue);
        }
    }
}
