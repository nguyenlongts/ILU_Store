namespace ILU_Store.Models.Employee
{
    public class CreateEmployeeModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; } = 2;
    }
}
