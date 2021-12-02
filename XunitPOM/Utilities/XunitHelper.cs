using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Abstractions;

namespace XunitPOM.Utilities
{
    public class XunitHelper : FactAttribute
    {
        /// <summary>
        /// Get display name from test case and create new test report
        /// </summary>
        /// <param name="DisplayName"></param>
        public static void CreateTestReport([CallerMemberName] string DisplayName = null)
        {
            string displayName = DisplayName;
            ReportHelper.test = ReportHelper.extent.CreateTest("Test case: " + ReportHelper.TestCaseCount()).Info(displayName);
        }
    }
}
