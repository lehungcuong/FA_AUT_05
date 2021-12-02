using System.Collections;
using System.Collections.Generic;

namespace XUnitTest_POM.TestData
{
    public class ClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {"Trang", "Tran", "trangtran99@gmail.com", "097810236", "240/28 CMT8 P10 Q3",
                "Viet Nam", "Viet Nam", "Mr", "Tuan", "Hoang", "Miss", "Thu", "Nguyen" };
            yield return new object[] {"Trang", "Tran", "trangtran99@gmail.com", "123456789", "240/28 CMT8 P10 Q3",
                "Viet Nam", "Viet Nam", "Mr", "Tuan", "Hoang", "Miss", "Thu", "Nguyen" };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
