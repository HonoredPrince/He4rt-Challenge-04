namespace Api.Domain.Models
{
    public class PokemonModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        private string _attribute;
        public string Attribute
        {
            get { return _attribute; }
            set { _attribute = value; }
        }
    }
}
