using Xunit;
using billetera.Controllers;
using billetera.Models;
using billetera.Services;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace test.Controllers;
public class UsuariosControllerTest 
{
    public UsuariosControllerTest(){
          //_controller = new UsuariosController(_loggerMock.Object, _serviceMock.Object);
    }
    
    [Fact]
    public void GuardaUsuario()
    {
        //Arrange
        var _loggerMock = new Mock<ILogger<UsuariosController>>();
        var _serviceMock = new Mock<IUsuariosService>();
        var usuariosController = new UsuariosController(_loggerMock.Object, _serviceMock.Object);
        var usuarios = new Usuarios();
        usuarios.ID= Guid.NewGuid();
        usuarios.Nombre = "Nombre_Prueba";
        usuarios.Email = "Email_Prueba@prueba.com";
        usuarios.Contrasena= "Contrasena_Prueba";
        //Act
        var result=usuariosController.GuardaUsuario(usuarios);
        //Assert
        Assert.IsType<OkResult>(result);
        //Assert.Equal(Ok(),result);


    }
}