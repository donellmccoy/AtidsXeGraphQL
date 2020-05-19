using System;

namespace TheFund.AtidsXe.Data.CompositeKeys {
	public sealed class SubdivisionPlattedLegalCompositeKey
	{
		public int SubdivisionLevelId { get; }
		public int PlatReferenceId { get; }

		public SubdivisionPlattedLegalCompositeKey(int platReferenceId, int subdivisionLevelId)
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

			return PlatReferenceId == ((SubdivisionPlattedLegalCompositeKey)obj).PlatReferenceId &&
				   SubdivisionLevelId == ((SubdivisionPlattedLegalCompositeKey)obj).SubdivisionLevelId;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(SubdivisionLevelId, PlatReferenceId);
		}
	}
}