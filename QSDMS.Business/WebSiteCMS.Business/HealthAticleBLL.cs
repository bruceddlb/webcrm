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

    public class HealthAticleBLL : BaseBLL<IHealthAticleService<HealthAticleEntity, HealthAticleEntity, Pagination>>
    {

        /// <summary>
        /// 访问实例
        /// </summary>
        public static HealthAticleBLL m_Instance = new HealthAticleBLL();

        /// <summary>
        /// 访问实例
        /// </summary>
        public static HealthAticleBLL Instance
        {
            get { return m_Instance; }
        }

        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "HealthAticleCache";


        /// <summary>
        /// 构造方法
        /// </summary>

        public int QueryCount(HealthAticleEntity para)
        {
            return InstanceDAL.QueryCount(para);
        }

        public List<HealthAticleEntity> GetPageList(HealthAticleEntity para, ref Pagination pagination)
        {
            List<HealthAticleEntity> list = InstanceDAL.GetPageList(para, ref pagination);

            return list;
        }

        public List<HealthAticleEntity> GetList(HealthAticleEntity para)
        {
            return InstanceDAL.GetList(para);
        }

        public bool Add(HealthAticleEntity entity)
        {
            return InstanceDAL.Add(entity);
        }

        public bool Update(HealthAticleEntity entity)
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
        public HealthAticleEntity GetEntity(string keyValue)
        {
            return InstanceDAL.GetEntity(keyValue);
        }
    }
}
