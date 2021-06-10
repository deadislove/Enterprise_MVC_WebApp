namespace Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns
{
    public class PrivateDataClass
    {
        public int ID { get; }

        public string Name { get; }

        public int? Age { get; }

        public PrivateDataClass(int _id, string _name, int _age)
        {
            this.ID = _id;
            this.Name = _name;
            this.Age = _age;
        }
    }
}
