using System;
using System.Diagnostics;

namespace XUnitTest_POM.Constraints
{
    public class WaitHelper
    {
        public static bool WaitFor(
        Func<bool> condition,
        int timeout = 5)
        {
            var watch = new Stopwatch();
            bool result = false;
            watch.Start();
            while (true)
            {
                try
                {
                    if (condition())
                    {
                        result = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    // Stop wait helper
                    if (ex.Message.Contains("Testcase Fail")) throw;
                }
                if (watch.Elapsed.TotalSeconds >= timeout)
                {
                    watch.Stop();
                    break;
                }
            }
            return result;
        }
    }
}
