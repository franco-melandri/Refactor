using System;
using fake;
using NUnit.Framework;

namespace RefactorTests
{
    [TestFixture]
    public class RefactorUnitTests
    {
        private ObjectMapper sut;

        [SetUp]
        public void SetUp()
        {
            sut = new ObjectMapper();
        }

        [Test]
        public void ShouldVerifySomethingChangeInRequest()
        {
            var response = SerachResultReponseBuilder
                            .Create()
                                .AddFilterAttribute("ctgr", true)
                                    .AddFilterAttributeInner("ctgr", "gnn", true)
                                    .AddFilterRefinement("ctgr", "hshlv", true)
                                        .AddFilterRefinementInner("ctgr", "hshlv", "hh", true)
                            .Build();

            var before = response.ToJson();
            
            Console.WriteLine(before);
            sut.fillAttributes(response);

            var after = response.ToJson();
            Console.WriteLine(after);

            Assert.AreNotEqual(before, after);
        }

        [Test]
        public void ShouldBeRefacored()
        {
            var response = SerachResultReponseBuilder
                            .Create()
                                .AddFilterAttribute("ctgr", true)
                                    .AddFilterAttributeInner("ctgr", "gnn", true)
                                    .AddFilterRefinement("ctgr", "hshlv", true)
                                        .AddFilterRefinementInner("ctgr", "hshlv", "hh", true)
                            .Build();

            var responseRefac = SerachResultReponseBuilder
                            .Create()
                                .AddFilterAttribute("ctgr", true)
                                    .AddFilterAttributeInner("ctgr", "gnn", true)
                                    .AddFilterRefinement("ctgr", "hshlv", true)
                                        .AddFilterRefinementInner("ctgr", "hshlv", "hh", true)
                            .Build();

            sut.fillAttributes(response);
            sut.fillAttributesRefactored(responseRefac);

            Assert.AreEqual(response.ToJson(), responseRefac.ToJson());
        }
    }
}
