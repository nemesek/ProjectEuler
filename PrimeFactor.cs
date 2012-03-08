using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public struct PrimeFactor
    {
        public static readonly PrimeFactor Unity = new PrimeFactor { Prime = 1, Multiplicity = 1 };

        public PrimeFactor(long prime, long multiplicity) : this()
        {
            Prime = prime;
            Multiplicity = multiplicity;
        }

        public long Prime
        {
            get;
            set;
        }

        public long Multiplicity
        {
            get;
            set;
        }

        public long Value
        {
            get
            {
                return (long)Math.Pow(Prime, Multiplicity);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}^{1}", Prime, Multiplicity);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PrimeFactor))
            {
                return false;
            }

            PrimeFactor other = (PrimeFactor)obj;
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Prime.GetHashCode() ^ Multiplicity.GetHashCode();
        }

        public bool Equals(PrimeFactor other)
        {
            return other.Prime == this.Prime && other.Multiplicity == this.Multiplicity;
        }
    }
}
