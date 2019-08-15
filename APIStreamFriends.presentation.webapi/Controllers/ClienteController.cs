using System.Threading.Tasks;
using APIStreamFriends.domain.domain.Interfaces;
using APIStreamFriends.domain.domain.Models;
using APIStreamFriends.presentation.webapi.Models;
using APIStreamFriends.presentation.webapi.Swagger.Example;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;

namespace APIStreamFriends.presentation.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : BaseController
    {
        private readonly IClienteRepository repository;
        public ClienteController(IMapper mapper, IClienteRepository repository)
            : base(mapper)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Recupera todos os clientes
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await repository.AllAsync();
            return Ok(res);
        }

        /// <summary>
        /// Cadastrar um cliente
        /// </summary>
        [HttpPost]
        [SwaggerRequestExample(typeof(ClienteVM), typeof(ClienteVMEx))]
        public async Task<IActionResult> Post([FromBody] ClienteVM cliente)
        {
            var _cliente = mapper.Map<Cliente>(cliente);
            await repository.SaveAsync(_cliente);
            return Ok();
        }

        /// <summary>
        /// Altera um cliente
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cliente cliente)
        {
            var res = await repository.UpdateAsync(cliente);
            return Ok(res);
        }

        /// <summary>
        /// Deleta um cliente
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Cliente cliente)
        {
            await repository.DeleteAsync(cliente);
            return Ok();
        }
    }
}