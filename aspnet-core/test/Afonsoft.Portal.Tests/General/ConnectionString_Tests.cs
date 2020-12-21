using Shouldly;
using Xunit;

namespace Afonsoft.Portal.Tests.General
{
    // ReSharper disable once InconsistentNaming
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder("Server=localhost; Database=Portal; Trusted_Connection=True;");
            csb["Database"].ShouldBe("Portal");
        }
    }
}
