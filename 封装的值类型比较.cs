using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 值类型比较
{
    public class AddClass1
    {
        public int Val;

        public static AddClass1 operator +(AddClass1 op1,AddClass1 op2) //重载运算符+
        {
            AddClass1 returnVal = new AddClass1();
            returnVal.Val = op1.Val + op2.Val;
            return returnVal;
        }

        public static AddClass1 operator -(AddClass1 op1) //重载运算符-
        {
            AddClass1 returnVal = new AddClass1();
            returnVal.Val = -op1.Val;
            return returnVal;
        }

        public static bool operator >=(AddClass1 op1,AddClass1 op2) //重载<或>必须成对
        {
            return (op1.Val >= op2.Val);
        }

        public static bool operator <=(AddClass1 op1,AddClass1 op2)
        {
            return (op1.Val <= op2.Val);
        }

        public static bool operator <(AddClass1 op1,AddClass1 op2)
        {
            return !(op1 >= op2);
        }

        public static bool operator >(AddClass1 op1,AddClass1 op2)
        {
            return !(op1 <= op2);
        }

        public static bool operator ==(AddClass1 op1,AddClass1 op2) //重载==或！=也要成对
        {
            return (op1.Val == op2.Val);
        }

        public static bool operator !=(AddClass1 op1,AddClass1 op2)
        {
            return !(op1 == op2);
        }

        public override bool Equals(object op1)
        {
            return Val == ((AddClass1)op1).Val;
        }

        public override int GetHashCode()
        {
            return Val;
        }

    }
    class 封装的值类型比较
    {
        static void Main(string[] args)
        {
            AddClass1 op1 = new AddClass1();
            op1.Val = 5;
            AddClass1 op2 = new AddClass1();
            op2.Val = 3;
            AddClass1 op3 = op1 + op2;
            AddClass1 op4 = -op1;
            Console.WriteLine("{0},{1}", op3.Val, op4.Val);
            Console.ReadKey();
        }
    }
}
