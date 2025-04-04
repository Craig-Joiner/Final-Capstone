using Craig_Joiner_Software_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IsFormVaildTest
{
    namespace AddCustomerValidationTests
    {
        [TestClass]
        public class IsFormValidTests
        {
            [TestMethod]
            public void IsFormValid_AllFieldsValid()
            {
                var form = new Add_Customers();
                form.textBoxName.Text = "John Doe";
                form.textBoxAddress.Text = "123 Main St";
                form.textBoxCity.Text = "New York";
                form.textBoxZipCode.Text = "10001";
                form.textBoxCountry.Text = "USA";
                form.textBoxPhoneNumber.Text = "555-1234";

                bool result = form.IsFormValid();

                Assert.IsTrue(result, "Form should be valid when all fields are filled.");
            }

            [TestMethod]
            public void IsFormValid_MissingName()
            {
                var form = new Add_Customers();
                form.textBoxName.Text = ""; // intentionally empty
                form.textBoxAddress.Text = "123 Main St";
                form.textBoxCity.Text = "New York";
                form.textBoxZipCode.Text = "10001";
                form.textBoxCountry.Text = "USA";
                form.textBoxPhoneNumber.Text = "555-1234";

                bool result = form.IsFormValid();

                Assert.IsFalse(result, "Form should not be valid when name is missing.");
            }

            [TestMethod]
            public void IsFormValid_MissingPhone()
            {
                var form = new Add_Customers();
                form.textBoxName.Text = "John Doe";
                form.textBoxAddress.Text = "123 Main St";
                form.textBoxCity.Text = "New York";
                form.textBoxZipCode.Text = "10001";
                form.textBoxCountry.Text = "USA";
                form.textBoxPhoneNumber.Text = ""; // missing phone

                bool result = form.IsFormValid();

                Assert.IsFalse(result, "Form should not be valid when phone is missing.");
            }

            [TestMethod]
            public void IsFormValid_AllFieldsEmpty()
            {
                var form = new Add_Customers();

                bool result = form.IsFormValid();

                Assert.IsFalse(result, "Form should not be valid when all fields are empty.");
            }
        }
    }
}
