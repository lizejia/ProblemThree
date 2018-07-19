using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemThree;
using ProblemThree.Rules;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestCheckTrue()
        {
            RuleMain calculate = new RuleMain("MMCMMIII");
            var output = calculate.Check();
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void TestCheckFalse()
        {
            RuleMain calculate = new RuleMain("MCMXLIVV");
            var output = calculate.Check();
            Assert.AreEqual(false, output);
        }



        [TestMethod]
        public void Testglob()
        {
            string input = @"glob is I
how much is glob ?";
            MessageMain messageMain = new MessageMain();
            var output = messageMain.Start(input);
            Assert.AreEqual("glob is 1", output);
        }
        [TestMethod]
        public void Testprok()
        {
            string input = @"prok is V
how much is prok ?";
            MessageMain messageMain = new MessageMain();
            var output = messageMain.Start(input);
            Assert.AreEqual("prok is 5", output);
        }
        [TestMethod]
        public void Testpish()
        {
            string input = @"pish is X
how much is pish ?";
            MessageMain messageMain = new MessageMain();
            var output = messageMain.Start(input);
            Assert.AreEqual("pish is 10", output);
        }
        [TestMethod]
        public void Testtegj()
        {
            string input = @"tegj is L
how much is tegj ?";
            MessageMain messageMain = new MessageMain();
            var output = messageMain.Start(input);
            Assert.AreEqual("tegj is 50", output);
        }

        [TestMethod]
        public void TestHowMuch()
        {
            string input = @"glob is I
prok is V
pish is X
tegj is L
how much is pish tegj glob glob ?";
            MessageMain messageMain = new MessageMain();
            var output = messageMain.Start(input);
            Assert.AreEqual("pish tegj glob glob is 42", output);
        }

        [TestMethod]
        public void TestHowMany_GlobProkSilver()
        {
            string input = @"glob is I
prok is V
pish is X
tegj is L
glob glob Silver is 34 Credits
how many Credits is glob prok Silver ?";
            MessageMain messageMain = new MessageMain();
            var output = messageMain.Start(input);
            Assert.AreEqual("glob prok Silver is 68 Credits", output);
        }
        [TestMethod]
        public void TestHowMany_GlobProkGold()
        {
            string input = @"glob is I
prok is V
pish is X
tegj is L
glob prok Gold is 57800 Credits
how many Credits is glob prok Gold ?";
            MessageMain messageMain = new MessageMain();
            var output = messageMain.Start(input);
            Assert.AreEqual("glob prok Gold is 57800 Credits", output);
        }

        [TestMethod]
        public void TestHowMany_GlobProkIron()
        {
            string input = @"glob is I
prok is V
pish is X
tegj is L
pish pish Iron is 3910 Credits
how many Credits is glob prok Iron ?";
            MessageMain messageMain = new MessageMain();
            var output = messageMain.Start(input);
            Assert.AreEqual("glob prok Iron is 782 Credits", output);
        }

        [TestMethod]
        public void TestNoIdea()
        {
            string input = @"glob is I
prok is V
pish is X
tegj is L
how much wood could a woodchuck chuck if a woodchuck could chuck wood ?";
            MessageMain messageMain = new MessageMain();
            var output = messageMain.Start(input);
            Assert.AreEqual("I have no idea what you are talking about", output);
        }

        [TestMethod]
        public void TestAll()
        {
            string input = @"glob is I
prok is V
pish is X
tegj is L
glob glob Silver is 34 Credits
glob prok Gold is 57800 Credits
pish pish Iron is 3910 Credits
how much is pish tegj glob glob ?
how many Credits is glob prok Silver ?
how many Credits is glob prok Gold ?
how many Credits is glob prok Iron ?
how much wood could a woodchuck chuck if a woodchuck could chuck wood ?";
            MessageMain messageMain = new MessageMain();
            var output = messageMain.Start(input);
            string answer = @"pish tegj glob glob is 42
glob prok Silver is 68 Credits
glob prok Gold is 57800 Credits
glob prok Iron is 782 Credits
I have no idea what you are talking about";
            Assert.AreEqual(answer, output);
        }
        [TestMethod]
        public void TestHowManyEx()
        {
            string input = @"glob is I
prok is V
pish is X
tegj is L
glob glob Silver is 34 Credits
glob prok Gold is 57800 Credits
pish pish Iron is 3910 Credits
how much wood could a woodchuck chuck if a woodchuck could chuck wood ?
how many Silver is glob Gold ?";
            MessageMain messageMain = new MessageMain();
            var output = messageMain.Start(input);
            string answer = @"I have no idea what you are talking about
glob Gold is 850 Silver";
            Assert.AreEqual(answer, output);
        }
    }
}
