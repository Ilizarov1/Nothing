using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class Vector
    {
        public double? R = null;
        public double? Theta = null;

        public double? ThetaRadians
        {
            get
            {   //转换角度到弧度
                return (Theta * Math.PI / 180.0);
            }
        }

        public Vector(double? r,double? theta)
        {
            //标准化
            if (r < 0)
            {
                r = -r;
                theta += 180;
            }
            theta = theta % 360;//取余

            R = r;
            Theta = theta;
        }

        public static Vector operator +(Vector op1,Vector op2)//向量加法
        {
            try
            {
                //为新向量获得(x,y)坐标
                double newX = op1.R.Value * Math.Cos(op1.ThetaRadians.Value)
                    + op2.R.Value * Math.Cos(op2.ThetaRadians.Value);
                double newY = op1.R.Value * Math.Sin(op1.ThetaRadians.Value)
                    + op2.R.Value * Math.Sin(op2.ThetaRadians.Value);

                //转换为(r,theta)
                double newR = Math.Sqrt(newX * newX + newY * newY);
                double newTheta = Math.Atan2(newY, newX) * 180.0 / Math.PI;

                return new Vector(newR, newTheta);
            }
            catch
            {
                //异常就返回空向量
                return new Vector(null, null);
            }
        }

        public static Vector operator -(Vector op1)//借助标准化给向量掉头Amazing!!!难以置信!!!的操作
        {
            return new Vector(-op1.R, op1.Theta);
        }

        public static Vector operator -(Vector op1,Vector op2)//向量减法
        {
            return op1 + (-op2);
        }

        public override string ToString()
        {
            //获得坐标字符串
            string rString = R.HasValue ? R.ToString() : "null";
            string thetaString = Theta.HasValue ? Theta.ToString() : "null";

            return string.Format("({0},{1})", rString, thetaString);
        }
    }
}
