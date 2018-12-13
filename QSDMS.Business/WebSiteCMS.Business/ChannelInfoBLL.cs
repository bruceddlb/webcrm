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

    public class ChannelInfoBLL : BaseBLL<IChannelInfoService<ChannelInfoEntity, ChannelInfoEntity, Pagination>>
    {

        /// <summary>
        /// 访问实例
        /// </summary>
        public static ChannelInfoBLL m_Instance = new ChannelInfoBLL();

        /// <summary>
        /// 访问实例
        /// </summary>
        public static ChannelInfoBLL Instance
        {
            get { return m_Instance; }
        }

        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "ChannelInfoCache";


        /// <summary>
        /// 构造方法
        /// </summary>

        public int QueryCount(ChannelInfoEntity para)
        {
            return InstanceDAL.QueryCount(para);
        }

        public List<ChannelInfoEntity> GetPageList(ChannelInfoEntity para, ref Pagination pagination)
        {
            List<ChannelInfoEntity> list = InstanceDAL.GetPageList(para, ref pagination);

            return list;
        }

        public List<ChannelInfoEntity> GetList(ChannelInfoEntity para)
        {
            return InstanceDAL.GetList(para);
        }

        public bool Add(ChannelInfoEntity entity)
        {
            return InstanceDAL.Add(entity);
        }

        public bool Update(ChannelInfoEntity entity)
        {
            return InstanceDAL.Update(entity);
        }

        public bool Delete(string keyValue)
        {
            return InstanceDAL.Delete(keyValue);
        }

        public bool ExistKey(string key, string lankey, string keyvalue)
        {
            return InstanceDAL.ExistKey(key, lankey, keyvalue);
        }
        /// <summary>
        /// 实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ChannelInfoEntity GetEntity(string keyValue)
        {
            return InstanceDAL.GetEntity(keyValue);
        }

        /// <summary>
        /// 根据语言查询内容
        /// </summary>
        /// <param name="languageKey"></param>
        /// <returns></returns>
        public ChannelInfoEntity GetEntityByLanguageKey(ChannelInfoEntity para)
        {
            ChannelInfoEntity model = new ChannelInfoEntity();
            var list = GetList(para);
            if (list != null)
            {
                model = list.FirstOrDefault();
            }
            return model;
        }

    }
}
