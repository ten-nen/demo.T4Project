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
    
    public partial class FormulaController : ApiController
    {
        #region Formula
		/// <summary>
        /// default update by id
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
		[HttpPut]
        public bool FormulaUpdate(Formula param)
        {
			StringBuilder setParts = new StringBuilder();
			if(param.Id.HasValue)
				setParts.AppendFormat(" {0}={1},","Id","@Id" );
			if(param.Name!=null)
				setParts.AppendFormat(" {0}={1},","Name","@Name" );
			if(param.Desc!=null)
				setParts.AppendFormat(" {0}={1},","Desc","@Desc" );
			if(param.Template!=null)
				setParts.AppendFormat(" {0}={1},","Template","@Template" );
			if(param.Typeid.HasValue)
				setParts.AppendFormat(" {0}={1},","Typeid","@Typeid" );
			return BusinessProvider.FormulaBll.Update(param,setParts.ToString().TrimEnd(','));
		}

		[HttpPost]
        public long FormulaAdd(Formula param)
        {
            Formula model=new Formula();
			model.Id= param.Id.HasValue?param.Id:0;
			model.Name= param.Name!=null?param.Name:string.Empty;
			model.Desc= param.Desc!=null?param.Desc:string.Empty;
			model.Template= param.Template!=null?param.Template:string.Empty;
			model.Typeid= param.Typeid.HasValue?param.Typeid:0;
			return BusinessProvider.FormulaBll.Create(model);
        }

		[HttpGet]
        public IEnumerable<Formula> FormulaQuery(Formula param,int offset=0,int limit=20,string orderby="")
        {
            StringBuilder whereParts = new StringBuilder();
			if(param.Id.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Id",param.Id );
			if(param.Name!=null)
				whereParts.AppendFormat(" {0}={1} and","Name",param.Name );
			if(param.Desc!=null)
				whereParts.AppendFormat(" {0}={1} and","Desc",param.Desc );
			if(param.Template!=null)
				whereParts.AppendFormat(" {0}={1} and","Template",param.Template );
			if(param.Typeid.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Typeid",param.Typeid );
			
			string wherePartsStr=whereParts.ToString();
			return BusinessProvider.FormulaBll.Query(param,wherePartsStr.EndsWith("and")?wherePartsStr.Substring(0,3):wherePartsStr,offset,limit,orderby);
        }

		[HttpDelete]
        public long FormulaDelete(Formula param)
        {
            StringBuilder whereParts = new StringBuilder();
			if(param.Id.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Id",param.Id );
			if(param.Name!=null)
				whereParts.AppendFormat(" {0}={1} and","Name",param.Name );
			if(param.Desc!=null)
				whereParts.AppendFormat(" {0}={1} and","Desc",param.Desc );
			if(param.Template!=null)
				whereParts.AppendFormat(" {0}={1} and","Template",param.Template );
			if(param.Typeid.HasValue)
				whereParts.AppendFormat(" {0}={1} and","Typeid",param.Typeid );
			string wherePartsStr=whereParts.ToString();
			return BusinessProvider.FormulaBll.Delete(param,wherePartsStr.EndsWith("and")?wherePartsStr.Substring(0,3):wherePartsStr);
        }
        #endregion
    }
}

