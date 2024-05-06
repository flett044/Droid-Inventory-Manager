using cis237_assignment_4;

namespace cis237_assignment_4_unittest
{
    [TestClass]
    public class ObjectCreation
    {
        [TestMethod]
        // Tests if one of each droid type can be added to droid array
        public void AddOneOfEachDroidToDroidCollection()
        {
            const int DROID_COLLECTION_SIZE = 100;

            DroidCollection droids = new DroidCollection(DROID_COLLECTION_SIZE);

            droids.NewDroid("Protocol", "Besker", "Gold", "3");
            droids.NewDroid("Astromech", "Besker", "Gold", "true", "true", "true", "true", "3");
            droids.NewDroid("Utility", "Besker", "Gold", "true", "true", "true");
            droids.NewDroid("Janitor", "Besker", "Gold", "true", "true", "true", "true", "true");
        }

        [TestMethod]
        // Does nothing right now
        public void CheckReturnDroidsArrayOfStrings()
        {
            const int DROID_COLLECTION_SIZE = 100;

            DroidCollection droids = new DroidCollection(DROID_COLLECTION_SIZE);

            droids.NewDroid("Protocol", "Besker", "Gold", "3");
            droids.NewDroid("Astromech", "Besker", "Gold", "true", "true", "true", "true", "3");
            droids.NewDroid("Utility", "Besker", "Gold", "true", "true", "true");
            droids.NewDroid("Janitor", "Besker", "Gold", "true", "true", "true", "true", "true");

            string droidsAsString = droids.ToString();
        }

        [TestMethod]
        // Instantiates a protocol droid
        public void AddProtocolDroid()
        {
            Protocol protocolDroid = new Protocol("Protocol", "Besker", "Gold", 3);
        }

        [TestMethod]
        // Instantiates an astromech
        public void AddAstromechDroid()
        {
            Astromech astromechDroid = new Astromech("Astromech", "Besker", "Gold", true, true, true, true, 3);
        }

        [TestMethod]
        // Instantiates a janitor
        public void AddJanitorDroid()
        {
            Janitor janitorDroid = new Janitor("Janitor", "Besker", "Gold", true, true, true, true, true);
        }

        [TestMethod]
        // Instantiates a utility droid
        public void AddUtilityDroid()
        {
            Utility utilityDroid = new Utility("Utility", "Besker", "Gold", true, true, true);
        }

        [TestMethod]
        // Check protocol droid properties for correctness
        public void CheckProtocolDroidProperties()
        {
            Protocol protocolDroid = new Protocol("Protocol", "Besker", "Gold", 3);

            string expectedModel = "Protocol";
            string expectedMaterial = "Besker";
            string expectedColor = "Gold";
            int expectedNumOfLanguages = 3;
            decimal expectedTotalCost = 410.00m;

            Assert.AreEqual(expectedModel, protocolDroid.Model);
            Assert.AreEqual(expectedMaterial, protocolDroid.Material);
            Assert.AreEqual(expectedColor, protocolDroid.Color);
            Assert.AreEqual(expectedNumOfLanguages, protocolDroid.NumberLanguages);
            Assert.AreEqual(expectedTotalCost, protocolDroid.TotalCost);
        }

        [TestMethod]
        // Check janitor properties for correctness
        public void CheckJanitorDroidProperties()
        {
            Janitor janitorDroid = new Janitor("Janitor", "Besker", "Gold", true, true, true, true, true);

            string expectedModel = "Janitor";
            string expectedMaterial = "Besker";
            string expectedColor = "Gold";
            bool expectedToolbox = true;
            bool expectedComputerConnection = true;
            bool expectedScanner = true;
            bool expectedBroom = true;
            bool expectedVacuum = true;
            decimal expectedTotalCost = 260.00m;

            Assert.AreEqual(expectedModel, janitorDroid.Model);
            Assert.AreEqual(expectedMaterial,janitorDroid.Material);
            Assert.AreEqual(expectedColor, janitorDroid.Color);
            Assert.AreEqual(expectedToolbox, janitorDroid.ToolBox);
            Assert.AreEqual(expectedComputerConnection, janitorDroid.ComputerConnection);
            Assert.AreEqual(expectedScanner, janitorDroid.Scanner);
            Assert.AreEqual(expectedBroom, janitorDroid.Broom);
            Assert.AreEqual(expectedVacuum, janitorDroid.Vacuum);
            Assert.AreEqual(expectedTotalCost, janitorDroid.TotalCost);
        }

        [TestMethod]
        // Check utility properties for correctness
        public void CheckUtilityProperties()
        {
            Utility utilityDroid = new Utility("Utility", "Besker", "Gold", true, true, true);

            string expectedModel = "Utility";
            string expectedMaterial = "Besker";
            string expectedColor = "Gold";
            bool expectedToolbox = true;
            bool expectedComputerConnection = true;
            bool expectedScanner = true;
            decimal expectedTotalCost = 440.00m;

            Assert.AreEqual(expectedModel, utilityDroid.Model);
            Assert.AreEqual(expectedMaterial, utilityDroid.Material);
            Assert.AreEqual(expectedColor, utilityDroid.Color);
            Assert.AreEqual(expectedToolbox, utilityDroid.ToolBox);
            Assert.AreEqual(expectedComputerConnection, utilityDroid.ComputerConnection);
            Assert.AreEqual(expectedScanner, utilityDroid.Scanner);
            Assert.AreEqual(expectedTotalCost, utilityDroid.TotalCost);
        }

        [TestMethod]
        // Check astromech properties for correctness
        public void CheckAstromechProperties()
        {
            Astromech astromechDroid = new Astromech("Astromech", "Besker", "Gold", true, true, true, true, 3);

            string expectedModel = "Astromech";
            string expectedMaterial = "Besker";
            string expectedColor = "Gold";
            bool expectedToolbox = true;
            bool expectedComputerConnection = true;
            bool expectedScanner = true;
            bool expectedNavigation = true;
            int expectedNumberShips = 3;
            decimal expectedTotalCost = 1000.00m;

            Assert.AreEqual(expectedModel, astromechDroid.Model);
            Assert.AreEqual(expectedMaterial, astromechDroid.Material);
            Assert.AreEqual(expectedColor, astromechDroid.Color);
            Assert.AreEqual(expectedToolbox, astromechDroid.ToolBox);
            Assert.AreEqual(expectedComputerConnection, astromechDroid.ComputerConnection);
            Assert.AreEqual(expectedScanner, astromechDroid.Scanner);
            Assert.AreEqual(expectedNavigation, astromechDroid.Navigation);
            Assert.AreEqual(expectedNumberShips, astromechDroid.NumberShips);
            Assert.AreEqual(expectedTotalCost, astromechDroid.TotalCost);
        }
    }
}