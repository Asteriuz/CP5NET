using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorApplicationService _applicationService;

        public VendedorController(IVendedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Método para recuperar todos os dados do Vendedor.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<VendedorEntity>>]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosVendedores();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível recuperar os dados");
        }

        /// <summary>
        /// Obtém as informações de um vendedor específico pelo ID.
        /// </summary>
        /// <param name="id">ID do vendedor.</param>
        /// <returns>Os dados do vendedor correspondente.</returns>
        [HttpGet("{id}")]
        [Produces<VendedorEntity>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterVendedorPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível recuperar os dados");
        }

        /// <summary>
        /// Registra os dados de um novo vendedor.
        /// </summary>
        /// <param name="entity">Informações do vendedor a ser registrado.</param>
        /// <returns>Os dados do vendedor registrado.</returns>
        [HttpPost]
        [Produces<VendedorEntity>]
        public IActionResult Post([FromBody] VendedorDto entity)
        {
            try
            {
                var objModel = _applicationService.SalvarDadosVendedor(entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possível registrar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Atualiza as informações de um vendedor existente.
        /// </summary>
        /// <param name="id">ID do vendedor a ser atualizado.</param>
        /// <param name="entity">Dados atualizados do vendedor.</param>
        /// <returns>Os dados do vendedor atualizado.</returns>
        [HttpPut("{id}")]
        [Produces<VendedorEntity>]
        public IActionResult Put(int id, [FromBody] VendedorDto entity)
        {
            try
            {
                var objModel = _applicationService.EditarDadosVendedor(id, entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possível atualizar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Remove um vendedor específico pelo ID.
        /// </summary>
        /// <param name="id">ID do vendedor a ser removido.</param>
        /// <returns>Os dados do vendedor removido.</returns>
        [HttpDelete("{id}")]
        [Produces<VendedorEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosVendedor(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível remover os dados");
        }
    }
}
