﻿using Microsoft.EntityFrameworkCore;

namespace TodoList_MySQL.Specification
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(
            IQueryable<T> inputQuery,
            ISpecification<T> specification)
        {
            var query = inputQuery;

            if(specification.Criteria != null) query = query.Where(specification.Criteria);

            if (specification.OrderBy != null) query = query.OrderBy(specification.OrderBy);

            if (specification.OrderByDescending != null) query = query.OrderByDescending(specification.OrderByDescending);

            if (specification.IsPagingEnabled) query = query.Skip(specification.Skip).Take(specification.Take);

            query = specification.Include.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
