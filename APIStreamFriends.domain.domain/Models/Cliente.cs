using System;
using System.Collections.Generic;
using System.Text;

namespace APIStreamFriends.domain.domain.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string email { get; set; }
        public string descricao { get; set; }
        public string imgPergil { get; set; }
        public string imgMural { get; set; }
        public string senha { get; set; }
        public DateTime dataNascimento { get; set; }
        public byte sexo { get; set; }
    }
}
