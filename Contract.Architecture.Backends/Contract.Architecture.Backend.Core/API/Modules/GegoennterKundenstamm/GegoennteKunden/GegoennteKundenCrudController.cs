using Contract.Architecture.Backend.Core.API.Contexts.Pagination;
using Contract.Architecture.Backend.Core.API.Security.Authorization;
using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.API.Modules.GegoennterKundenstamm.GegoennteKunden
{
    [ApiController]
    [Route("api/gegoennter-kundenstamm/gegoennte-kunden")]
    public class GegoennteKundenCrudController : ControllerBase
    {
        private readonly IGegoennteKundenCrudLogic gegoennteKundenCrudLogic;

        public GegoennteKundenCrudController(IGegoennteKundenCrudLogic gegoennteKundenCrudLogic)
        {
            this.gegoennteKundenCrudLogic = gegoennteKundenCrudLogic;
        }

        [HttpGet]
        [Authorized]
        [Pagination(FilterFields = new[] { "Name" })]
        public ActionResult<IPagedResult<IGegoennterKunde>> GetGegoennteKunden()
        {
            var getGegoennteKundenPagedResult = this.gegoennteKundenCrudLogic.GetGegoennteKunden();
            return this.FromLogicResult(getGegoennteKundenPagedResult);
        }

        [HttpGet]
        [Authorized]
        [Route("{gegoennterKundeId}")]
        public ActionResult<IGegoennterKundeDetail> GetGegoennterKundeDetail(Guid gegoennterKundeId)
        {
            var getGegoennterKundeDetailResult = this.gegoennteKundenCrudLogic.GetGegoennterKundeDetail(gegoennterKundeId);
            return this.FromLogicResult(getGegoennterKundeDetailResult);
        }

        [HttpPost]
        [Authorized]
        public ActionResult<DataBody<Guid>> CreateGegoennterKunde([FromBody] GegoennterKundeCreate gegoennterKundeCreate)
        {
            ILogicResult<Guid> createGegoennterKundeResult = this.gegoennteKundenCrudLogic.CreateGegoennterKunde(gegoennterKundeCreate);
            if (!createGegoennterKundeResult.IsSuccessful)
            {
                return this.FromLogicResult(createGegoennterKundeResult);
            }

            return this.Ok(new DataBody<Guid>(createGegoennterKundeResult.Data));
        }

        [HttpPut]
        [Authorized]
        public ActionResult UpdateGegoennterKunde([FromBody] GegoennterKundeUpdate gegoennterKundeUpdate)
        {
            ILogicResult updateGegoennterKundeResult = this.gegoennteKundenCrudLogic.UpdateGegoennterKunde(gegoennterKundeUpdate);
            return this.FromLogicResult(updateGegoennterKundeResult);
        }

        [HttpDelete]
        [Authorized]
        [Route("{gegoennterKundeId}")]
        public ActionResult DeleteGegoennterKunde(Guid gegoennterKundeId)
        {
            ILogicResult deleteGegoennterKundeResult = this.gegoennteKundenCrudLogic.DeleteGegoennterKunde(gegoennterKundeId);
            return this.FromLogicResult(deleteGegoennterKundeResult);
        }
    }
}