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

        public static int KS(int CL,int cou,int [] pro,int [] we,int [] ins, ref int[] i_t, ref int[] i_o_i_t)
        {
            int[,] KCA = new int[cou + 1, CL + 1];
            int max(int a, int b) { return (a > b) ? a : b; }
            int W = CL;
            int h = 1;
            //for 0 items total value is zero
            for (int i = 0; i <= CL; i++)
            {
                KCA[0, i] = 0;
            }
            //for 0 weight total value is zero
            for (int i = 0; i <= cou; i++)
            {
                KCA[i, 0] = 0;
            }

            for (int i = 0; i <= cou; ++i)
            {
                for (int w = 0; w <= CL; ++w)
                {
                    if (i == 0 || w == 0)
                    {
                        KCA[i, w] = 0;
                    }
                    else
                    {
                        int m = 0;
                        for (int j = 0; j <= ins[i]; j++)
                        {
                            if (j * we[i] <= w)
                            {
                                m = max(m, j * pro[i] + KCA[i - 1, w - j * we[i]]);
                                KCA[i, w] = m;
                            }
                        }

                    }

                }
            }
            for (int i = cou; i > 0 && W > 0; i--)
            {
                if (KCA[i, W] != KCA[i - 1, W])
                {
                    i_t[cou - i] = i;
                    for (h = 1; h <= ins[i]; h++)
                    {
                        if (KCA[i, W] - KCA[i - 1, W - h * we[i]] == h * pro[i])
                            break;
                    }
                    i_o_i_t[cou - i] = h;
                    W -= (h * we[i]);
                }
                
                else if (KCA[i, W] == KCA[i - 1, W])
                {
                    continue;
                }
            }
            return KCA[cou, CL];
        }
        public static int AliBabaSol(int camelsLoad, int itemsCount, int[] weights, int[] profits, int[] instances, ref int[] items_taken, ref int[] instances_of_items_taken)
        {
            return KS(camelsLoad, itemsCount, profits, weights, instances,ref items_taken,ref instances_of_items_taken);
        }
    }
}
