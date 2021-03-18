using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Entities
{
    public class PrototypeEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

        public IdInfo IdInfo;

        public PrototypeEntity ShallowCopy()
        {
            return (PrototypeEntity)this.MemberwiseClone();
        }

        public PrototypeEntity DeepCopy()
        {
            PrototypeEntity clone = (PrototypeEntity)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            return clone;
        }
    }

    public class IdInfo
    {
        public Guid IdNumber;

        public IdInfo(Guid _IdNumber) => IdNumber = _IdNumber;
    }
}
