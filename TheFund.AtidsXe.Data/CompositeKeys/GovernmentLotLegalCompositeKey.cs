using System;

namespace TheFund.AtidsXe.Data.CompositeKeys
{
    public sealed class GovernmentLotLegalCompositeKey
    {
        public int GovernmentLotId { get; }

        public int UnPlattedReferenceId { get; }

        public GovernmentLotLegalCompositeKey(int unplattedReferenceId, int governmentLotId)
        {
            UnPlattedReferenceId = unplattedReferenceId;
            GovernmentLotId = governmentLotId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return UnPlattedReferenceId == ((GovernmentLotLegalCompositeKey)obj).UnPlattedReferenceId && 
                   GovernmentLotId == ((GovernmentLotLegalCompositeKey)obj).GovernmentLotId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GovernmentLotId, UnPlattedReferenceId);
        }
    }
}
