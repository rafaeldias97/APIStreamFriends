using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIStreamFriends.presentation.webapi.Controllers
{
    public class BaseController : ControllerBase
    {
        public IMapper mapper { get; set; }
        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}