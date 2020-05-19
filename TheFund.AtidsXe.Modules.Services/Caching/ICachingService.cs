using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace TheFund.AtidsXe.Modules.Services.Caching
{
    public interface ICachingService
    {
        Task<T> AddOrGetExistingAsync<T>(int key, [NotNull] Func<Task<T>> valueFactory);
        Task<T> AddOrGetExistingAsync<T>([NotNull] string key, [NotNull] Func<Task<T>> valueFactory);
        void Remove(int key);
        void Remove([NotNull] string key);
        void Remove([NotNull] string key, [NotNull] string region);
        void Remove([NotNull] IEnumerable<int> keys);
        void Remove([NotNull] IEnumerable<string> keys);
        Task<T> AddOrGetExistingAsync<T>([NotNull] string key, [NotNull] string region, [NotNull] Func<Task<T>> valueFactory);
        Task<T> AddOrGetExistingAsync<T>(int key, [NotNull] string region, [NotNull] Func<Task<T>> valueFactory);
        Task<T> RemoveAsync<T>([NotNull] string key, [NotNull] string region, [NotNull] Func<Task<T>> deleteValueFactory);
        ValueTask<T> AddOrGetExistingAsync<T>(string key, string region, Func<ValueTask<T>> valueFactory);
		void Remove(int key, string region);
		Task<T> RemoveAsync<T>(int key, string region, Func<Task<T>> deleteValueFactory);
	}
}