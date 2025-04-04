using Craig_Joiner_Software_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Windows.Forms;
[TestClass]
public class LoginScreenTests
{
    private LoginScreen loginScreen;

    [TestInitialize]
    public void Setup()
    {
        loginScreen = new LoginScreen();
    }

    [TestMethod]
    public void Login_WithValidCredentials_HidesLoginScreen()
    {
        // Arrange
        loginScreen.textBoxUsername.Text = "test";
        loginScreen.textBoxPassword.Text = "test";

        // Act
        loginScreen.Log_In_Click(loginScreen, EventArgs.Empty);

        // Assert
        Assert.IsFalse(loginScreen.Visible, "LoginScreen should be hidden after successful login.");
    }

    [TestMethod]
    public void Login_WithInvalidCredentials_ShowsLoginScreen()
    {
        // Arrange
        loginScreen.textBoxUsername.Text = "invalidUser";
        loginScreen.textBoxPassword.Text = "wrongPassword";

        // Act
        loginScreen.Log_In_Click(loginScreen, EventArgs.Empty);

        // Assert
        Assert.IsTrue(loginScreen.Visible, "LoginScreen should remain visible after failed login.");
    }
}