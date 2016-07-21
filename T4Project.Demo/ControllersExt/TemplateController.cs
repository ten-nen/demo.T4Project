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
    
    public partial class TemplateController : ApiController
    {
        #region Template
		/// <summary>
        /// default update by id
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
		[HttpPut]
        public bool TemplateUpdate(Template param)
        {
			StringBuilder setParts = new StringBuilder();
			if(param.Id.HasValue)
				setParts.AppendFormat(" {0}={1},","Id","@Id" );
			if(param.Name!=null)
				setParts.AppendFormat(" {0}={1},","Name","@Name" );
			if(param.FreightType.HasValue)
				setParts.AppendFormat(" {0}={1},","FreightType","@FreightType" );
			if(param.PricingType.HasValue)
				setParts.AppendFormat(" {0}={1},","PricingType","@PricingType" );
			if(param.ExpressType.HasValue)
				setParts.AppendFormat(" {0}={1},","ExpressType","@ExpressType" );
			if(param.IsCondition.HasValue)
				setParts.AppendFormat(" {0}={1},","IsCondition","@IsCondition" );
			return BusinessProvider.TemplateBll.Update(param,setParts.ToString().TrimEnd(','));
		}

		[HttpPost]
        public long TemplateAdd(Template param)
        {
            Template model=new Template();
			model.Id= param.Id.HasValue?param.Id:0;
			model.Name= param.Name!=null?param.Name:string.Empty;
			model.FreightType= param.FreightType.HasValue?param.FreightType:0;
			model.PricingType= param.PricingType.HasValue?param.PricingType:0;
			model.ExpressType= param.ExpressType.HasValue?param.ExpressType:0;
			model.IsCondition= param.IsCondition.HasValue?param.IsCondition:false;
			return BusinessProvider.TemplateBll.Create(model);
        }

		[HttpGet]
        public IEnumerable<Template> TemplateQuery(Template param,int offset=0,int limit=20,string orderby="")
        {
            StringBuilder whereParts = new StringBuilder();
			if(param.Id.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Id",param.Id );
			if(param.Name!=null)
				whereParts.AppendFormat(" {0}={1} and","Name",param.Name );
			if(param.FreightType.HasValue)
				whereParts.AppendFormat(" {0}={1} and","FreightType",param.FreightType );
			if(param.PricingType.HasValue)
				whereParts.AppendFormat(" {0}={1} and","PricingType",param.PricingType );
			if(param.ExpressType.HasValue)
				whereParts.AppendFormat(" {0}={1} and","ExpressType",param.ExpressType );
			if(param.IsCondition.HasValue)
				whereParts.AppendFormat(" {0}={1} and","IsCondition",param.IsCondition );
			
			string wherePartsStr=whereParts.ToString();
			return BusinessProvider.TemplateBll.Query(param,wherePartsStr.EndsWith("and")?wherePartsStr.Substring(0,3):wherePartsStr,offset,limit,orderby);
        }

		[HttpDelete]
        public long TemplateDelete(Template param)
        {
            StringBuilder whereParts = new StringBuilder();
			if(param.Id.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Id",param.Id );
			if(param.Name!=null)
				whereParts.AppendFormat(" {0}={1} and","Name",param.Name );
			if(param.FreightType.HasValue)
				whereParts.AppendFormat(" {0}={1} and","FreightType",param.FreightType );
			if(param.PricingType.HasValue)
				whereParts.AppendFormat(" {0}={1} and","PricingType",param.PricingType );
			if(param.ExpressType.HasValue)
				whereParts.AppendFormat(" {0}={1} and","ExpressType",param.ExpressType );
			if(param.IsCondition.HasValue)
				whereParts.AppendFormat(" {0}={1} and","IsCondition",param.IsCondition );
			string wherePartsStr=whereParts.ToString();
			return BusinessProvider.TemplateBll.Delete(param,wherePartsStr.EndsWith("and")?wherePartsStr.Substring(0,3):wherePartsStr);
        }
        #endregion
    }
}

