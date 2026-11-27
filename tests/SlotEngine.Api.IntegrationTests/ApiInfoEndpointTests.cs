namespace SlotEngine.Api.IntegrationTests;

using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using System.Net;

public class ApiInfoEndpointTests
{
    [Fact]
    public async Task GetApiInfo_ReturnsExpectedResponse()
    {
        // Arrange
        using var factory = new WebApplicationFactory<Program>();
        using var client = factory.CreateClient(new WebApplicationFactoryClientOptions()
        {
            BaseAddress = new Uri("https://localhost"),
            AllowAutoRedirect = false
        });
        // Act
        using var response = await client.GetAsync("/api/v1");

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
        using var json = JsonDocument.Parse(content);

        Assert.Equal("SlotEngine API", json.RootElement.GetProperty("name").GetString());
        Assert.Equal("v1", json.RootElement.GetProperty("version").GetString());
        Assert.Equal("running", json.RootElement.GetProperty("status").GetString());

    }
}