using APIStreamFriends.domain.domain.Interfaces;
using APIStreamFriends.domain.domain.Models;
using APIStreamFriends.presentation.webapi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APIStreamFriends.presentation.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguidorController : BaseController
    {
        private readonly ISeguidorRepository repository;
        public SeguidorController(IMapper mapper, ISeguidorRepository repository)
            : base(mapper)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Recupera amigos
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var res = repository.FindBy(x => x.idClienteSeguidor == id);
            return Ok(res);
        }

        /// <summary>
        /// Seguir
        /// </summary>
        [HttpPost]
        //[SwaggerRequestExample(typeof(ClienteVM), typeof(ClienteVMEx))]
        public async Task<IActionResult> Post([FromBody] SeguidorVM seguidor)
        {
            var _seguidor = mapper.Map<Seguidor>(seguidor);
            await repository.SaveAsync(_seguidor);
            return Ok();
        }

        /// <summary>
        /// Deixar de seguir
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Seguidor seguidor)
        {
            await repository.DeleteAsync(seguidor);
            return Ok();
        }
    }
}