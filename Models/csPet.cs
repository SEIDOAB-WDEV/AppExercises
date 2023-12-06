using System;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace Models
{    
    public enum enAnimalKind { Dog, Cat, Rabbit, Fish, Bird };
    public enum enAnimalMood { Happy, Hungry, Lazy, Sulky, Buzy, Sleepy };
    public class csPet : ISeed<csPet>
    {
        public virtual Guid PetId { get; set; } = Guid.NewGuid();

        public virtual enAnimalKind Kind { get; set; }
        public virtual enAnimalMood Mood { get; set; }

        public virtual string Name { get; set; }

        public override string ToString() => $"{Name} the {Mood} {Kind}";

        #region constructors
        public csPet() { }
        public csPet(csPet org)
        {
            this.Seeded = org.Seeded;

            this.PetId = org.PetId;
            this.Kind = org.Kind;
            this.Name = org.Name;
        }
        #endregion

        #region randomly seed this instance
        public bool Seeded { get; set; } = false;

        public virtual csPet Seed(csSeedGenerator sgen)
        {
            Seeded = true;

            PetId = Guid.NewGuid();
            Name = sgen.PetName;
            Kind = sgen.FromEnum<enAnimalKind>();
            Mood = sgen.FromEnum<enAnimalMood>();

            return this;
        }
        #endregion
    }
}

