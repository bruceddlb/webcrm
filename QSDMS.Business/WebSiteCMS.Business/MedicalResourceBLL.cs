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

    public class MedicalResourceBLL : BaseBLL<IMedicalResourceService<MedicalResourceEntity, MedicalResourceEntity, Pagination>>
    {

        /// <summary>
        /// 访问实例
        /// </summary>
        public static MedicalResourceBLL m_Instance = new MedicalResourceBLL();

        /// <summary>
        /// 访问实例
        /// </summary>
        public static MedicalResourceBLL Instance
        {
            get { return m_Instance; }
        }

        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "MedicalResourceCache";


        /// <summary>
        /// 构造方法
        /// </summary>

        public int QueryCount(MedicalResourceEntity para)
        {
            return InstanceDAL.QueryCount(para);
        }

        public List<MedicalResourceEntity> GetPageList(MedicalResourceEntity para, ref Pagination pagination)
        {
            List<MedicalResourceEntity> list = InstanceDAL.GetPageList(para, ref pagination);

            return list;
        }

        public List<MedicalResourceEntity> GetList(MedicalResourceEntity para)
        {
            return InstanceDAL.GetList(para);
        }

        public bool Add(MedicalResourceEntity entity)
        {
            return InstanceDAL.Add(entity);
        }

        public bool Update(MedicalResourceEntity entity)
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
        public MedicalResourceEntity GetEntity(string keyValue)
        {
            return InstanceDAL.GetEntity(keyValue);
        }
    }
}
