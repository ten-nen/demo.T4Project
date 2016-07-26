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
    
    public partial class FormulaArgsController : ApiController
    {
        #region FormulaArgs
		/// <summary>
        /// default update by id
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
		[HttpPut]
        public bool FormulaArgsUpdate(FormulaArgs param)
        {
			StringBuilder setParts = new StringBuilder();
			if(param.Typeid.HasValue)
				setParts.AppendFormat(" {0}={1},","Typeid","@Typeid" );
			if(param.Val.HasValue)
				setParts.AppendFormat(" {0}={1},","Val","@Val" );
			if(param.TemplateId.HasValue)
				setParts.AppendFormat(" {0}={1},","TemplateId","@TemplateId" );
			if(param.AreaId.HasValue)
				setParts.AppendFormat(" {0}={1},","AreaId","@AreaId" );
			if(param.GroupMark!=null)
				setParts.AppendFormat(" {0}={1},","GroupMark","@GroupMark" );
			return BusinessProvider.FormulaArgsBll.Update(param,setParts.ToString().TrimEnd(','));
		}

		[HttpPost]
        public long FormulaArgsAdd(FormulaArgs param)
        {
            FormulaArgs model=new FormulaArgs();
			model.Id= param.Id.HasValue?param.Id:0;
			model.Typeid= param.Typeid.HasValue?param.Typeid:0;
			model.Val= param.Val.HasValue?param.Val:0;
			model.TemplateId= param.TemplateId.HasValue?param.TemplateId:0;
			model.AreaId= param.AreaId.HasValue?param.AreaId:0;
			model.GroupMark= param.GroupMark!=null?param.GroupMark:string.Empty;
			return BusinessProvider.FormulaArgsBll.Create(model);
        }

		[HttpGet]
        public IEnumerable<FormulaArgs> FormulaArgsQuery(FormulaArgs param,int offset=0,int limit=20,string orderby="")
        {
            StringBuilder whereParts = new StringBuilder();
			if(param.Id.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Id",param.Id );
			if(param.Typeid.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Typeid",param.Typeid );
			if(param.Val.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Val",param.Val );
			if(param.TemplateId.HasValue)
				whereParts.AppendFormat(" {0}={1} and","TemplateId",param.TemplateId );
			if(param.AreaId.HasValue)
				whereParts.AppendFormat(" {0}={1} and","AreaId",param.AreaId );
			if(param.GroupMark!=null)
				whereParts.AppendFormat(" {0}={1} and","GroupMark",param.GroupMark );
			
			string wherePartsStr=whereParts.ToString();
			return BusinessProvider.FormulaArgsBll.Query(param,wherePartsStr.EndsWith("and")?wherePartsStr.Substring(0,wherePartsStr.Length-3):wherePartsStr,offset,limit,orderby);
        }

		[HttpDelete]
        public long FormulaArgsDelete(FormulaArgs param)
        {
            StringBuilder whereParts = new StringBuilder();
			if(param.Id.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Id",param.Id );
			if(param.Typeid.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Typeid",param.Typeid );
			if(param.Val.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Val",param.Val );
			if(param.TemplateId.HasValue)
				whereParts.AppendFormat(" {0}={1} and","TemplateId",param.TemplateId );
			if(param.AreaId.HasValue)
				whereParts.AppendFormat(" {0}={1} and","AreaId",param.AreaId );
			if(param.GroupMark!=null)
				whereParts.AppendFormat(" {0}={1} and","GroupMark",param.GroupMark );
			string wherePartsStr=whereParts.ToString();
			return BusinessProvider.FormulaArgsBll.Delete(param,wherePartsStr.EndsWith("and")?wherePartsStr.Substring(0,wherePartsStr.Length-3):wherePartsStr);
        }
        #endregion
    }
}

