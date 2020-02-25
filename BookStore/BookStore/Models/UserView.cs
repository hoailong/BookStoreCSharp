using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class UserView
    {
        public UserView(int userId, int employeeId, string employeeName, string role)
        {
            UserId = userId;
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            Role = role;
        }

        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }

    }
}
