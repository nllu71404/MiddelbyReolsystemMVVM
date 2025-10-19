
using System.IO;
using System.Linq;
using MiddelbyReolsystemMVVM.Models;
using MiddelbyReolsystemMVVM.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class FileRackRepositoryTests
{
    private readonly string testFilePath = "test_racks.json";

    [TestInitialize] //Alle metoder inde i denne køres inden testmetoderne for at sikre, at hver test starter med rene og kontrollerede data
    public void Setup() //Sletter vores tidligere test-fil
    {
        if (File.Exists(testFilePath))
            File.Delete(testFilePath);
    }

    [TestMethod]
    public void GetRacksByStatus_ReturnsOnlyMatchingStatus()
    {
        // Arrange - opretter repository-objektet og definerer den status, vi vil teste 
        var repo = new FileRackRepository(testFilePath);
        var statusToTest = RackStatus.Available;

        // Act - Kalder metoden GetRacksByStatus for at hente alle racks med den givne status (Available) 
        var racks = repo.GetRacksByStatus(statusToTest).ToList();

        // Assert - 
        Assert.IsTrue(racks.Any(), "Ingen racks med den givne status blev fundet."); //Tjekker om der er racks med den givne status på listen,
                                                                                     //så foreach-loopet kun kører, hvis der rent faktisk er fundet nogle racks

        foreach (var rack in racks)
        {
            Assert.AreEqual("Ledig", rack.RackStatus.Name, "Status-navn er ikke 'Ledig'");
        }
    }
}