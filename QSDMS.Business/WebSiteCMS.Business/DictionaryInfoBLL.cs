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

    public class DictionaryInfoBLL : BaseBLL<IDictionaryInfoService<DictionaryInfoEntity, DictionaryInfoEntity, Pagination>>
    {

        /// <summary>
        /// 访问实例
        /// </summary>
        public static DictionaryInfoBLL m_Instance = new DictionaryInfoBLL();

        /// <summary>
        /// 访问实例
        /// </summary>
        public static DictionaryInfoBLL Instance
        {
            get { return m_Instance; }
        }

        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "DictionaryInfoCache";


        /// <summary>
        /// 构造方法
        /// </summary>

        public int QueryCount(DictionaryInfoEntity para)
        {
            return InstanceDAL.QueryCount(para);
        }

        public List<DictionaryInfoEntity> GetPageList(DictionaryInfoEntity para, ref Pagination pagination)
        {
            List<DictionaryInfoEntity> list = InstanceDAL.GetPageList(para, ref pagination);

            return list;
        }

        public List<DictionaryInfoEntity> GetList(DictionaryInfoEntity para)
        {
            return InstanceDAL.GetList(para);
        }

        public bool Add(DictionaryInfoEntity entity)
        {
            return InstanceDAL.Add(entity);
        }

        public bool Update(DictionaryInfoEntity entity)
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
        public DictionaryInfoEntity GetEntity(string keyValue)
        {
            return InstanceDAL.GetEntity(keyValue);
        }

        /// <summary>
        /// 根据语言查询内容
        /// </summary>
        /// <param name="languageKey"></param>
        /// <returns></returns>
        public DictionaryInfoEntity GetEntityByLanguageKey(DictionaryInfoEntity para)
        {
            DictionaryInfoEntity model = new DictionaryInfoEntity();
            var list = GetList(para);
            if (list != null)
            {
                model = list.FirstOrDefault();
            }
            return model;
        }

        public bool ExistKey(string key, string lankey, string keyvalue)
        {
            return InstanceDAL.ExistKey(key, lankey, keyvalue);
        }

    }
}
