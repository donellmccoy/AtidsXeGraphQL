using System;

namespace TheFund.AtidsXe.Data.CompositeKeys
{
    public sealed class PlattedLegalCompositeKey : IEquatable<PlattedLegalCompositeKey>
    {
        public int SubdivisionLevelId { get; }

        public int PlatReferenceId { get; }

        public PlattedLegalCompositeKey(int platReferenceId, int subdivisionLevelId)
        {
            PlatReferenceId = platReferenceId;
            SubdivisionLevelId = subdivisionLevelId;
        }

        public bool Equals(PlattedLegalCompositeKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return SubdivisionLevelId == other.SubdivisionLevelId && PlatReferenceId == other.PlatReferenceId;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is PlattedLegalCompositeKey other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SubdivisionLevelId, PlatReferenceId);
        }
    }
}
