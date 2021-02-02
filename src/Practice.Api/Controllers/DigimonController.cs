using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practice.Core.Entities.DigimonAggregate;
using Practice.Core.Features.Digimons.Queries.GetDigimons;
using Serilog.Context;

namespace Practice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DigimonController : ControllerBase
    {
        private readonly ILogger<DigimonController> logger;
        private readonly IMediator mediator;

        public DigimonController(ILogger<DigimonController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        /// <summary>
        ///     Récupère tout les digimons.
        /// </summary>
        /// <returns> Un tableau de digimon. </returns>
        /// <response code="200"> Retourne les digimons recherchés. </response>
        [HttpGet(Name = "GetDigimons")]
        [ProducesResponseType(typeof(Digimon[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDigimons()
        {
            logger.LogInformation("A request to get all digimons started");

            var result = await mediator.Send(new GetDigimonsQuery());

            return Ok(result);
        }
    }
}