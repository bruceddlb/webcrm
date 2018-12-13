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

    public class JobBLL : BaseBLL<IJobService<JobEntity, JobEntity, Pagination>>
    {

        /// <summary>
        /// 访问实例
        /// </summary>
        public static JobBLL m_Instance = new JobBLL();

        /// <summary>
        /// 访问实例
        /// </summary>
        public static JobBLL Instance
        {
            get { return m_Instance; }
        }

        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "JobCache";


        /// <summary>
        /// 构造方法
        /// </summary>

        public int QueryCount(JobEntity para)
        {
            return InstanceDAL.QueryCount(para);
        }

        public List<JobEntity> GetPageList(JobEntity para, ref Pagination pagination)
        {
            List<JobEntity> list = InstanceDAL.GetPageList(para, ref pagination);

            return list;
        }

        public List<JobEntity> GetList(JobEntity para)
        {
            return InstanceDAL.GetList(para);
        }

        public bool Add(JobEntity entity)
        {
            return InstanceDAL.Add(entity);
        }

        public bool Update(JobEntity entity)
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
        public JobEntity GetEntity(string keyValue)
        {
            return InstanceDAL.GetEntity(keyValue);
        }

        /// <summary>
        /// 根据语言查询内容
        /// </summary>
        /// <param name="languageKey"></param>
        /// <returns></returns>
        public JobEntity GetEntityByLanguageKey(JobEntity para)
        {
            JobEntity model = new JobEntity();
            var list = GetList(para);
            if (list != null)
            {
                model = list.FirstOrDefault();
            }
            return model;
        }

    }
}
