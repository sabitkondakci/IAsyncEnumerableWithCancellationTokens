#region Original Code


using System;
using System.Collections.Generic;
using System.Threading;

namespace IAsyncEnu
{
    class Program
    {
        static void Main(string[] args)
        {
            TestStaff();
        }

        static IEnumerable<Staff> GetStaffList(int count)
        {
            // List<Staff> staff = new List<Staff>();
            var rand = new Random();

            for (int i = 0; i <= count; i++)
            {
               // Thread.Sleep(100);
                if (i == 100)
                    yield break;

                yield return new Staff { Id = i, Name = $"Staff {i}", DepartmentId = rand.Next(1, 51), Salary = rand.Next(1500, 10_000) };
            }

            // return staff;
        }

        static void TestStaff()
        {
            var staffList = GetStaffList(1_000_000);

            foreach (var item in staffList)
            {
                if (item.Id <= 1000)
                    Console.WriteLine($"Id:{item.Id} Name:{item.Name} DepartmentID:{item.DepartmentId} Salary:{item.Salary}");
                else
                    break;

            }
        }
    }

    internal struct Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int Salary { get; set; }
    }
}

#endregion


#region Decompiled Version
/*
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;


namespace IAsyncEnu
{
    internal class Program
    {

        public static void Main()
        {
            TestStaff();
        }

        private sealed class GetStaffListClass : IEnumerable<Staff>, IEnumerable, IEnumerator<Staff>, IDisposable,
            IEnumerator
        {
            private int _stateOne;

            private Staff _currentTwo;

            private readonly int _initialThreadId;

            private int _count;

            public int countTwo;

            private Random _random;

            private int _i;

            Staff IEnumerator<Staff>.Current => _currentTwo;

            object IEnumerator.Current => _currentTwo;


            public GetStaffListClass(int stateOne)
            {
                this._stateOne = stateOne;
                _initialThreadId = Environment.CurrentManagedThreadId;
                
            }

            void IDisposable.Dispose()
            {
                // dispose;
            }


            private bool MoveNext()
            {
                int num = _stateOne;

                if (num != 0)
                {
                    if (num != 1)
                    {
                        return false;
                    }

                    _stateOne = -1;
                    _i++;
                }
                else
                {
                    _stateOne = -1;
                    _random = new Random();
                    _i = 0;
                }

                if (_i <= _count)
                {
                    Thread.Sleep(100);

                    if (_i == 100)
                    {
                        return false;
                    }

                    var staff = _currentTwo.Salary == 0 ? new Staff() : _currentTwo;

                    staff.Id = _i;
                    staff.Name = $"Staff {_i}";
                    staff.DepartmentId = _random.Next(1, 51);
                    staff.Salary = _random.Next(1500, 10000);

                    _currentTwo = staff;
                    _stateOne = 1;
                    return true;
                }

                return false;
            }

            bool IEnumerator.MoveNext()
            {
                //ILSpy generated this explicit interface implementation from .override directive in MoveNext
                return this.MoveNext();
            }


            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }


            IEnumerator<Staff> IEnumerable<Staff>.GetEnumerator()
            {
                GetStaffListClass getStaffListClass;

                if (_stateOne == -2 && _initialThreadId == Environment.CurrentManagedThreadId)
                {
                    _stateOne = 0;
                    getStaffListClass = this;
                }
                else
                {
                    getStaffListClass = new GetStaffListClass(0);
                }

                getStaffListClass._count = countTwo;
                return getStaffListClass;
            }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<Staff>)this).GetEnumerator();
            }
        }

        private static IEnumerable<Staff> GetStaffList(int count)
        {
            GetStaffListClass getStaffList1 = new GetStaffListClass(-2) { countTwo = count };
            return getStaffList1;
        }

        private static readonly object[] _array = new object[4];
        private static void TestStaff()
        {
            IEnumerable<Staff> staffList = GetStaffList(1000000);
            IEnumerator<Staff> enumerator = staffList.GetEnumerator();
            
            try
            {
                while (enumerator.MoveNext())
                {
                    Staff current = enumerator.Current;

                    if (current.Id <= 1000)
                    {
                        _array[0] = current.Id;
                        _array[1] = current.Name;
                        _array[2] = current.DepartmentId;
                        _array[3] = current.Salary;
                        Console.WriteLine(string.Format("Id:{0} Name:{1} DepartmentID:{2} Salary:{3}", _array));
                        continue;
                    }

                    break;
                }
            }

            finally
            {
                enumerator.Dispose();
            }
        }
    }

    internal struct Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int Salary { get; set; }
    }
}

*/
#endregion