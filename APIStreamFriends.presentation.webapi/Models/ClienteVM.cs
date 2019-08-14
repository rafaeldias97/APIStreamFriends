using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIStreamFriends.presentation.webapi.Models
{
    public class ClienteVM
    {
        public string email { get; set; }
        public string descricao { get; set; }
        public string imgPerfil { get; set; }
        public string imgMural { get; set; }
        public string senha { get; set; }
        public DateTime dataNascimento { get; set; }
        public byte sexo { get; set; }
    }
}
