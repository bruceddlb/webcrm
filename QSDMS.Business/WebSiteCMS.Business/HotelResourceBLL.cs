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

    public class HotelResourceBLL : BaseBLL<IHotelResourceService<HotelResourceEntity, HotelResourceEntity, Pagination>>
    {

        /// <summary>
        /// 访问实例
        /// </summary>
        public static HotelResourceBLL m_Instance = new HotelResourceBLL();

        /// <summary>
        /// 访问实例
        /// </summary>
        public static HotelResourceBLL Instance
        {
            get { return m_Instance; }
        }

        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "HotelResourceCache";


        /// <summary>
        /// 构造方法
        /// </summary>

        public int QueryCount(HotelResourceEntity para)
        {
            return InstanceDAL.QueryCount(para);
        }

        public List<HotelResourceEntity> GetPageList(HotelResourceEntity para, ref Pagination pagination)
        {
            List<HotelResourceEntity> list = InstanceDAL.GetPageList(para, ref pagination);

            return list;
        }

        public List<HotelResourceEntity> GetList(HotelResourceEntity para)
        {
            return InstanceDAL.GetList(para);
        }

        public bool Add(HotelResourceEntity entity)
        {
            return InstanceDAL.Add(entity);
        }

        public bool Update(HotelResourceEntity entity)
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
        public HotelResourceEntity GetEntity(string keyValue)
        {
            return InstanceDAL.GetEntity(keyValue);
        }
    }
}
