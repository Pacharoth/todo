namespace tracer_backend.test.PasswordTest;
using BCrypt.Net;
public class PasswordHash
{
    public string HashPassword(string password){
        return BCrypt.HashPassword(password);
    }
    public bool VerifyPassword(string hashedPassword,string password){
        return BCrypt.Verify(password,hashedPassword);
    }
}