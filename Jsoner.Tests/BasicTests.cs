using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace Jsoner.Tests
{
    [TestClass]
    public class BasicTests
    {
   

        [TestMethod]
        public void TestObjectWithDictionary()
        {
            IDictionary<string,object> obj = Parser.ParseJson(@"{ ""foo"" : ""bar"" }") as IDictionary<string, object>;

            Assert.IsNotNull(obj);
            Assert.AreEqual("bar", obj["foo"]);
        }


        [TestMethod]
        public void TestObjectWithDynamic()
        {
            dynamic obj = Parser.ParseJson(@"{ ""foo"" : ""bar"" }") ;

            Assert.IsNotNull(obj);
            Assert.AreEqual("bar", obj.foo);
        }


        [TestMethod]
        public void TestNestedObject()
        {
            dynamic obj = Parser.ParseJson(@"{ ""foo"" : { ""bar"" : ""baz""} }") ;

            Assert.IsNotNull(obj);
            Assert.AreEqual("baz", obj.foo.bar);
        }

        [TestMethod]
        public void TestSimpleArray()
        {
            var arr = Parser.ParseJson(@"[ ""foo"", ""bar"", ""baz""]") as List<object>;

            Assert.IsNotNull(arr);
            Assert.AreEqual("foo", arr[0]);
            Assert.AreEqual("bar", arr[1]);
            Assert.AreEqual("baz", arr[2]);
        }

        [TestMethod]
        public void TestArrayWithObject()
        {
            dynamic arr = Parser.ParseJson(@"[ ""foo"", ""bar"", {""baz"":""qux""}]");

            Assert.IsNotNull(arr);
            Assert.AreEqual("foo", arr[0]);
            Assert.AreEqual("bar", arr[1]);
            Assert.AreEqual("qux", arr[2].baz);
        }

        [TestMethod]
        public void TesObjectWithArray()
        {
            dynamic obj = Parser.ParseJson(@"{ ""foo"": ""bar"", ""bar"" : null}");

            Assert.IsNotNull(obj);
            Assert.AreEqual("bar", obj.foo);
            Assert.AreEqual(null, obj.bar);
        }   

        [TestMethod]
        public void TesObjectWithTrueAndFalse()
        {
            dynamic obj = Parser.ParseJson(@"{ ""foo"": true, ""bar"" : false}");

            Assert.IsNotNull(obj);
            Assert.AreEqual(true, obj.foo);
            Assert.AreEqual(false, obj.bar);
        }    

        [TestMethod]
        public void TesObjectWithDouble()
        {
            dynamic obj = Parser.ParseJson(@"{ ""qux"": 1234.56}");

            Assert.IsNotNull(obj);
            Assert.AreEqual(1234.56, obj.qux);
        }    

        [TestMethod]
        public void TestExampleJsonFile()
        {
            var json = @"
            {
                ""glossary"": {
                    ""title"": ""example glossary"",
                    ""GlossDiv"": {
                        ""title"": ""S"",
                        ""GlossList"": {
                            ""GlossEntry"": {
                                ""ID"": ""SGML"",
                                ""SortAs"": ""SGML"",
                                ""GlossTerm"": ""Standard Generalized Markup Language"",
                                ""Acronym"": ""SGML"",
                                ""Abbrev"": ""ISO 8879:1986"",
                                ""GlossDef"": {
                                    ""para"": ""A meta-markup language, used to create markup languages such as DocBook."",
                                    ""GlossSeeAlso"": [""GML"", ""XML""]
                                },
                                ""GlossSee"": ""markup""
                            }
                        }
                    }
                }
            }";
            dynamic obj = Parser.ParseJson(json);
            Assert.IsNotNull(obj);
            Assert.AreEqual("example glossary", obj.glossary.title);

        }
    }
}
