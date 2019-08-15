using APIStreamFriends.presentation.webapi.Models;
using Swashbuckle.AspNetCore.Examples;
using System;

namespace APIStreamFriends.presentation.webapi.Swagger.Example
{
    public class ClienteVMEx : IExamplesProvider
    {
        public object GetExamples()
        {
            return new ClienteVM
            {
                email = "teste@teste.com",
                descricao = "Alguma coisa",
                imgPerfil = "www.url.com",
                imgMural = "www.url.com",
                senha = "teste",
                dataNascimento = DateTime.Now,
                sexo = 1
            };
        }
    }
}