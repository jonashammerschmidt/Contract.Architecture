using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Tests
{
    [ExcludeFromCodeCoverage]
    public static class AssertExtension
    {
        public static void AreDictionariesEqual<TKey, TValue>(IDictionary<TKey, TValue> expected, IDictionary<TKey, TValue> actual)
        {
            if (expected == null || actual == null || expected.Count != actual.Count)
            {
                Assert.Fail();
                return;
            }

            var orderedExpected = expected.OrderBy(keyValue => keyValue.Key).ToList();
            var orderedActual = actual.OrderBy(keyValue => keyValue.Key).ToList();
            for (int i = 0; i < expected.Count; i++)
            {
                if (!EqualityComparer<TKey>.Default.Equals(orderedExpected[i].Key, orderedActual[i].Key) ||
                    !EqualityComparer<TValue>.Default.Equals(orderedExpected[i].Value, orderedActual[i].Value))
                {
                    Assert.Fail();
                    return;
                }
            }
        }
    }
}