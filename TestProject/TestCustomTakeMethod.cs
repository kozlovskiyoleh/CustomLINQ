
using CustomLinq;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TakeSeveralElements()
        {
            List<int> sequence = new() { 1, 2, 3, 4 };
            Assert.That(sequence.CustomTake(2).ToList(), Is.EqualTo(new List<int>() { 1, 2 }));
        }

        [Test]
        public void TakeOneElement()
        {
            List<int> sequence = new() {4};
            Assert.That(sequence.CustomTake(1).ToList(), Is.EqualTo(new List<int>() {4}));
        }

        [Test]
        public void NoTakeAnyElements()
        {
            List<int> sequence = new() { 4 };
            Assert.That(sequence.CustomTake(0).ToList(), Is.EqualTo(new List<int>()));
        }

        [Test]
        public void TakeAllElements()
        {
            List<int> sequence = new() { 1, 2, 3, 4 };
            Assert.That(sequence.CustomTake(6).ToList(), Is.EqualTo(new List<int>() { 1, 2, 3, 4}));
        }
    }
}