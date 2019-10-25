namespace Constraints
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    public class TestBase<TSubject, TFake>
        where TSubject : new()
        where TFake : class
    {
        public TSubject Subject { get; private set; }
        public Mock<TFake> Fake { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            Subject = new TSubject();
            Fake = new Mock<TFake>();
        }
    }
}