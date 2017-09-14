using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MoqTester.UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PersonInformationUpdatedTest1()
        {
            var dataservice = new PersonTestDataService("Brown");

            Person person1 = new Person(dataservice);

            Assert.AreEqual("Brown", person1.HairColor);

            person1.DoMakeOver();

            Assert.AreEqual("Red",  person1.HairColor);
            
        }



        [TestMethod]
        public void PersonInformationUpdatedTest2()
        {
            var mock = new Mock<IPersonDataService>();
            mock.Setup(m => m.GetHairColor()).Returns("Black");

            var person1 = new Person(mock.Object);
            Assert.AreEqual("Black", person1.HairColor);

            //act
            person1.DoMakeOver();

            //assert
            Assert.AreEqual("Red", person1.HairColor);

            //Assert that the UpdatePersonInfo method was NOT called with the 'black' parameter
            mock.Verify(m => m.UpdatePersonInfo("Black"),Times.Never);

            //Assert that the UpdatePersonInfo method was called
            mock.Verify(m => m.UpdatePersonInfo("Red"),Times.Exactly(1));

        }
    }
}
