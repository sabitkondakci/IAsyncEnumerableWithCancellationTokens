```c#
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace IAsyncEnu
{
    internal class Program
    {
        [CompilerGenerated]
        private sealed class <GetStaffList>d__1 : IEnumerable<Staff>, IEnumerable, IEnumerator<Staff>, IDisposable, IEnumerator
        {
            private int <>1__state;

            private Staff <>2__current;

            private int <>l__initialThreadId;

            private int count;

            public int <>3__count;

            private Random <rand>5__2;

            private int <i>5__3;

            Staff IEnumerator<Staff>.Current
            {
                [DebuggerHidden]
                get
                {
                    return <>2__current;
                }
            }

            object IEnumerator.Current
            {
                [DebuggerHidden]
                get
                {
                    return <>2__current;
                }
            }

            [DebuggerHidden]
            public <GetStaffList>d__1(int <>1__state)
            {
                this.<>1__state = <>1__state;
                <>l__initialThreadId = Environment.CurrentManagedThreadId;
            }

            [DebuggerHidden]
            void IDisposable.Dispose()
            {
            }

            private bool MoveNext()
            {
                int num = <>1__state;
                if (num != 0)
                {
                    if (num != 1)
                    {
                        return false;
                    }
                    <>1__state = -1;
                    <i>5__3++;
                }
                else
                {
                    <>1__state = -1;
                    <rand>5__2 = new Random();
                    <i>5__3 = 0;
                }
                if (<i>5__3 < count)
                {
                    Thread.Sleep(100);
                    if (<i>5__3 == 100)
                    {
                        return false;
                    }
                    Staff staff = new Staff();
                    staff.Id = <i>5__3;
                    staff.Name = string.Format("Staff {0}", <i>5__3);
                    staff.DepartmentId = <rand>5__2.Next(1, 51);
                    staff.Salary = <rand>5__2.Next(1500, 10000);
                    <>2__current = staff;
                    <>1__state = 1;
                    return true;
                }
                return false;
            }

            bool IEnumerator.MoveNext()
            {
                //ILSpy generated this explicit interface implementation from .override directive in MoveNext
                return this.MoveNext();
            }

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            [DebuggerHidden]
            IEnumerator<Staff> IEnumerable<Staff>.GetEnumerator()
            {
                <GetStaffList>d__1 <GetStaffList>d__;
                if (<>1__state == -2 && <>l__initialThreadId == Environment.CurrentManagedThreadId)
                {
                    <>1__state = 0;
                    <GetStaffList>d__ = this;
                }
                else
                {
                    <GetStaffList>d__ = new <GetStaffList>d__1(0);
                }
                <GetStaffList>d__.count = <>3__count;
                return <GetStaffList>d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<Staff>)this).GetEnumerator();
            }
        }

        public void M(string[] args)
        {
            TestStaff();
        }

        [IteratorStateMachine(typeof(<GetStaffList>d__1))]
        private static IEnumerable<Staff> GetStaffList(int count)
        {
            <GetStaffList>d__1 <GetStaffList>d__ = new <GetStaffList>d__1(-2);
            <GetStaffList>d__.<>3__count = count;
            return <GetStaffList>d__;
        }

        private static void TestStaff()
        {
            IEnumerator<Staff> enumerator = GetStaffList(1000000).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Staff current = enumerator.Current;
                    if (current.Id <= 200)
                    {
                        object[] array = new object[4];
                        array[0] = current.Id;
                        array[1] = current.Name;
                        array[2] = current.DepartmentId;
                        array[3] = current.Salary;
                        Console.WriteLine(string.Format("Id:{0} Name:{1} DepartmentID:{2} Salary:{3}", array));
                        continue;
                    }
                    break;
                }
            }
            finally
            {
                if (enumerator != null)
                {
                    enumerator.Dispose();
                }
            }
        }
    }
    internal class Staff
    {
        [CompilerGenerated]
        private int <Id>k__BackingField;

        [CompilerGenerated]
        private string <Name>k__BackingField;

        [CompilerGenerated]
        private int <DepartmentId>k__BackingField;

        [CompilerGenerated]
        private int <Salary>k__BackingField;

        public int Id
        {
            [CompilerGenerated]
            get
            {
                return <Id>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <Id>k__BackingField = value;
            }
        }

        public string Name
        {
            [CompilerGenerated]
            get
            {
                return <Name>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <Name>k__BackingField = value;
            }
        }

        public int DepartmentId
        {
            [CompilerGenerated]
            get
            {
                return <DepartmentId>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <DepartmentId>k__BackingField = value;
            }
        }

        public int Salary
        {
            [CompilerGenerated]
            get
            {
                return <Salary>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                <Salary>k__BackingField = value;
            }
        }
    }
}

```