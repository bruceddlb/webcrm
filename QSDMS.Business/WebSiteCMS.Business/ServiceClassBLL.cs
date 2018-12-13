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

    public class ServiceClassBLL : BaseBLL<IServiceClassService<ServiceClassEntity, ServiceClassEntity, Pagination>>
    {

        /// <summary>
        /// 访问实例
        /// </summary>
        public static ServiceClassBLL m_Instance = new ServiceClassBLL();

        /// <summary>
        /// 访问实例
        /// </summary>
        public static ServiceClassBLL Instance
        {
            get { return m_Instance; }
        }

        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "ServiceClassCache";


        /// <summary>
        /// 构造方法
        /// </summary>

        public int QueryCount(ServiceClassEntity para)
        {
            return InstanceDAL.QueryCount(para);
        }

        public List<ServiceClassEntity> GetPageList(ServiceClassEntity para, ref Pagination pagination)
        {
            List<ServiceClassEntity> list = InstanceDAL.GetPageList(para, ref pagination);

            return list;
        }

        public List<ServiceClassEntity> GetList(ServiceClassEntity para)
        {
            return InstanceDAL.GetList(para);
        }

        public bool Add(ServiceClassEntity entity)
        {
            return InstanceDAL.Add(entity);
        }

        public bool Update(ServiceClassEntity entity)
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
        public ServiceClassEntity GetEntity(string keyValue)
        {
            return InstanceDAL.GetEntity(keyValue);
        }
    }
}
