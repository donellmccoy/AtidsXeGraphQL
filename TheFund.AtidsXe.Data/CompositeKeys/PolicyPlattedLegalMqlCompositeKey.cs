using System;

namespace TheFund.AtidsXe.Data.CompositeKeys
{
    public sealed class PolicyPlattedLegalMqlCompositeKey
    {
        public int SubdivisionLevelId { get; }
        public int PlatReferenceId { get; }

        public PolicyPlattedLegalMqlCompositeKey(int platReferenceId, int subdivisionLevelId)
        {
            PlatReferenceId = platReferenceId;
            SubdivisionLevelId = subdivisionLevelId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return PlatReferenceId == ((PolicyPlattedLegalMqlCompositeKey)obj).PlatReferenceId &&
                   SubdivisionLevelId == ((PolicyPlattedLegalMqlCompositeKey)obj).SubdivisionLevelId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SubdivisionLevelId, PlatReferenceId);
        }
    }
}
