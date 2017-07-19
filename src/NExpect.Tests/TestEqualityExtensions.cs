﻿using NExpect.Extensions;
using NUnit.Framework;
using static NExpect.Implementations.Expectations;
using static PeanutButter.RandomGenerators.RandomValueGen;

namespace NExpect.Tests
{
    [TestFixture]
    public class TestEqualityExtensions
    {
        public class Equality
        {
            [Test]
            public void Expect_src_ToEqual_value_WhenMatches_ShouldNotThrow()
            {
                // Arrange
                var actual = 1;
                var expected = 1;
                // Pre-Assert

                // Act
                Assert.That(
                    () => Expect(actual).To.Equal(expected),
                    Throws.Nothing
                );
                // Assert
            }

            [Test]
            public void Expect_src_ToEqual_value_WhenDoesNotMatch_ShouldThrow()
            {
                // Arrange
                var actual = 1;
                var expected = 2;
                // Pre-Assert

                // Act
                Assert.That(
                    () => Expect(actual).To.Equal(expected),
                    Throws.Exception.InstanceOf<AssertionException>()
                        .With.Message.Contains($"Expected {expected} but got {actual}")
                );
                // Assert
            }

            [Test]
            public void
                Expect_src_ToEqual_value_WhenDoesNotMatch_GivenCustomMessage_ShouldThrowWithCustomMessageAndRegularOne()
            {
                // Arrange
                var actual = 1;
                var expected = 2;
                var custom = GetRandomString(5);
                // Pre-Assert

                // Act
                Assert.That(
                    () => Expect(actual).To.Equal(expected, custom),
                    Throws.Exception.InstanceOf<AssertionException>()
                        .With.Message.Contains($"Expected {expected} but got {actual}")
                );
                Assert.That(
                    () => Expect(actual).To.Equal(expected, custom),
                    Throws.Exception.InstanceOf<AssertionException>()
                        .With.Message.Contains(custom)
                );
                // Assert
            }

            [Test]
            public void Negation_WhenValuesDoNotMatch_ShouldNotThrow()
            {
                // Arrange
                var actual = 1;
                var expected = 2;

                // Pre-Assert

                // Act
                Assert.That(
                    () => Expect(actual).Not.To.Equal(expected),
                    Throws.Nothing
                );

                // Assert
            }

            [Test]
            public void ReversedNegation_WhenValuesDoNotMatch_ShouldNotThrow()
            {
                // Arrange
                var actual = 1;
                var expected = 2;

                // Pre-Assert

                // Act
                Assert.That(
                    () => Expect(actual).To.Not.Equal(expected),
                    Throws.Nothing
                );

                // Assert
            }


            [Test]
            public void AlternativeEqualGrammar_HappyPath()
            {
                // Arrange
                var value = GetRandomInt();
                // Pre-Assert

                // Act
                Assert.That(() => { Expect(value).To.Be.Equal.To(value); }, Throws.Nothing);

                // Assert
            }

            [Test]
            public void AlternativeEqualGrammar_SadPath()
            {
                // Arrange
                var value = GetRandomInt();
                var expected = GetAnother(value);
                // Pre-Assert

                // Act
                Assert.That(() => { Expect(value).To.Be.Equal.To(expected); },
                    Throws.Exception.InstanceOf<AssertionException>());

                // Assert
            }

            [Test]
            public void AlternativeEqualGrammar_Negated_HappyPath()
            {
                // Arrange
                var value = GetRandomInt();
                var unexpected = GetAnother(value);
                // Pre-Assert

                // Act
                Assert.That(() => { Expect(value).Not.To.Be.Equal.To(unexpected); }, Throws.Nothing);

                // Assert
            }

            [Test]
            public void AlternativeEqualGrammar_Negated_SadPath()
            {
                // Arrange
                var value = GetRandomInt();
                // Pre-Assert

                // Act
                Assert.That(() => { Expect(value).Not.To.Be.Equal.To(value); },
                    Throws.Exception.InstanceOf<AssertionException>());

                // Assert
            }

            [Test]
            public void AlternativeEqualGrammar_AltNegated_HappyPath()
            {
                // Arrange
                var value = GetRandomInt();
                var unexpected = GetAnother(value);
                // Pre-Assert

                // Act
                Assert.That(() => { Expect(value).To.Not.Be.Equal.To(unexpected); }, Throws.Nothing);

                // Assert
            }

            [Test]
            public void AlternativeEqualGrammar_AltNegated_SadPath()
            {
                // Arrange
                var value = GetRandomInt();
                // Pre-Assert

                // Act
                Assert.That(() => { Expect(value).To.Not.Be.Equal.To(value); },
                    Throws.Exception.InstanceOf<AssertionException>());

                // Assert
            }
        }

        [TestFixture]
        public class GreaterThan
        {
            public class ActingOnInts
            {
                [Test]
                public void GreaterThan_WhenActualIsGreaterThanExpected_ShouldNotThrow()
                {
                    // Arrange
                    var actual = GetRandomInt(5, 10);
                    var expected = GetRandomInt(0, 4);

                    // Pre-Assert

                    // Act
                    Assert.That(() => 
                    { 
                        Expect(actual).To.Be.Greater.Than(expected); 
                    }, Throws.Nothing);

                    // Assert
                }

                [Test]
                public void GreaterThan_WhenActualIsEqualToExpected_ShouldThrow()
                {
                    // Arrange
                    var actual = GetRandomInt(5, 10);

                    // Pre-Assert

                    // Act
                    Assert.That(() => 
                    { 
                        Expect(actual).To.Be.Greater.Than(actual); 
                    }, Throws.Exception.InstanceOf<AssertionException>());

                    // Assert
                }

                [Test]
                public void GreaterThan_WhenActualIsLessThanExpected_ShouldThrow()
                {
                    // Arrange
                    var actual = GetRandomInt(5, 10);
                    var expected = GetRandomInt(11, 20);

                    // Pre-Assert

                    // Act
                    Assert.That(() => 
                    { 
                        Expect(actual).To.Be.Greater.Than(expected); 
                    }, Throws.Exception.InstanceOf<AssertionException>());

                    // Assert
                }
            }
        }

        [TestFixture]
        public class LessThan
        {
            [Test]
            public void LessThan_WhenActualIsLessThanExpected_ShouldNotThrow()
            {
                // Arrange
                var actual = GetRandomInt(1, 5);
                var expected = GetRandomInt(6, 12);
                // Pre-Assert
                // Act
                Assert.That(() =>
                {
                    Expect(actual).To.Be.Less.Than(expected);
                }, Throws.Nothing);
                // Assert
            }

            [Test]
            public void LessThan_WhenActualIsEqualToExpected_ShouldThrow()
            {
                // Arrange
                var actual = GetRandomInt(1, 5);
                var expected = actual;
                // Pre-Assert
                // Act
                Assert.That(() =>
                {
                    Expect(actual).To.Be.Less.Than(expected);
                }, Throws.Exception.InstanceOf<AssertionException>()
                    .With.Message.Contains($"{actual} to be less than {expected}"));
                // Assert
            }

            [Test]
            public void LessThan_WhenActualIsGreaterThanExpected_ShouldThrow()
            {
                // Arrange
                var actual = GetRandomInt(1, 5);
                var expected = GetRandomInt(-5, 0);
                // Pre-Assert
                // Act
                Assert.That(() =>
                {
                    Expect(actual).To.Be.Less.Than(expected);
                }, Throws.Exception.InstanceOf<AssertionException>()
                    .With.Message.Contains($"{actual} to be less than {expected}"));
                // Assert
            }
        }
    }
}