using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TheFund.AtidsXe.Data.Respositories;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public abstract class ObjectGraphTypeBase<TSourceType> : ObjectGraphType<TSourceType>
    {
        public IGenericRepository _genericRepository { get; }

        protected ObjectGraphTypeBase(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        protected void Field<TGraphType>(string name, Func<ResolveFieldContext<TSourceType>, object> resolve = null, QueryArguments arguments = null) 
            where TGraphType : IGraphType
        {
            Field<TGraphType>
            (
                name,
                name,
                arguments,
                resolve
            );
        }

        protected void FieldList<TGraph, TReturn, TKey>(string fieldName, Func<TSourceType, TKey> keySelector1, Expression<Func<TReturn, TKey>> keySelector2)
            where TGraph : IGraphType
            where TReturn : class
        {
            Field<ListGraphType<TGraph>, IEnumerable<TReturn>>()
                .Name(fieldName)
                .ResolveAsync(context =>
                {
                    var key = keySelector1.Invoke(context.Source);
                    return _genericRepository.LoadCollectionAsync(fieldName, key, keySelector2);
                });
        }

        protected void FieldListAsync<TGraph, TReturn>(string fieldName, Func<TSourceType, int> keySelector1, Expression<Func<TReturn, int>> keySelector2)
            where TGraph : IGraphType
            where TReturn : class
        {
            FieldAsync<ListGraphType<TGraph>, IEnumerable<TReturn>>
            (
                fieldName,
                null,
                null,
                context =>
                {
                    var key = keySelector1.Invoke(context.Source);
                    return _genericRepository.LoadCollectionAsync(fieldName, key, keySelector2);
                });
        }

		protected void FieldListAsync<TGraph, TReturn, TKey>(
            string fieldName,
            Func<TSourceType, TKey> keySelector1,
            Expression<Func<TReturn, TKey>> keySelector2)
			where TGraph : IGraphType
			where TReturn : class
		{
			FieldAsync<ListGraphType<TGraph>, IEnumerable<TReturn>>
				(
				 fieldName,
				 null,
				 null,
				 context =>
				 {
					 var key = keySelector1.Invoke(context.Source);
					 return _genericRepository.LoadCollectionAsync(fieldName, key, keySelector2);
				 });
		}

        protected void Field<TGraph, TReturn, TKey>(
            string fieldName,
            Expression<Func<TSourceType, TKey>> keySelector1,
            Expression<Func<TReturn, TKey>> keySelector2)
            where TReturn : class
        {
            Field<TGraph, TReturn>()
                .Name(fieldName)
                .ResolveAsync(context =>
                {
                    var key = keySelector1.Compile().Invoke(context.Source);
                    return _genericRepository.LoadObjectAsync(fieldName, keySelector2).LoadAsync(key);
                });
        }

        protected void Field<TGraph, TReturn>(
            string fieldName,
            Func<TSourceType, int> keySelector1,
            Expression<Func<TReturn, int>> keySelector2)
            where TReturn : class
        {
            Field<TGraph, TReturn>()
                .Name(fieldName)
                .ResolveAsync(context =>
                {
                    var key = keySelector1.Invoke(context.Source);
                    return _genericRepository.LoadObjectAsync(fieldName, keySelector2).LoadAsync(key);
                });
        }

        protected void Field<TGraph, TReturn>(
            string fieldName,
            Func<TSourceType, ValueTuple<int, int>> keySelector,
            Expression<Func<TReturn, ValueTuple<int, int>>> predicate)
            where TReturn : class
        {
            Field<TGraph, TReturn>()
                .Name(fieldName)
                .ResolveAsync(context =>
                {
                    var key = keySelector.Invoke(context.Source);
                    return _genericRepository.LoadObjectAsync(fieldName, predicate)
                                             .LoadAsync(key);
                });
        }
    }
}