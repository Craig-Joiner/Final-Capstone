using System;
using Craig_Joiner_Software_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OverLapAppointments
{
    [TestClass]
    public class AppointmentOverlapTest
    {
        [TestMethod]
        public void IsOverlapAppointment_WhenTimeSlot_IsAlreadyBooked_ShouldReturnTrue()
        {
            var add_Appointment = new Add_Appointment();
            var existingStart = new DateTime(2025, 3, 24, 10, 0, 0);
            var existingEnd = new DateTime(2025, 3, 24, 11, 0, 0);
            var customerIds = 1;

            add_Appointment.AddAppointmentToDb(existingStart, existingEnd, customerIds);

            var newStart = new DateTime(2025, 3, 24, 10, 30, 0);
            var newEnd = new DateTime(2025, 3, 24, 11, 30, 0);
            bool isOverlap = add_Appointment.IsOverlapAppointment();

            Assert.IsTrue(isOverlap, "IsOverlapAppointment did not detect a double booking!");
        }
    }
}
