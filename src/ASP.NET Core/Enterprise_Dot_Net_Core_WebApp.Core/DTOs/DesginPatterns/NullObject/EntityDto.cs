namespace Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns.NullObject
{
    public class EntityDto
    {
        public EntityDto() { }

        public EntityDto(int _ID, string _Name, int _Age)
        {
            ID = _ID;
            Name = _Name;
            Age = _Age;
        }

        public virtual int ID { get; set; } = 1;

        public virtual string Name { get; set; } = "Default value";

        public virtual int? Age { get; set; } = 1;
    }

    public sealed class IsNullEntityDto : EntityDto
    {
        public override int ID => 0;

        public override string Name => "Name empty";

        public override int? Age => 1;
    }
}
