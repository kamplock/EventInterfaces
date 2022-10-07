using EventInterfaces;

namespace EventInterfacesTest
{
    [TestClass]
    public class EventInterfacesTest
    {
        //we are testing eventCode(char c) with L, l, D, d, and k
        [TestMethod]
        public void eventCode_UpperL()
        {
            Events myEvent = new Events(5, "Test", 400.00);
            double cost = myEvent.eventCode('L');

            //late fee
            Assert.AreEqual(440, cost);

        }

        [TestMethod]
        public void eventCode_LowerL()
        {
            Events myEvent = new Events(5, "Test", 400.00);
            double cost = myEvent.eventCode('l');

            //late fee
            Assert.AreEqual(440, cost);

        }

        [TestMethod]
        public void eventCode_UpperD()
        {
            Events myEvent = new Events(5, "Test", 400.00);
            double cost = myEvent.eventCode('D');

            //discount
            Assert.AreEqual(360, cost);

        }

        [TestMethod]
        public void eventCode_LowerD()
        {
            Events myEvent = new Events(5, "Test", 400.00);
            double cost = myEvent.eventCode('d');

            //discount
            Assert.AreEqual(360, cost);
        }


        [TestMethod]
        public void eventCode_Other()
        {
            Events myEvent = new Events(5, "Test", 400.00);
            double cost = myEvent.eventCode('c');

            //nothing
            Assert.AreEqual(400, cost);
        }

        [TestMethod]
        public void eventCode_UpperE()
        {
            Events myEvent = new Events(5, "Test", 400.00);
            double cost = myEvent.eventCode('E');

            //nothing
            Assert.AreEqual(300, cost);
        }

        [TestMethod]
        public void eventCode_LowerE()
        {
            Events myEvent = new Events(5, "Test", 400.00);
            double cost = myEvent.eventCode('e');

            //nothing
            Assert.AreEqual(300, cost);
        }

        [TestMethod]
        public void eventCode_UpperF()
        {
            Events myEvent = new Events(5, "Test", 400.00);
            double cost = myEvent.eventCode('F');

            //nothing
            Assert.AreEqual(0, cost);
        }

        [TestMethod]
        public void eventCode_LowerF()
        {
            Events myEvent = new Events(5, "Test", 400.00);
            double cost = myEvent.eventCode('f');

            //nothing
            Assert.AreEqual(0, cost);
        }

        
  
    }
}