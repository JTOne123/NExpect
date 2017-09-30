﻿using System.Linq;
using NExpect.Exceptions;
using NUnit.Framework;
using PeanutButter.RandomGenerators;
using PeanutButter.Utils;
using static PeanutButter.RandomGenerators.RandomValueGen;
using static NExpect.Expectations;

namespace NExpect.Tests.Collections
{
    [TestFixture]
    public class AtLeast_N
    {
        [TestFixture]
        public class EqualTo
        {
            [Test]
            public void Contain_GivenAtLeast1_WhenCollectionHasNone_ShouldThrow()
            {
                // Arrange
                var search = GetRandomString();
                var item1 = GetAnother(search);
                var item2 = GetAnother<string>(new[] {item1, search});
                var collection = new[] {item1, item2}.Randomize();
                // Pre-Assert
                // Act
                Assert.That(() =>
                    {
                        Expect(collection).To.Contain.At.Least(1).Equal.To(search);
                    },
                    Throws.Exception
                        .InstanceOf<UnmetExpectationException>()
                        .With.Message.Contains("at least 1"));
                // Assert
            }

            [Test]
            public void Contain_Any_WhenCollectionHasNone_ShouldThrow()
            {
                // Arrange
                var search = GetRandomString();
                var item1 = GetAnother(search);
                var item2 = GetAnother<string>(new[] {item1, search});
                var collection = new[] {item1, item2}.Randomize();
                // Pre-Assert
                // Act
                Assert.That(() =>
                    {
                        Expect(collection).To.Contain.Any().Equal.To(search);
                    },
                    Throws.Exception
                        .InstanceOf<UnmetExpectationException>()
                        .With.Message.Contains("Expected to find any match"));
                // Assert
            }

            [Test]
            public void Contain_Any_WhenCollectionHas1_ShouldNotThrow()
            {
                // Arrange
                var search = GetRandomString();
                var item1 = GetAnother(search);
                var item2 = GetAnother<string>(new[] {item1, search});
                var collection = new[] {item1, item2, search}.Randomize();
                // Pre-Assert
                // Act
                Assert.That(() =>
                    {
                        Expect(collection).To.Contain.Any().Equal.To(search);
                    },
                    Throws.Nothing);
                // Assert
            }

            [Test]
            public void Contain_All_WhenCollectionHasMismatches_ShouldThrow()
            {
                // Arrange
                var search = GetRandomString();
                var item1 = GetAnother(search);
                var item2 = GetAnother<string>(new[] {item1, search});
                var collection = new[] {item1, item2, search}.Randomize();
                // Pre-Assert
                // Act
                Assert.That(() =>
                    {
                        Expect(collection).To.Contain.All().Equal.To(search);
                    },
                    Throws.Exception
                        .InstanceOf<UnmetExpectationException>()
                        .With.Message.Contains("Expected to find all matching"));
                // Assert
            }

            [Test]
            public void Contain_All_WhenCollectionHasMismatchesWithMatcher_ShouldThrow()
            {
                // Arrange
                var search = GetRandomString();
                var item1 = GetAnother(search);
                var item2 = GetAnother<string>(new[] {item1, search});
                var collection = new[] {item1, item2, search, null}.Randomize();
                // Pre-Assert
                // Act
                Assert.That(() =>
                    {
                        Expect(collection).To.Contain.All().Matched.By(s => s == null);
                    },
                    Throws.Exception
                        .InstanceOf<UnmetExpectationException>()
                        .With.Message.Contains("Expected to find all matching but found 1"));
                // Assert
            }

            [Test]
            public void Contain_Any_WhenCollectionHasMismatchesWithMatcher_ShouldThrow()
            {
                // Arrange
                var search = GetRandomString();
                var item1 = GetAnother(search);
                var item2 = GetAnother<string>(new[] {item1, search});
                var collection = new[] {item1, item2, search}.Randomize();
                // Pre-Assert
                // Act
                Assert.That(() =>
                    {
                        Expect(collection).To.Contain.Any().Matched.By(s => s == null);
                    },
                    Throws.Exception
                        .InstanceOf<UnmetExpectationException>()
                        .With.Message.Contains("Expected to find any matching but found none"));
                // Assert
            }

            [Test]
            public void Contain_Any_MatchedByWithIndex_WhenCollectionHasMismatchesWithMatcher_ShouldThrow()
            {
                // Arrange
                var items = PyLike.Range(10).Select(i => i + 1).ToArray();
                // Pre-Assert
                // Act
                Assert.That(() =>
                    {
                        Expect(items).To.Contain.Any().Matched.By((idx, item) => item == idx);
                    },
                    Throws.Exception
                        .InstanceOf<UnmetExpectationException>()
                        .With.Message.Contains("Expected to find any matching but found none"));
                // Assert
            }

            [Test]
            public void Contain_All_MatchedByWithIndex_WhenCollectionHasMismatchesWithMatcher_ShouldThrow()
            {
                // Arrange
                var items = PyLike.Range(10).Select(i => i).ToArray();
                // Pre-Assert
                // Act
                Assert.That(() =>
                    {
                        Expect(items).To.Contain.All().Matched.By((idx, item) => item == idx);
                    },
                    Throws.Nothing);
                // Assert
            }


            [Test]
            public void Contain_All_WhenCollectionHasNoMismatches_ShouldNotThrow()
            {
                // Arrange
                var search = GetRandomString();
                var collection = PyLike.Range(2, 4).Select(i => search);
                // Pre-Assert
                // Act
                Assert.That(() =>
                    {
                        Expect(collection).To.Contain.All().Equal.To(search);
                    },
                    Throws.Nothing);
                // Assert
            }

            [Test]
            public void Contain_GivenAtLeast1_WhenCollectionHas1_ShouldNotThrow()
            {
                // Arrange
                var search = GetRandomString();
                var item1 = GetAnother(search);
                var item2 = GetAnother<string>(new[] {item1, search});
                var collection = new[] {search, item1, item2}.Randomize();
                // Pre-Assert
                // Act
                Assert.That(() =>
                    {
                        Expect(collection).To.Contain.At.Least(1).Equal.To(search);
                    },
                    Throws.Nothing);
                // Assert
            }

            [Test]
            public void Contain_GivenAtLeast1_WhenCollectionHas2_ShouldNotThrow()
            {
                // Arrange
                var search = GetRandomString();
                var item1 = GetAnother(search);
                var item2 = GetAnother<string>(new[] {item1, search});
                var collection = new[] {search, item1, search, item2}.Randomize();
                // Pre-Assert
                // Act
                Assert.That(() =>
                    {
                        Expect(collection).To.Contain.At.Least(1).Equal.To(search);
                    },
                    Throws.Nothing);
                // Assert
            }
        }

        [TestFixture]
        public class Matched
        {
            [TestFixture]
            public class By
            {
                [Test]
                public void OperatingOnCollection_WhenSeeking1Match_AndHas1Match_ShouldNotThrow()
                {
                    // Arrange
                    var collection = GetRandomCollection<string>(3, 3).ToArray();
                    var search = collection.Randomize().First();
                    // Pre-Assert

                    // Act
                    Assert.That(() =>
                        {
                            Expect(collection)
                                .To.Contain
                                .At.Least(1)
                                .Matched.By(s => s == search);
                        },
                        Throws.Nothing);

                    // Assert
                }

                [Test]
                public void OperatingOnCollection_WhenSeeking1Match_AndHas2Matches_ShouldNotThrow()
                {
                    // Arrange
                    var collection = GetRandomCollection<string>(3, 3).ToArray();
                    var search = collection.Randomize().First();
                    collection = collection.And(search).Randomize().ToArray();
                    // Pre-Assert
                    Assert.That(collection.Count(s => s == search), Is.EqualTo(2));
                    // Act
                    Assert.That(() =>
                        {
                            Expect(collection)
                                .To.Contain
                                .At.Least(1)
                                .Matched.By(s => s == search);
                        },
                        Throws.Nothing);

                    // Assert
                }

                [Test]
                public void OperatingOnCollection_WhenSeeking2Matches_AndHas1Match_ShouldThrow()
                {
                    // Arrange
                    var collection = GetRandomCollection<string>(3, 3).ToArray();
                    var search = collection.Randomize().First();
                    // Pre-Assert
                    // Act
                    Assert.That(() =>
                        {
                            Expect(collection)
                                .To.Contain
                                .At.Least(2)
                                .Matched.By(s => s == search);
                        },
                        Throws.Exception.InstanceOf<UnmetExpectationException>());

                    // Assert
                }

                [Test]
                public void Negated_OperatingOnCollection_WhenSeeking1Match_AndHas1Match_ShouldThrow()
                {
                    // Arrange
                    var collection = GetRandomCollection<string>(3, 3).ToArray();
                    var search = collection.Randomize().First();
                    // Pre-Assert

                    // Act
                    Assert.That(() =>
                        {
                            Expect(collection)
                                .Not.To.Contain
                                .At.Least(1)
                                .Matched.By(s => s == search);
                        },
                        Throws.Exception.InstanceOf<UnmetExpectationException>());

                    // Assert
                }

                [Test]
                public void NegatedAlt_OperatingOnCollection_WhenSeeking1Match_AndHas1Match_ShouldThrow()
                {
                    // Arrange
                    var collection = GetRandomCollection<string>(3, 3).ToArray();
                    var search = collection.Randomize().First();
                    // Pre-Assert

                    // Act
                    Assert.That(() =>
                        {
                            Expect(collection)
                                .To.Not.Contain
                                .At.Least(1)
                                .Matched.By(s => s == search);
                        },
                        Throws.Exception.InstanceOf<UnmetExpectationException>());

                    // Assert
                }
            }
        }
    }
}