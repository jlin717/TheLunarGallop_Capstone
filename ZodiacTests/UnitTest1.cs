using ZodiacAPI.Controllers;
using ZodiacAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ZodiacTests;

public class UnitTest1
{
    [Fact]
    public void Test_ZodiacCalculation_2026_Is_Horse()
    {
        var controller = new ZodiacController();
        var testUser = new UserProfile { Name = "Test", BirthYear = 2026 };

        controller.PostUser(testUser);

        //Assert that 2026 correctly assigns "Horse"
        Assert.Equal("Horse", testUser.AssignedSign);
    }
}
