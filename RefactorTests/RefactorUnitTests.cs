using System;
using System.IO;
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
        [TestCase("test_1_before.txt", "test_1_after.txt")]
        [TestCase("test_2_before.txt", "test_2_after.txt")]
        public void ShouldLoadTestCaseAndVerifyOutput(string input, string output)
        {
            var fileInput = File.OpenText(@"C:\Work\Projects\LnLs\Refactor\RefactorTests\testcases\" + input);
            var jsonInput = fileInput.ReadToEnd();
            fileInput.Close();

            var response = jsonInput.FromJson();
            sut.fillAttributes(response);

            var after = response.ToJson();
            var fileOutput= File.OpenText(@"C:\Work\Projects\LnLs\Refactor\RefactorTests\testcases\" + output);
            var jsonOuput = fileOutput.ReadToEnd();
            fileInput.Close();
            var outputModel = jsonOuput.FromJson();

            Assert.AreEqual(after, outputModel.ToJson());
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
