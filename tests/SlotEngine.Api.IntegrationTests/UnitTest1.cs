namespace SlotEngine.Api.IntegrationTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        int numero = 100;
        //Act
        int resultado = numero/25;
        //Assert
        Assert.Equal(4, resultado);
    }
}
