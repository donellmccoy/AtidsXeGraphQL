using Newtonsoft.Json;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    /// <summary>
    /// Class BranchLocation.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BranchLocation
    {
        /// <summary>
        /// Gets or sets the branch location identifier.
        /// </summary>
        /// <value>The branch location identifier.</value>
        [JsonProperty]
        public int BranchLocationId { get; set; }
        /// <summary>
        /// Gets or sets the is internal branch.
        /// </summary>
        /// <value>The is internal branch.</value>
        [JsonProperty]
        public string IsInternalBranch { get; set; }
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        [JsonProperty]
        public string AccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty]
        public string Description { get; set; }
    }
}
