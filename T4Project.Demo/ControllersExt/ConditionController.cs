 
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
    
    public partial class ConditionController : ApiController
    {
        #region Condition
		/// <summary>
        /// default update by id
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
		[HttpPut]
        public bool ConditionUpdate(Condition param)
        {
			StringBuilder setParts = new StringBuilder();
			if(param.Id.HasValue)
				setParts.AppendFormat(" {0}={1},","Id","@Id" );
			if(param.ExpressType.HasValue)
				setParts.AppendFormat(" {0}={1},","ExpressType","@ExpressType" );
			if(param.ConditionType.HasValue)
				setParts.AppendFormat(" {0}={1},","ConditionType","@ConditionType" );
			if(param.Val.HasValue)
				setParts.AppendFormat(" {0}={1},","Val","@Val" );
			if(param.TemplateId.HasValue)
				setParts.AppendFormat(" {0}={1},","TemplateId","@TemplateId" );
			if(param.AreaId.HasValue)
				setParts.AppendFormat(" {0}={1},","AreaId","@AreaId" );
			if(param.GroupMark!=null)
				setParts.AppendFormat(" {0}={1},","GroupMark","@GroupMark" );
			return BusinessProvider.ConditionBll.Update(param,setParts.ToString().TrimEnd(','));
		}

		[HttpPost]
        public long ConditionAdd(Condition param)
        {
            Condition model=new Condition();
			model.Id= param.Id.HasValue?param.Id:0;
			model.ExpressType= param.ExpressType.HasValue?param.ExpressType:0;
			model.ConditionType= param.ConditionType.HasValue?param.ConditionType:0;
			model.Val= param.Val.HasValue?param.Val:0;
			model.TemplateId= param.TemplateId.HasValue?param.TemplateId:0;
			model.AreaId= param.AreaId.HasValue?param.AreaId:0;
			model.GroupMark= param.GroupMark!=null?param.GroupMark:string.Empty;
			return BusinessProvider.ConditionBll.Create(model);
        }

		[HttpGet]
        public IEnumerable<Condition> ConditionQuery(Condition param,int offset=0,int limit=20,string orderby="")
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
			if(param.TemplateId.HasValue)
				whereParts.AppendFormat(" {0}={1} and","TemplateId",param.TemplateId );
			if(param.AreaId.HasValue)
				whereParts.AppendFormat(" {0}={1} and","AreaId",param.AreaId );
			if(param.GroupMark!=null)
				whereParts.AppendFormat(" {0}={1} and","GroupMark",param.GroupMark );
			
			string wherePartsStr=whereParts.ToString();
			return BusinessProvider.ConditionBll.Query(param,wherePartsStr.EndsWith("and")?wherePartsStr.Substring(0,3):wherePartsStr,offset,limit,orderby);
        }

		[HttpDelete]
        public long ConditionDelete(Condition param)
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
			if(param.TemplateId.HasValue)
				whereParts.AppendFormat(" {0}={1} and","TemplateId",param.TemplateId );
			if(param.AreaId.HasValue)
				whereParts.AppendFormat(" {0}={1} and","AreaId",param.AreaId );
			if(param.GroupMark!=null)
				whereParts.AppendFormat(" {0}={1} and","GroupMark",param.GroupMark );
			string wherePartsStr=whereParts.ToString();
			return BusinessProvider.ConditionBll.Delete(param,wherePartsStr.EndsWith("and")?wherePartsStr.Substring(0,3):wherePartsStr);
        }
        #endregion
    }
}

