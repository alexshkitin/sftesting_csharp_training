using NUnit.Framework;

namespace AddressBookTests
{
    public class TestBase
    {

        protected string baseURL;
        protected ApplicationManager app;

        [SetUp]
        public void SetupAppManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}
