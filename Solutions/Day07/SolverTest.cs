namespace AoC_2023.Solutions.Day7
{
    public class SolverTest
    {
        [Fact]
        public void TestPartOne()
        {
            var input = InputService.SplitToArray(@"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483");
            var expected = 6440;

            SolverDay7 solver = new(new InputService(input));
            var actual = solver.SolvePartOne();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestCompareHands1()
        {
            
            var hand1 = new Hand("42536", 123);
            var hand2 = new Hand("62537", 123);

            var expected = -1;
            var actual = hand1.CompareTo(hand2);
            
            Assert.Equal(expected, actual); 
        }

        public void TestCompareHands2()
        {

            var hand1 = new Hand("42536", 123);
            var hand2 = new Hand("62537", 123);

            var expected = -1;
            var actual = hand1.CompareTo(hand2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartTwo()
        {
            var input = InputService.SplitToArray(@"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483");
            var expected = 5905;

            SolverDay7 solver = new(new InputService(input));
            var actual = solver.SolvePartTwo();

            Assert.Equal(expected, actual);
        }
    }
}
