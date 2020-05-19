using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using ReactiveUI;
using Stateless;
using TheFund.AtidsXe.Modules.Common.Models;
using TheFund.AtidsXe.Modules.Search.Enumerations;
using TheFund.AtidsXe.Modules.Search.Factories;
using TheFund.AtidsXe.Modules.Search.ViewModels;
using TheFund.AtidsXe.Modules.Services.Search;

namespace TheFund.AtidsXe.Modules.Search.StateMachines
{
    internal sealed class SearchStateMachine : SearchStateMachineBase, ISearchStateMachine
    {
        private readonly ISubject<ISearchResponse> _searchSubject;
        private readonly ISearchViewModel _searchViewModel;
        private readonly ISearchService _searchService;

        private StateMachine<SearchState, SearchTrigger>.TriggerWithParameters<ISearchRequest> _userKeysSearchTerm;
        private StateMachine<SearchState, SearchTrigger>.TriggerWithParameters<ISearchRequest> _userSelectsSearchTerm;

        internal SearchStateMachine(ISearchViewModel searchViewModel,  ISearchService searchService)
        {
            _searchViewModel = searchViewModel;
            _searchService = searchService;

            CreateStateMachine();
        }

        public void KeySearchTerm(ISearchRequest request)
        {
            StateMachine.Fire(_userKeysSearchTerm, request);
        }

        public void SelectSearchTerm(ISearchRequest request)
        {
            StateMachine.Fire(_userSelectsSearchTerm, request);
        }

        public void Cancel()
        {
            StateMachine.Fire(SearchTrigger.UserCancelsSearch);
        }

        private void CreateStateMachine()
        {
            CreateParameters();

            Configure(SearchState.Idle)
                .OnEntry(LogTransition)
                .Permit(SearchTrigger.UserKeysSearchTerm, SearchState.Searching)
                .Permit(SearchTrigger.UserSelectsSearchTerm, SearchState.Searching);

            Configure(SearchState.Searching)
                .OnEntry(LogTransition)
                .OnEntryFrom(_userKeysSearchTerm, OnEntryUserKeysSearchTerm)
                .OnEntryFrom(_userSelectsSearchTerm, OnEntrySelectsSearchTerm)
                .PermitReentry(SearchTrigger.UserKeysSearchTerm)
                .PermitReentry(SearchTrigger.UserSelectsSearchTerm)
                .Permit(SearchTrigger.ServerSendsSearchResults, SearchState.Searched)
                .Permit(SearchTrigger.UserCancelsSearch, SearchState.Cancelling)
                .Permit(SearchTrigger.InternalError, SearchState.Error);

            Configure(SearchState.Searched)
                .OnEntry(LogTransition)
                .OnEntryFrom(SearchTrigger.ServerSendsSearchResults, OnEntrySearched)
                .Permit(SearchTrigger.UserCancelsSearch, SearchState.Cancelling)
                .Permit(SearchTrigger.InternalError, SearchState.Error);

            Configure(SearchState.Cancelling)
                .OnEntry(LogTransition)
                .OnEntryFrom(SearchTrigger.UserCancelsSearch, OnEntryCancelling)
                .Permit(SearchTrigger.ServerCancelled, SearchState.Cancelled);

            Configure(SearchState.Cancelled)
                .OnEntry(LogTransition)
                .OnEntry(OnEntryCancelled);

            Configure(SearchState.Error)
                .OnEntry(LogTransition)
                .OnEntryFrom(SearchTrigger.InternalError, OnEntryError);
        }

        private static void OnEntryError()
        {
            
        }

        private static void OnEntryCancelled()
        {
            
        }

        private static void OnEntrySearched()
        {
            
        }

        private static void OnEntryCancelling()
        {

        }

        private void OnEntryUserKeysSearchTerm(ISearchRequest request)
        {
        }

        private static void OnEntrySelectsSearchTerm(ISearchRequest request)
        {
            
        }

        private void CreateParameters()
        {
            _userKeysSearchTerm = CreateTriggerWithParameter<ISearchRequest>(SearchTrigger.UserKeysSearchTerm);
            _userSelectsSearchTerm = CreateTriggerWithParameter<ISearchRequest>(SearchTrigger.UserSelectsSearchTerm);
        }

        public void Dispose()
        {
            
        }
    }
}
