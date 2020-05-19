using System;

namespace TheFund.AtidsXe.Data.CompositeKeys
{
    public sealed class TitleEventPlattedLegalMqlCompositeKey
    {
        public int SubdivisionLevelId { get; }
        public int PlatReferenceId { get; }

        public TitleEventPlattedLegalMqlCompositeKey(int platReferenceId, int subdivisionLevelId)
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

            return PlatReferenceId == ((TitleEventPlattedLegalMqlCompositeKey)obj).PlatReferenceId &&
                   SubdivisionLevelId == ((TitleEventPlattedLegalMqlCompositeKey)obj).SubdivisionLevelId;
        }

        public override int GetHashCode()
        {
			return HashCode.Combine(SubdivisionLevelId, PlatReferenceId);
        }
    }
}
