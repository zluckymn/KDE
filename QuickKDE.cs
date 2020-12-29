using System;
using System.Collections.Generic;
using System.Linq;
public class QuickKDE
    {

        
        public static double gauss(double x)
        {
            return (1 / Math.Sqrt(2 * Math.PI)) * Math.Exp(-0.5 * (x * x));
        }

        public static double KDE(double x, double[] data_array, double bandwidth = 0.1)
        {
            var N = data_array.Length;
            double res = 0.0;
            if (data_array.Length == 0) return 0;
            foreach (var value in data_array)
            {
                res += gauss((x - value) / bandwidth);
            }
            res /= (N * bandwidth);
            return res;
        }

        public static List<double> cluster(double[] input_array,double bandwidth=0.1)
        {
            if (bandwidth == 0)
            {
                //std标准差， 
                bandwidth = 1.05 * StDev(input_array) * (Math.Pow(input_array.Length, (-1 / 5)));
            }
            var result = new List<BsonDocument>();
             
            foreach (var value in input_array.Distinct().OrderBy(c=>c))
            {
                var item= KDE(value, input_array, bandwidth);
                 
                result.Add(value);
            }
            return result.ToList();

          }
        public static double StDev(double[] arrData) //计算标准偏差
        {
            double xSum = 0;
            double xAvg = 0;
            double sSum = 0;
            double tmpStDev = 0;
            int arrNum = arrData.Length;
            for (int i = 0; i < arrNum; i++)
            {
                xSum += arrData[i];
            }
            xAvg = xSum / arrNum;
            for (int j = 0; j < arrNum; j++)
            {
                sSum += ((arrData[j] - xAvg) * (arrData[j] - xAvg));
            }
            tmpStDev = Convert.ToSingle(Math.Sqrt((sSum / (arrNum))).ToString());
            return tmpStDev;
        }
    }
