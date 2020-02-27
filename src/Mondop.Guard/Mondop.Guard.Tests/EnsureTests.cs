using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Mondop.Guard.Tests
{
    [TestClass]
    public class EnsureTests
    {
        [TestMethod]
        public void Call_IsNotNull_WithValidArgument_Expect_AssignedResult()
        {
            var test = new StringBuilder();

            var result = Ensure.IsNotNull(test, nameof(test));

            result.Should().NotBeNull();
        }

        [TestMethod]
        public void Call_IsNotNull_With_NullValue_Expect_Exception()
        {
            StringBuilder test = null;
            Action action = () => Ensure.IsNotNull(test, nameof(test));

            action.Should().ThrowExactly<ArgumentNullException>();
        }

        [TestMethod]
        public void Call_IsNotNullOrEmpty_With_Value_Expect_AssignedResult()
        {
            string test = "Test";
            var result = Ensure.IsNotNullOrEmpty(test, nameof(test));

            result.Should().Be("Test");
        }

        [TestMethod]
        public void Call_IsNotNullOrEmpty_With_NullValue_Expect_ArgumentNullException()
        {
            string test = null;
            Action action = () => Ensure.IsNotNullOrEmpty(test, nameof(test));

            action.Should().ThrowExactly<ArgumentNullException>();
        }

        [TestMethod]
        public void Call_IsNotNullOrEmpty_With_NullValue_Expect_ArgumentException()
        {
            string test = "";
            Action action = () => Ensure.IsNotNullOrEmpty(test, nameof(test));

            action.Should().ThrowExactly<ArgumentException>();
        }

        [TestMethod]
        public void Call_IsNotNullOrWhiteSpace_With_Value_Expect_AssignedResult()
        {
            string test = "Test";
            var result = Ensure.IsNotNullOrWhiteSpace(test, nameof(test));

            result.Should().Be("Test");
        }

        [TestMethod]
        public void Call_IsNotNullOrWhiteSpace_With_NullValue_Expect_ArgumentNullException()
        {
            string test = null;
            Action action = () => Ensure.IsNotNullOrWhiteSpace(test, nameof(test));

            action.Should().ThrowExactly<ArgumentNullException>();
        }

        [TestMethod]
        public void Call_IsNotNullOrWhiteSpace_With_EmptyValue_Expect_ArgumentException()
        {
            string test = "";
            Action action = () => Ensure.IsNotNullOrWhiteSpace(test, nameof(test));

            action.Should().ThrowExactly<ArgumentException>();
        }

        [TestMethod]
        public void Call_IsNotNullOrWhiteSpace_With_WhiteSpaceValue_Expect_ArgumentException()
        {
            string test = "\t ";
            Action action = () => Ensure.IsNotNullOrWhiteSpace(test, nameof(test));

            action.Should().ThrowExactly<ArgumentException>();
        }

        [TestMethod]
        public void Call_IsWithCorrectType_Expect_AssignedResult()
        {
            object tmp = new TestPoco();

            var result = Ensure.Is<TestPoco>(tmp, nameof(tmp));

            result.Should().BeOfType<TestPoco>();
        }

        [TestMethod]
        public void Call_IsWithCorrectInherited_Expect_AssignedResult()
        {
            TestPoco tmp = new TestPocoB();

            var result = Ensure.Is<TestPocoB>(tmp, nameof(tmp));

            result.Should().BeOfType<TestPocoB>();
        }

        [TestMethod]
        public void Call_IsWithInCorrectType_Expect_AssignedResult()
        {
            object tmp = new TestPocoC();

            Action action = () => Ensure.Is<TestPocoB>(tmp, nameof(tmp));

            action.Should().ThrowExactly<ArgumentException>();
        }

    }
}
