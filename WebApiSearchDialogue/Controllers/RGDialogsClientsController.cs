using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Net.Mime;
using System;
using System.Collections.Generic;
using Application.RGDialogsntsFolder.Queries.GetRGDialogsClientsList;

namespace WebApiSearchDialogue.Controllers
{
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    [Route("api/[controller]")]
    public class RGDialogsClientsController : BaseController
    {
        private readonly ILogger<RGDialogsClientsController> _logger;
        public RGDialogsClientsController(ILogger<RGDialogsClientsController> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// поиск диалога в котором есть все переданные клиенты. Если такого
        /// диалога нет, то возвращается пустой GUID.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET / ListIDRGDialog  
        /// Тестовые данные клиентов: 
        /// "4b6a6b9a-2303-402a-9970-6e71f4a47151",
        /// "c72e5cb5-d6b4-4c0c-9992-d7ae1c53a820",
        /// "7de3299b-2796-4982-a85b-2d6d1326396e",
        /// "0a58955e-342f-4095-88c6-1109d0f70583",
        /// "50454d55-a73c-4cbc-be25-3c5729dcb82b"
        /// </remarks>
        /// <returns>Returns DataGame</returns>
        /// <response code="200">Удачное выполнение запроса</response>
        /// <response code="404">Переданное значение не обнаружено 
        /// в коллекции данных</response>
        /// <response code="400">В тело запроса был передан не список Guid</response>
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
