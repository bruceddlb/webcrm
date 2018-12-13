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

    public class NewsBLL : BaseBLL<INewsService<NewsEntity, NewsEntity, Pagination>>
    {

        /// <summary>
        /// 访问实例
        /// </summary>
        public static NewsBLL m_Instance = new NewsBLL();

        /// <summary>
        /// 访问实例
        /// </summary>
        public static NewsBLL Instance
        {
            get { return m_Instance; }
        }

        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "NewsCache";


        /// <summary>
        /// 构造方法
        /// </summary>

        public int QueryCount(NewsEntity para)
        {
            return InstanceDAL.QueryCount(para);
        }

        public List<NewsEntity> GetPageList(NewsEntity para, ref Pagination pagination)
        {
            List<NewsEntity> list = InstanceDAL.GetPageList(para, ref pagination);

            return list;
        }

        public List<NewsEntity> GetList(NewsEntity para)
        {
            return InstanceDAL.GetList(para);
        }

        public bool Add(NewsEntity entity)
        {
            return InstanceDAL.Add(entity);
        }

        public bool Update(NewsEntity entity)
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
        public NewsEntity GetEntity(string keyValue)
        {
            return InstanceDAL.GetEntity(keyValue);
        }

        /// <summary>
        /// 根据语言查询内容
        /// </summary>
        /// <param name="languageKey"></param>
        /// <returns></returns>
        public NewsEntity GetEntityByLanguageKey(NewsEntity para)
        {
            NewsEntity model = new NewsEntity();
            var list = GetList(para);
            if (list != null)
            {
                model = list.FirstOrDefault();
            }
            return model;
        }

    }
}
