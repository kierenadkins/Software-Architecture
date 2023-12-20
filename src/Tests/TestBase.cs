using Moq;
using Moq.AutoMock;

namespace StockKeeping.BL.Tests;

public abstract class TestBase<TServiceUnderTest> where TServiceUnderTest : class
{
    protected readonly AutoMocker AutoMocker = new (MockBehavior.Loose);
    protected TServiceUnderTest CreateSut() => 
        AutoMocker.CreateInstance<TServiceUnderTest>();
}