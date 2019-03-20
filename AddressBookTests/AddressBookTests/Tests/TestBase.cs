using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Text;

namespace AddressBookTests
{
    public class TestBase
    {

        protected string baseURL;
        protected ApplicationManager app;
        public static Random rnd = new Random();
        [SetUp]
        public void SetupAppManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static string GenerateRandomString(int maxLength)
        {
            Randomizer rnd = Randomizer.CreateRandomizer();
            int l = Convert.ToInt32(rnd.NextDouble() * maxLength);
            StringBuilder builder = new StringBuilder();
            for(int i =0; i<l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }
            return builder.ToString();
        }
    }
}
