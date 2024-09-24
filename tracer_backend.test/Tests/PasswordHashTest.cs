using tracer_backend.test.PasswordTest;

namespace tracer_backend.test.Tests;

public class PasswordHashTest
{
    [Fact]
    public void Is_Password_Match()
    {
        PasswordHash password =new PasswordHash();
        var hashedpassword =password.HashPassword("1234");
        bool verify = password.VerifyPassword(hashedpassword,"1234");
        Assert.True(verify,"Password  is not matching");
    }
}