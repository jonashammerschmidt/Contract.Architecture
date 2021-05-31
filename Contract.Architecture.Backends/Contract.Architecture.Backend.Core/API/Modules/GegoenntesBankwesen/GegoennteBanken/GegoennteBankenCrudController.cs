using Contract.Architecture.Backend.Core.API.Security.Authorization;
using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.API.Modules.GegoenntesBankwesen.GegoennteBanken
{
    [ApiController]
    [Route("api/gegoenntes-bankwesen/gegoennte-banken")]
    public class GegoennteBankenCrudController : ControllerBase
    {
        private readonly IGegoennteBankenCrudLogic gegoennteBankenCrudLogic;

        public GegoennteBankenCrudController(IGegoennteBankenCrudLogic gegoennteBankenCrudLogic)
        {
            this.gegoennteBankenCrudLogic = gegoennteBankenCrudLogic;
        }

        [HttpGet]
        [Authorized]
        public ActionResult<IEnumerable<IGegoennteBank>> GetGegoennteBanken()
        {
            var getGegoennteBankenResult = this.gegoennteBankenCrudLogic.GetGegoennteBanken();
            return this.FromLogicResult(getGegoennteBankenResult);
        }

        [HttpGet]
        [Authorized]
        [Route("{gegoennteBankId}")]
        public ActionResult<IGegoennteBankDetail> GetGegoennteBankDetail(Guid gegoennteBankId)
        {
            var getGegoennteBankDetailResult = this.gegoennteBankenCrudLogic.GetGegoennteBankDetail(gegoennteBankId);
            return this.FromLogicResult(getGegoennteBankDetailResult);
        }

        [HttpPost]
        [Authorized]
        public ActionResult<DataBody<Guid>> CreateGegoennteBank([FromBody] GegoennteBankCreate gegoennteBankCreate)
        {
            ILogicResult<Guid> createGegoennteBankResult = this.gegoennteBankenCrudLogic.CreateGegoennteBank(gegoennteBankCreate);
            if (!createGegoennteBankResult.IsSuccessful)
            {
                return this.FromLogicResult(createGegoennteBankResult);
            }

            return this.Ok(new DataBody<Guid>(createGegoennteBankResult.Data));
        }

        [HttpPut]
        [Authorized]
        public ActionResult UpdateGegoennteBank([FromBody] GegoennteBankUpdate gegoennteBankUpdate)
        {
            ILogicResult updateGegoennteBankResult = this.gegoennteBankenCrudLogic.UpdateGegoennteBank(gegoennteBankUpdate);
            return this.FromLogicResult(updateGegoennteBankResult);
        }

        [HttpDelete]
        [Authorized]
        [Route("{gegoennteBankId}")]
        public ActionResult DeleteGegoennteBank(Guid gegoennteBankId)
        {
            ILogicResult deleteGegoennteBankResult = this.gegoennteBankenCrudLogic.DeleteGegoennteBank(gegoennteBankId);
            return this.FromLogicResult(deleteGegoennteBankResult);
        }
    }
}