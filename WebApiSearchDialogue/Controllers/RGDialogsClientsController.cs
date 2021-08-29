using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Net.Mime;
using System;
using System.Collections.Generic;
using Application.RGDialogsClients.Queries.GetRGDialogsClientsList;

namespace WebApiSearchDialogue.Controllers
{
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    [Route("api/datagame")]
    public class RGDialogsClientsController : BaseController
    {
        private readonly ILogger<RGDialogsClientsController> _logger;
        public RGDialogsClientsController(ILogger<RGDialogsClientsController> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Получение уровня достоверности экстрасенсов 
        /// в конце раунда 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET / EndRound
        /// </remarks>
        /// <returns>Returns DataGame</returns>
        /// <response code="200">Удачное выполнение запроса</response>
        /// <response code="400">Переданное значение не в рамках
        /// допустимого диапазона</response>
        [HttpPost]
        [Route("endround")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DialogListVm>> ListIDRGDialog([FromBody] List<Guid> clients)
        {
            GetDialogListQuery getDialogList = new()
            {
                Clients = clients
            };
            var dg = await Mediator.Send(getDialogList);
            return Ok(dg);
        }
    }
}
