using NExpect.Implementations;
using NExpect.Interfaces;
// ReSharper disable ClassNeverInstantiated.Global

namespace NExpect
{
    internal class ExceptionMessageContainuationToStringContainContinuation
        : ExpectationContext<string>, IStringContainContinuation
    {
        public string Actual { get; set; }

        public ExceptionMessageContainuationToStringContainContinuation(string actual)
        {
            Actual = actual;
        }
    }
}