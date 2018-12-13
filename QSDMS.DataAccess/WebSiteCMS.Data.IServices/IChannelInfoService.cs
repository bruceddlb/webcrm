using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteCMS.Data.IServices
{
    public interface IChannelInfoService<T, Q, P> : IDAL<T, Q, P>
    {
        bool ExistKey(string key, string lankey, string keyvalue);
    }
}
