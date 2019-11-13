using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliBaba
{
    public class AliBaba
    {
        //Your Code is Here:
        //==================
        /// <summary>
        /// Calculate the max total profit that can be carried within the given camels' load
        /// </summary>
        /// <param name="camelsLoad">max load that can be carried by camels</param>
        /// <param name="itemsCount">number of items</param>
        /// <param name="weights">weight of each item [ONE-BASED array]</param>
        /// <param name="profits">profit of each item [ONE-BASED array]</param>
        /// <param name="instances">number of instances for each item [ONE-BASED array]</param>
        /// <param name="items_taken">Empty array of length = itemsCount, to fill it with the indecies of the items selected</param>
        /// <param name="instances_of_items_taken">Empty array of length = itemsCount, to fill it with the instances taken from each selected item</param>
        /// <returns>Max total profit</returns>
        /// 
        
        public static int KS(int CL,int[] we,int [] pr,int co)
        {
            int max(int a, int b) { return (a > b) ? a : b; }

            if (co==0 || CL==0)
            {
                return 0;
            }
            if (we[co - 1] > CL)
            {
                return KS(CL, we, pr, co - 1);
            }
            else return max(KS(CL - we[co - 1], we, pr, co - 1) + pr[co - 1], KS(CL, we, pr, co - 1));
        }
        public static int AliBabaSol(int camelsLoad, int itemsCount, int[] weights, int[] profits, int[] instances, ref int[] items_taken, ref int[] instances_of_items_taken)
        {

            //int[,] K = new int[itemsCount + 1, camelsLoad + 1];
            // //for 0 items total value is zero
            // for (int i = 0; i <= camelsLoad; i++)
            // {
            //     K[0, i] = 0;
            // }
            // //for 0 weight total value is zero
            // for (int i = 0; i <= itemsCount; i++)
            // {
            //     K[i, 0] = 0;
            // }

            // for (int i = 0; i <= itemsCount; ++i)
            // {
            //     for (int w = 0; w <= camelsLoad; ++w)
            //     {
            //         if (i == 0 || w == 0)
            //             K[i, w] = 0;
            //         else if (weights[i - 1] <= w)
            //             K[i, w] = Math.Max(profits[i - 1] + K[i - 1, w - weights[i - 1]], K[i - 1, w]);
            //         else
            //             K[i, w] = K[i - 1, w];
            //     }
            // }

            return KS(camelsLoad, weights, profits, itemsCount);
        }
    }
}
