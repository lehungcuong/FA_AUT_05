using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitPOM.TestData
{
    public class TourClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Dinh", "Thi", "DinhThi123@gmail.com", "0918023045", "8 King Gorden Cali", "Tung", "Son", "Son", "Tung" };
            yield return new object[] { "Minh", "Thi", "MinhThi123@gmail.com", "0918023041", "9 King Gorden Cali", "Son", "Goku", "Goku", "Son" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
