namespace Eq.Test.Core.Mock
{
    public interface IMockInt
    {
        int Value { get; set; }
    }
    public class MockObj : IMockInt
    {
        public int Value { get; set; }
    }
}
