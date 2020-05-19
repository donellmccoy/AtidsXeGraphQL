using Prism.Commands;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.Policies
{
    public interface IPolicySearchLegalTreeViewModel
    {
        DelegateCommand SelectPolicySearchLegalCommand { get; set; }
    }
}