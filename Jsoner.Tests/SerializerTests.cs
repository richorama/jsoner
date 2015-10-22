using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsoner.Tests
{
    [TestClass]
    public class SerializerTests
    {
        [TestMethod]
        public void TestBasicObject()
        {
            dynamic obj = new { Foo = "Bar" };
            var json = Json.Serialize(obj);
            Assert.AreEqual("{\"Foo\":\"Bar\"}", json);
        }

        [TestMethod]
        public void TestBasicArray()
        {
            dynamic obj = new string[] { "foo", "bar", "baz"};
            var json = Json.Serialize(obj);
            Assert.AreEqual("[\"foo\",\"bar\",\"baz\"]", json);
        }

        [TestMethod]
        public void TestFloatArray()
        {
            var obj = new float[] { 1, 2, 3 };
            var json = Json.Serialize(obj);
            Assert.AreEqual("[1,2,3]", json);
        }

        [TestMethod]
        public void TestAllTypes()
        {
            string nullValue = null;
            dynamic obj = new
            {
                stringField = "STRINGVALUE",
                numberField = 123.45,
                boolField = true,
                arrayField = new object[] { true, false },
                nullField = nullValue
            };
            var json = Json.Serialize(obj);
            Assert.AreEqual("{\"stringField\":\"STRINGVALUE\",\"numberField\":123.45,\"boolField\":true,\"arrayField\":[true,false],\"nullField\":null}", json);
        }

        class Foo
        {
            public Foo()
            {
                this.Prop1 = "1";
                this.Prop2 = "2";
                this.Prop3 = "3";
                this.Prop4 = "4";
            }

            public string Prop1 { get; }
            public string Prop2 { private get;  set; }
            private string Prop3 { get; set; }
            protected string Prop4 { get; set; }
        }

        [TestMethod]
        public void TestProperties()
        {
            var foo = new Foo();
            var json = Json.Serialize(foo);
            Assert.AreEqual("{\"Prop1\":\"1\"}", json);
        }

        [TestMethod]
        public void TestSerializeBackAgain()
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
            dynamic obj = Json.Parse(json);
            Assert.IsNotNull(obj);
            Assert.AreEqual("example glossary", obj.glossary.title);
            var json2 = Json.Serialize(obj);
            Assert.IsTrue(json2.IndexOf("{\"glossary\":{") == 0);

            var object2 = Json.Parse(json2);


        }
    }
}
