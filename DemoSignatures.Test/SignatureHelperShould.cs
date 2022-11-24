using DemoSignatures.Helper;
using Xunit;

namespace DemoSignatures.Test;

public class SignatureHelperShould
{
    [Theory]
    [InlineData("D:\\Assets\\Demo3.jpg", true)]
    [InlineData("D:\\Assets\\ExcelPrueba.csv", true)]
    [InlineData("D:\\Assets\\Libro1.xls", true)]
    [InlineData("D:\\Assets\\Prueba.csv", true)]
    [InlineData("D:\\Assets\\ArchivoPredial.pdf", true)]
    [InlineData("D:\\Assets\\DemoConsoleApp.csv", false)]
    [InlineData("D:\\Assets\\ArchivoPdfConExtensionCambiada.pdf", true)]
    [InlineData("D:\\Assets\\NoExiste.jpg", false)]
    public void VerifierFile(string path, bool expected)
    {
        //Arrange
        FileTypeVerifier fileTypeVerifier= new FileTypeVerifier();

        //Act
        bool isValid = fileTypeVerifier.IsMatch(path);

        //Assert
        Assert.Equal(isValid, expected);
    }
}