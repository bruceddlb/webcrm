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

    public class LanguageInfoBLL : BaseBLL<ILanguageInfoService<LanguageInfoEntity, LanguageInfoEntity, Pagination>>
    {

        /// <summary>
        /// 访问实例
        /// </summary>
        public static LanguageInfoBLL m_Instance = new LanguageInfoBLL();

        /// <summary>
        /// 访问实例
        /// </summary>
        public static LanguageInfoBLL Instance
        {
            get { return m_Instance; }
        }

        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "LanguageInfoCache";


        /// <summary>
        /// 构造方法
        /// </summary>

        public int QueryCount(LanguageInfoEntity para)
        {
            return InstanceDAL.QueryCount(para);
        }

        public List<LanguageInfoEntity> GetPageList(LanguageInfoEntity para, ref Pagination pagination)
        {
            List<LanguageInfoEntity> list = InstanceDAL.GetPageList(para, ref pagination);

            return list;
        }

        public List<LanguageInfoEntity> GetList(LanguageInfoEntity para)
        {
            return InstanceDAL.GetList(para);
        }

        public bool Add(LanguageInfoEntity entity)
        {
            return InstanceDAL.Add(entity);
        }

        public bool Update(LanguageInfoEntity entity)
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
        public LanguageInfoEntity GetEntity(string keyValue)
        {
            return InstanceDAL.GetEntity(keyValue);
        }

        /// <summary>
        /// 根据语言查询内容
        /// </summary>
        /// <param name="languageKey"></param>
        /// <returns></returns>
        public LanguageInfoEntity GetEntityByLanguageKey(LanguageInfoEntity para)
        {
            LanguageInfoEntity model = new LanguageInfoEntity();
            var list = GetList(para);
            if (list != null)
            {
                model = list.FirstOrDefault();
            }
            return model;
        }

    }
}
