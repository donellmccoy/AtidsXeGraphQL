using ReactiveUI;
using System;
using Telerik.Windows.Data;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.ViewModels;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public sealed class ProfileListItem : ViewModelBase, IProfileListItem
    {
        private bool _isLoaded;
        private string _profileName;
        private string _description;

        public ProfileListItem()
        {
            FileReferences = new RadObservableCollection<IFileReference>();
        }

        public int UserId { get; set; }

        public int ProfileId { get; set; }

        public string ProfileName
        {
            get => _profileName;
            set
            {
                _profileName = value;
                this.RaisePropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsLoaded
        {
            get => _isLoaded;
            set
            {
                _isLoaded = value;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged(nameof(Loaded));
            }
        }

        public string Loaded => _isLoaded ? "Yes" : "No";

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public RadObservableCollection<IFileReference> FileReferences { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (!(obj is ProfileListItem))
            {
                return false;
            }

            return ProfileId == ((ProfileListItem)obj).ProfileId;
        }

        public bool Equals(ProfileListItem other)
        {
            return UserId == other.UserId && ProfileId == other.ProfileId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (UserId.GetHashCode() * 397) ^ ProfileId.GetHashCode();
            }
        }
    }
}