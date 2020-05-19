using TheFund.AtidsXe.Modules.Common.Models;
using TheFund.AtidsXe.Modules.Services.Search;

namespace TheFund.AtidsXe.Modules.Search.StateMachines
{
    internal interface ISearchStateMachine : IStateMachine
    {
        void Cancel();
        void KeySearchTerm(ISearchRequest request);
        void SelectSearchTerm(ISearchRequest request);
    }
}
