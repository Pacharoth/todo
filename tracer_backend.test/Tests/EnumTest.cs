using tracer_backend.test.PasswordTest;

namespace tracer_backend.test.Tests;

public class EnumTest
{
    [Fact]
    public void Is_Correct_Enum()
    {
        TaskStatus.TaskStatus status = TaskStatus.TaskStatus.UNCOMPLETED;
        Assert.Equal("UNCOMPLETED",status.ToString());
    }
}