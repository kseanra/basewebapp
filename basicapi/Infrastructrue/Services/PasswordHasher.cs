using BCrypt.Net;

namespace basicapi.Infrastructrue.Services
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            try {
                if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(hashedPassword))
                {
                    return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error verifying password: {ex.Message}");
                return false;
            }

            return false;
        }
    }
}
