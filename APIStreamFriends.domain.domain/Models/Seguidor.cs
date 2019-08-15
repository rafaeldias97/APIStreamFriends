namespace APIStreamFriends.domain.domain.Models
{
    public class Seguidor
    {
        public int id { get; set; }
        public int idClienteSeguidor { get; set; }
        public int idClienteSeguido { get; set; }
    }
}
