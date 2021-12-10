using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Data
{
    public class LoginData: IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "ntnhien19091999@gmail.com", "12345" };
            yield return new object[] { "ntnhien@gmail.com", "12345" };
           
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
