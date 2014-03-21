﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NinjaNye.SearchExtensions.Fluent;
using NinjaNye.SearchExtensions.Helpers;
using NinjaNye.SearchExtensions.Validation;

namespace NinjaNye.SearchExtensions
{
    public static class SearchEnumerableExtensions
    {
        /// <summary>
        /// Search ALL string properties for a particular search term in memory
        /// </summary>
        /// <param name="source">Source data to query</param>
        /// <param name="searchTerm">search term to look for</param>
        /// <returns>Queryable records where the any string property contains the search term</returns>
        [Obsolete("This method has been superseded by the fluent api. Please use the Fluent API http://jnye.co/fluent")]
        public static IEnumerable<T> Search<T>(this IEnumerable<T> source, string searchTerm)
        {
            if (String.IsNullOrEmpty(searchTerm))
            {
                return source;
            }

            var stringProperties = EnumerableExpressionHelper.GetProperties<T, string>();
            return source.Search(new[] { searchTerm }, stringProperties);
        }

        /// <summary>
        /// Search ALL string properties for a particular search term in memory
        /// </summary>
        /// <param name="source">Source data to query</param>
        /// <param name="searchTerm">search term to look for</param>
        /// <param name="stringComparison">Enumeration value that specifies how the strings will be compared.</param>
        /// <returns>Queryable records where the any string property contains the search term</returns>
        [Obsolete("This method has been superseded by the fluent api. Please use the Fluent API http://jnye.co/fluent")]
        public static IEnumerable<T> Search<T>(this IEnumerable<T> source, string searchTerm, StringComparison stringComparison)
        {
            if (String.IsNullOrEmpty(searchTerm))
            {
                return source;
            }

            var stringProperties = EnumerableExpressionHelper.GetProperties<T, string>();
            return source.Search(new[] { searchTerm }, stringProperties, stringComparison);
        }

        /// <summary>
        /// Search a particular property for a particular search term in memory.
        /// </summary>
        /// <param name="source">Source data to query</param>
        /// <param name="stringProperty">String property to search</param>
        /// <param name="searchTerm">search term to look for</param>
        /// <returns>Enumerable records where the property contains the search term</returns>
        [Obsolete("This method has been superseded by the fluent api. Please use the Fluent API http://jnye.co/fluent")]
        public static IEnumerable<T> Search<T>(this IEnumerable<T> source, string searchTerm, Expression<Func<T, string>> stringProperty)
        {
            return source.Search(searchTerm, stringProperty, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Search a particular property for a particular search term in memory.
        /// </summary>
        /// <param name="source">Source data to query</param>
        /// <param name="stringProperty">String property to search</param>
        /// <param name="searchTerm">search term to look for</param>
        /// <param name="stringComparison">Enumeration value that specifies how the strings will be compared.</param>
        /// <returns>Enumerable records where the property contains the search term</returns>
        [Obsolete("This method has been superseded by the fluent api. Please use the Fluent API http://jnye.co/fluent")]
        public static IEnumerable<T> Search<T>(this IEnumerable<T> source, string searchTerm, Expression<Func<T, string>> stringProperty, StringComparison stringComparison)
        {
            Ensure.ArgumentNotNull(stringProperty, "stringProperty");

            if (String.IsNullOrEmpty(searchTerm))
            {
                return source;
            }

            return source.Search(new[] {searchTerm}, new[] {stringProperty}, stringComparison);
        }

        /// <summary>
        /// Search multiple properties for a particular search term in memory.
        /// </summary>
        /// <param name="source">Source data to query</param>
        /// <param name="searchTerm">search term to look for</param>
        /// <param name="stringProperties">properties to search against</param>
        /// <returns>Enumerable records where any property contains the search term</returns>
        [Obsolete("This method has been superseded by the fluent api. Please use the Fluent API http://jnye.co/fluent")]
        public static IEnumerable<T> Search<T>(this IEnumerable<T> source, string searchTerm, params Expression<Func<T, string>>[] stringProperties)
        {
            Ensure.ArgumentNotNull(stringProperties, "stringProperties");

            if (String.IsNullOrEmpty(searchTerm))
            {
                return source;
            }

            return source.Search(new[] { searchTerm }, stringProperties, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Search multiple properties for a particular search term in memory.
        /// </summary>
        /// <param name="source">Source data to query</param>
        /// <param name="searchTerm">search term to look for</param>
        /// <param name="stringComparison">Enumeration value that specifies how the strings will be compared.</param>
        /// <param name="stringProperties">properties to search against</param>
        /// <returns>Enumerable records where any property contains the search term</returns>
        [Obsolete("This method has been superseded by the fluent api. Please use the Fluent API http://jnye.co/fluent")]
        public static IEnumerable<T> Search<T>(this IEnumerable<T> source, string searchTerm, Expression<Func<T, string>>[] stringProperties, StringComparison stringComparison)
        {
            Ensure.ArgumentNotNull(stringProperties, "stringProperties");

            if (String.IsNullOrEmpty(searchTerm))
            {
                return source;
            }

            return source.Search(new[] { searchTerm }, stringProperties, stringComparison);
        }

        /// <summary>
        /// Search a property for multiple search terms in memory.  
        /// </summary>
        /// <param name="source">Source data to query</param>
        /// <param name="searchTerms">search terms to find</param>
        /// <param name="stringProperty">properties to search against</param>
        /// <returns>Enumerable records where the property contains any of the search terms</returns>
        [Obsolete("This method has been superseded by the fluent api. Please use the Fluent API http://jnye.co/fluent")]
        public static IEnumerable<T> Search<T>(this IEnumerable<T> source, string[] searchTerms, Expression<Func<T, string>> stringProperty)
        {
            Ensure.ArgumentNotNull(stringProperty, "stringProperty");
            Ensure.ArgumentNotNull(searchTerms, "searchTerms");

            return source.Search(searchTerms, new[] { stringProperty }, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Search a property for multiple search terms in memory.  
        /// </summary>
        /// <param name="source">Source data to query</param>
        /// <param name="stringComparison">Enumeration value that specifies how the strings will be compared.</param>
        /// <param name="searchTerms">search terms to find</param>
        /// <param name="stringProperty">properties to search against</param>
        /// <returns>Enumerable records where the property contains any of the search terms</returns>
        [Obsolete("This method has been superseded by the fluent api. Please use the Fluent API http://jnye.co/fluent")]
        public static IEnumerable<T> Search<T>(this IEnumerable<T> source, string[] searchTerms, Expression<Func<T, string>> stringProperty, StringComparison stringComparison)
        {
            Ensure.ArgumentNotNull(stringProperty, "stringProperty");
            Ensure.ArgumentNotNull(searchTerms, "searchTerms");

            return source.Search(searchTerms, new[]{stringProperty}, stringComparison);
        }

        /// <summary>
        /// Search multiple properties for multiple search terms in memory
        /// </summary>
        /// <param name="source">Source data to query</param>
        /// <param name="searchTerms">search term to look for</param>
        /// <param name="stringProperties">properties to search against</param>
        /// <returns>Enumerable records where any property contains any of the search terms</returns>
        [Obsolete("This method has been superseded by the fluent api. Please use the Fluent API http://jnye.co/fluent")]
        public static IEnumerable<T> Search<T>(this IEnumerable<T> source, string[] searchTerms, params Expression<Func<T, string>>[] stringProperties)
        {
            Ensure.ArgumentNotNull(searchTerms, "searchTerms");
            Ensure.ArgumentNotNull(stringProperties, "stringProperties");

            return source.Search(searchTerms, stringProperties, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Search multiple properties for multiple search terms in memory
        /// </summary>
        /// <param name="source">Source data to query</param>
        /// <param name="searchTerms">search term to look for</param>
        /// <param name="stringProperties">properties to search against</param>
        /// <param name="stringComparison">Enumeration value that specifies how the strings will be compared.</param>
        /// <returns>Enumerable records where any property contains any of the search terms</returns>
        [Obsolete("This method has been superseded by the fluent api. Please use the Fluent API http://jnye.co/fluent")]
        public static IEnumerable<T> Search<T>(this IEnumerable<T> source, string[] searchTerms, Expression<Func<T, string>>[] stringProperties, StringComparison stringComparison)
        {
            Ensure.ArgumentNotNull(searchTerms, "searchTerms");
            Ensure.ArgumentNotNull(stringProperties, "stringProperties");
            return source.Search(stringProperties).SetCulture(stringComparison).Containing(searchTerms);
        }
    }
}