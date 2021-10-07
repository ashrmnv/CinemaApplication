﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CinemaApp.Common.Models;
using CinemaApp.Domain;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Text;

namespace CinemaApp.DAL.Extensions
{
    public static class QueryableExtensions
    {
        public static PaginatedResult<T> CreatePaginatedResult<T>(this IQueryable<T> query, PagedRequest pagedRequest) //, IMapper mapper
            where T : Entity
        {
            query = query.ApplyFilters(pagedRequest);

            var total = query.Count();

            query = query.Paginate(pagedRequest);

            var projectionResult = query.Sort(pagedRequest);

            var listResult = projectionResult.ToList();

            return new PaginatedResult<T>()
            {
                Items = listResult,
                PageSize = pagedRequest.PageSize,
                PageIndex = pagedRequest.PageIndex,
                Total = total
            };
        }
        private static IQueryable<T> Paginate<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            var entities = query.Skip(pagedRequest.PageIndex * pagedRequest.PageSize).Take(pagedRequest.PageSize);
            return entities;
        }

        private static IQueryable<T> Sort<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            if (!string.IsNullOrWhiteSpace(pagedRequest.ColumnNameForSorting))
            {
                query = query.OrderBy(pagedRequest.ColumnNameForSorting + " " + pagedRequest.SortDirection);
            }
            return query;
        }

        private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            var predicate = new StringBuilder();
            var requestFilters = pagedRequest.RequestFilters;
            for (int i = 0; i < requestFilters.Filters.Count; i++)
            {
                if (i > 0)
                {
                    predicate.Append($" {requestFilters.LogicalOperators} ");
                }
                predicate.Append(requestFilters.Filters[i].Path + $".{nameof(string.Contains)}(@{i})");
            }

            if (requestFilters.Filters.Any())
            {
                var propertyValues = requestFilters.Filters.Select(filter => filter.Value).ToArray();

                query = query.Where(predicate.ToString(), propertyValues);
            }

            return query;
        }
    }
}