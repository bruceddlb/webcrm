//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//	   生成时间 2017-06-11 15:18:04 by 群升科技
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
    
using System;
namespace QSDMS.Model 
{
    /// <summary>
    /// 数据表实体类：Base_ModuleColumnEntity 
    /// </summary>
    [Serializable()]
    public class Base_ModuleColumnEntity
    {    
		            
		/// <summary>
		/// varchar:列主键
		/// </summary>	
                 
		public string ModuleColumnId { get; set; }

                    
		/// <summary>
		/// varchar:功能主键
		/// </summary>	
                 
		public string ModuleId { get; set; }

                    
		/// <summary>
		/// varchar:父级主键
		/// </summary>	
                 
		public string ParentId { get; set; }

                    
		/// <summary>
		/// varchar:编码
		/// </summary>	
                 
		public string EnCode { get; set; }

                    
		/// <summary>
		/// varchar:名称
		/// </summary>	
                 
		public string FullName { get; set; }

                    
		/// <summary>
		/// int:排序码
		/// </summary>	
                 
		public int? SortCode { get; set; }

                    
		/// <summary>
		/// varchar:备注
		/// </summary>	
                 
		public string Description { get; set; }

           
    }    
}
	