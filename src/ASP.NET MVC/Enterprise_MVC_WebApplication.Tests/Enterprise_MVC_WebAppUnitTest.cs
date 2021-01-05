using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enterprise_MVC_WebApplication.Core.Interface;
using Enterprise_MVC_WebApplication.Infra;

namespace Enterprise_MVC_WebApplication.Tests
{
    [TestClass]
    public class Enterprise_MVC_WebAppUnitTest
    {
        IEnterprise_MVC_CoreRepository repo;
        [TestInitialize]
        public void TestSetUp()
        {
            repo = new Enterprise_MVC_Repository();
        }

        [TestMethod]
        public void IEnterprise_MVC_CoreRepositoryGetData()
        {
            var result = repo.GetData();
            Assert.IsNotNull(result);
        }
    }
}
