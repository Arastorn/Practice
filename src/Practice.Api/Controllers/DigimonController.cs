using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practice.Api.Models.Digimons;
using Practice.Core.Entities.DigimonAggregate;
using Practice.Core.Features.Digimons.Commands.CreateDigimon;
using Practice.Core.Features.Digimons.Commands.UpdateDigimon;
using Practice.Core.Features.Digimons.Queries.GetDigimonById;
using Practice.Core.Features.Digimons.Queries.GetDigimons;

namespace Practice.Api.Controllers
{
    [ApiController]
    [Route("Digimons")]
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

        /// <summary>
        ///     Get a digimon by his id.
        /// </summary>
        /// /// <param name="id"> id of digimon. </param>
        /// <returns> a digimon. </returns>
        /// <response code="200"> Digimon that match the id. </response>
        [HttpGet("{id:guid}", Name = "GetDigimonById")]
        [ProducesResponseType(typeof(Digimon), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetDigimonById(Guid id)
        {
            logger.LogInformation("A request to get a digimon by this id : {Id} started", id);

            var result = await mediator.Send(new GetDigimonByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        ///     Récupère tout les digimons.
        /// </summary>
        /// <param name="request"> the digimon that we want to create.</param>
        /// <returns> Un tableau de digimon. </returns>
        /// <response code="200"> Retourne les digimons recherchés. </response>
        [HttpPost(Name = "CreateDigimon")]
        [ProducesResponseType(typeof(Digimon), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDigimon(CreateDigimonRequest request)
        {
            logger.LogInformation("A request to create a digimon started");

            var result = await mediator.Send(new CreateDigimonCommand(request.Nom, request.Niveau));

            return Ok(result);
        }

        /// <summary>
        ///    Update digimon by id.
        /// </summary>
        /// <param name="request"> the digimon that we want to update.</param>
        /// <returns> Un tableau de digimon. </returns>
        /// <response code="204"> Everything is fine. </response>
        [HttpPut(Name = "UpdateDigimon")]
        [ProducesResponseType(typeof(Digimon), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateDigimon(UpdateDigimonRequest request)
        {
            logger.LogInformation("A request to update a digimon started with this Id : {Id}", request.Id);
            await mediator.Send(new UpdateDigimonCommand(request.Id, request.Nom, request.Niveau));

            return NoContent();
        }
    }
}