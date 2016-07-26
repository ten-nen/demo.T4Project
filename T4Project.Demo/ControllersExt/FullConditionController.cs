using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using T4Project.Models;

namespace T4Project.Controllers
{
    
    public partial class FullConditionController : ApiController
    {
        #region FullCondition
		/// <summary>
        /// default update by id
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
		[HttpPut]
        public bool FullConditionUpdate(FullCondition param)
        {
			StringBuilder setParts = new StringBuilder();
			if(param.ExpressType.HasValue)
				setParts.AppendFormat(" {0}={1},","ExpressType","@ExpressType" );
			if(param.ConditionType.HasValue)
				setParts.AppendFormat(" {0}={1},","ConditionType","@ConditionType" );
			if(param.Val.HasValue)
				setParts.AppendFormat(" {0}={1},","Val","@Val" );
			if(param.AreaId.HasValue)
				setParts.AppendFormat(" {0}={1},","AreaId","@AreaId" );
			if(param.GroupMark!=null)
				setParts.AppendFormat(" {0}={1},","GroupMark","@GroupMark" );
			if(param.Enabled.HasValue)
				setParts.AppendFormat(" {0}={1},","Enabled","@Enabled" );
			return BusinessProvider.FullConditionBll.Update(param,setParts.ToString().TrimEnd(','));
		}

		[HttpPost]
        public long FullConditionAdd(FullCondition param)
        {
            FullCondition model=new FullCondition();
			model.Id= param.Id.HasValue?param.Id:0;
			model.ExpressType= param.ExpressType.HasValue?param.ExpressType:0;
			model.ConditionType= param.ConditionType.HasValue?param.ConditionType:0;
			model.Val= param.Val.HasValue?param.Val:0;
			model.AreaId= param.AreaId.HasValue?param.AreaId:0;
			model.GroupMark= param.GroupMark!=null?param.GroupMark:string.Empty;
			model.Enabled= param.Enabled.HasValue?param.Enabled:false;
			return BusinessProvider.FullConditionBll.Create(model);
        }

		[HttpGet]
        public IEnumerable<FullCondition> FullConditionQuery(FullCondition param,int offset=0,int limit=20,string orderby="")
        {
            StringBuilder whereParts = new StringBuilder();
			if(param.Id.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Id",param.Id );
			if(param.ExpressType.HasValue)
				whereParts.AppendFormat(" {0}={1} and","ExpressType",param.ExpressType );
			if(param.ConditionType.HasValue)
				whereParts.AppendFormat(" {0}={1} and","ConditionType",param.ConditionType );
			if(param.Val.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Val",param.Val );
			if(param.AreaId.HasValue)
				whereParts.AppendFormat(" {0}={1} and","AreaId",param.AreaId );
			if(param.GroupMark!=null)
				whereParts.AppendFormat(" {0}={1} and","GroupMark",param.GroupMark );
			if(param.Enabled.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Enabled",param.Enabled );
			
			string wherePartsStr=whereParts.ToString();
			return BusinessProvider.FullConditionBll.Query(param,wherePartsStr.EndsWith("and")?wherePartsStr.Substring(0,wherePartsStr.Length-3):wherePartsStr,offset,limit,orderby);
        }

		[HttpDelete]
        public long FullConditionDelete(FullCondition param)
        {
            StringBuilder whereParts = new StringBuilder();
			if(param.Id.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Id",param.Id );
			if(param.ExpressType.HasValue)
				whereParts.AppendFormat(" {0}={1} and","ExpressType",param.ExpressType );
			if(param.ConditionType.HasValue)
				whereParts.AppendFormat(" {0}={1} and","ConditionType",param.ConditionType );
			if(param.Val.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Val",param.Val );
			if(param.AreaId.HasValue)
				whereParts.AppendFormat(" {0}={1} and","AreaId",param.AreaId );
			if(param.GroupMark!=null)
				whereParts.AppendFormat(" {0}={1} and","GroupMark",param.GroupMark );
			if(param.Enabled.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Enabled",param.Enabled );
			string wherePartsStr=whereParts.ToString();
			return BusinessProvider.FullConditionBll.Delete(param,wherePartsStr.EndsWith("and")?wherePartsStr.Substring(0,wherePartsStr.Length-3):wherePartsStr);
        }
        #endregion
    }
}

