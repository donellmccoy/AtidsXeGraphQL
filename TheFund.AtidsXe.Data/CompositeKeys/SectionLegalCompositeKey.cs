using System;

namespace TheFund.AtidsXe.Data.CompositeKeys
{
    public sealed class SectionLegalCompositeKey
    {
        public int UnplattedReferenceId { get; }

        public int SectionBreakdownCodeId { get; }

        public SectionLegalCompositeKey(int unplattedReferenceId, int sectionBreakdownCodeId)
        {
            UnplattedReferenceId = unplattedReferenceId;
            SectionBreakdownCodeId = sectionBreakdownCodeId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return SectionBreakdownCodeId == ((SectionLegalCompositeKey)obj).SectionBreakdownCodeId &&
                   UnplattedReferenceId == ((SectionLegalCompositeKey)obj).UnplattedReferenceId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SectionBreakdownCodeId, UnplattedReferenceId);
        }
    }
}
