using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _applicationService;

        public FornecedorController(IFornecedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Recupera todos os dados dos fornecedores.
        /// </summary>
        /// <returns>Uma coleção de fornecedores.</returns>
        [HttpGet]
        [Produces<IEnumerable<FornecedorEntity>>]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosFornecedores();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível recuperar os dados");
        }

        /// <summary>
        /// Obtém as informações de um fornecedor específico pelo ID.
        /// </summary>
        /// <param name="id">ID do fornecedor.</param>
        /// <returns>Os dados do fornecedor correspondente.</returns>
        [HttpGet("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterFornecedorPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível recuperar os dados");
        }

        /// <summary>
        /// Registra os dados de um novo fornecedor.
        /// </summary>
        /// <param name="entity">Informações do fornecedor a ser registrado.</param>
        /// <returns>Os dados do fornecedor registrado.</returns>
        [HttpPost]
        [Produces<FornecedorEntity>]
        public IActionResult Post([FromBody] FornecedorDto entity)
        {
            try
            {
                var objModel = _applicationService.SalvarDadosFornecedor(entity);

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
        /// Atualiza as informações de um fornecedor existente.
        /// </summary>
        /// <param name="id">ID do fornecedor a ser atualizado.</param>
        /// <param name="entity">Dados atualizados do fornecedor.</param>
        /// <returns>Os dados do fornecedor atualizado.</returns>
        [HttpPut("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult Put(int id, [FromBody] FornecedorDto entity)
        {
            try
            {
                var objModel = _applicationService.EditarDadosFornecedor(id, entity);

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
        /// Remove um fornecedor específico pelo ID.
        /// </summary>
        /// <param name="id">ID do fornecedor a ser removido.</param>
        /// <returns>Os dados do fornecedor removido.</returns>
        [HttpDelete("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosFornecedor(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível remover os dados");
        }
    }
}
