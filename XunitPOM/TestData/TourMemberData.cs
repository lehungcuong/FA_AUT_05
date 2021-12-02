using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitPOM.TestData
{
    public class TourMemberData
    {
        public static IEnumerable<object[]> UserData =>
        new List<object[]>
        {
            new object[] { "Dinh", "Thi", "DinhThi123@gmail.com", "0918023045", "8 King Gorden Cali", "Tung", "Son", "Son", "Tung" },
            new object[] { "Minh", "Thi", "MinhThi123@gmail.com", "0918023041", "9 King Gorden Cali", "Son", "Goku", "Goku", "Son" },
        };
    }
}
