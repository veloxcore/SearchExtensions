using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NinjaNye.SearchExtensions.Levenshtein;
using NinjaNye.SearchExtensions.Soundex;

namespace NinjaNye.SearchExtensions.Helpers.ExpressionBuilders
{
    internal static class ExpressionMethods
    {
        #region Contants
        public static readonly ConstantExpression EmptyStringExpression = Expression.Constant(string.Empty);
        public static readonly ConstantExpression NullExpression = Expression.Constant(null);
        public static readonly ConstantExpression ZeroConstantExpression = Expression.Constant(0);
        #endregion

        #region Properties
        public static readonly PropertyInfo StringLengthProperty = typeof(string).GetTypeInfo().DeclaredProperties.First(o => o.Name.Equals("Length"));
        #endregion

        #region Methods

        public static readonly MethodInfo IndexOfMethod = typeof(string).GetRuntimeMethod("IndexOf", new[] { typeof(string) });
        public static readonly MethodInfo IndexOfMethodWithComparison = typeof(string).GetRuntimeMethod("IndexOf", new[] { typeof(string), typeof(StringComparison) });
        public static readonly MethodInfo ReplaceMethod = typeof(string).GetRuntimeMethod("Replace", new[] { typeof(string), typeof(string) });
        public static readonly MethodInfo EqualsMethod = typeof(string).GetRuntimeMethod("Equals", new[] { typeof(string), typeof(StringComparison) });
        public static readonly MethodInfo StartsWithMethod = typeof(string).GetRuntimeMethod("StartsWith", new[] { typeof(string) });
        public static readonly MethodInfo StartsWithMethodWithComparison = typeof(string).GetRuntimeMethod("StartsWith", new[] { typeof(string), typeof(StringComparison) });
        public static readonly MethodInfo EndsWithMethod = typeof(string).GetRuntimeMethod("EndsWith", new[] { typeof(string) });
        public static readonly MethodInfo EndsWithMethodWithComparison = typeof(string).GetRuntimeMethod("EndsWith", new[] { typeof(string), typeof(StringComparison) });
        public static readonly MethodInfo StringConcatMethod = typeof(string).GetRuntimeMethod("Concat", new[] { typeof(string), typeof(string) });
        public static readonly MethodInfo StringContainsMethod = typeof(string).GetRuntimeMethod("Contains", new[] { typeof(string) });
        public static readonly MethodInfo StringListContainsMethod = typeof(List<string>).GetRuntimeMethod("Contains", new[] { typeof(string) });
        public static readonly MethodInfo SoundexMethod = typeof(SoundexProcessor).GetTypeInfo().DeclaredMethods.First(o => o.Name.Equals("ToSoundex"));
        public static readonly MethodInfo ReverseSoundexMethod = typeof(SoundexProcessor).GetTypeInfo().DeclaredMethods.First(o => o.Name.Equals("ToReverseSoundex"));
        public static readonly MethodInfo LevensteinDistanceMethod = typeof(LevenshteinProcessor).GetTypeInfo().DeclaredMethods.First(o => o.Name.Equals("LevenshteinDistance"));
        public static readonly MethodInfo CustomReplaceMethod = typeof(StringExtensionHelper).GetTypeInfo().DeclaredMethods.First(o => o.Name.Equals("Replace"));
        public static readonly MethodInfo QuickReverseMethod = typeof(StringExtensionHelper).GetTypeInfo().DeclaredMethods.First(o => o.Name.Equals("QuickReverse"));

        public static readonly MethodInfo AnyQueryableMethod = typeof(Enumerable).GetTypeInfo().DeclaredMethods
                                                                                 .Single(mi => mi.Name == "Any" 
                                                                                            && mi.GetParameters().Length == 2);

        #endregion
    }
}