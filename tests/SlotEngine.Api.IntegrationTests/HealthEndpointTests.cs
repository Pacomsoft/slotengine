namespace SlotEngine.Api.IntegrationTests;

using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;


public class HealthEndpointTests
{
    [Fact]
    public async Task GetHealth_ReturnsOkAndHealthy()
    {
        //Arrange
        using var factory = new WebApplicationFactory<Program>();
        using var client = factory.CreateClient(
            new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost"),
                AllowAutoRedirect = false
            }
        );

        //Act
        using var response = await client.GetAsync("/health");


        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Healthy", await response.Content.ReadAsStringAsync());
    }
}