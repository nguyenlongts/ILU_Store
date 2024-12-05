namespace ILU_Store.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
       
        public int Status { get; set; }
        public DateTime DoB { get; set; }
        public int Gender { get; set; }
        public string FullName { get; set; }
        public List<AddressDTO> Addresses { get; set; }
        public string Role { get; set; } 
    }

    

}
