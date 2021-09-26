namespace Api.Domain.Models
{
    public class TrainerModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _region;
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}
