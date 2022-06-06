using RestThreeSixtyFive;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        internal Calculator calc = new Calculator();

        [DataTestMethod]
        [DataRow("20", true, true, false, 20)]     // Test Case : 1.1.a
        [DataRow("1,5000", true, true, false, 5001)] //Test Case :  1.1.b
        [DataRow("4,-3", true, true, true, 1)] //Test Case :  1.1.c
        [DataRow("", true, true, false, 0)]        // Test Case : 1.2
        [DataRow("5,tytyt", true, true, false, 5)] //Test Case :  1.3
        public void TestMethodMax2NumbersAndMoreThan1000(string src, bool max2Numbers, bool allowMoreThan1K, bool allowNegatives, int value)
        {
            var res = calc.Add(src, max2Numbers, allowMoreThan1K, allowNegatives);
            Assert.AreEqual(value, res);
        }


        [DataTestMethod]
        [DataRow("1,2,3,4,5,6,7,8,9,10,11,12", 78)] // Test Case : 2.0
        [DataRow("1\n2,3", 6)] // Test Case : 3.0
        [DataRow("2,1001,6", 8)] // Test Case : 5.0
        [DataRow("//#\n2#5", 7)] // Test Case : 6.1
        [DataRow("//,\\n2,ff,100", 102)] // Test Case : 6.2
        [DataRow("//[***]\n11***22***33", 66)] // Test Case : 7.0
        [DataRow("//[*][!!][rrr]\n11rrr22*33!!44", 110)] // Test Case : 8.0
        public void TestMethodAddAny(string src, int value)
        {
            var res = calc.Add(src);
            Assert.AreEqual(value, res);
        }


        // EXCEPTIONS - Test cases
        [DataTestMethod]
        [DataRow("1,2,3,4", true, "More than 2 numbers passed to add.")] // Test Case: 1.1: Exception 
        public void TestMethodMax2NumbersException(string src, bool max2Numbers, string value)
        {
            try
            {
                var res = calc.Add(src, max2Numbers);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(value, ex.Message);
            }
        }

        [DataTestMethod]
        [DataRow("4,-3", "Exception: Invalid Negative Numbers: -3 ")] // Test Case: 4 - - Exception
        public void TestMethodNegativeException(string src, string value) //when negative not allowed
        {
            try
            {
                var res = calc.Add(src);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(value, ex.Message);
            }
        }
    }
}