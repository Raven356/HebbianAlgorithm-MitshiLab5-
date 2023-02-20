using System;
using System.Collections.Generic;
using System.Text;

namespace MitshiLab5Complete
{
    class HebianLogic
    {
        public int[] HebianAlgorithm(List<List<int>> letters, int[] y)
        {
            int[] weights = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            
            List<bool> eq = new List<bool>();
            eq.Add(false);
            //while (eq.Contains(false))
            {
                int k = 0;
                eq.Clear();
                List<int> answer = new List<int>();
                foreach (var letter in letters)
                {

                    for (int i = 0; i < letter.Count; i++)
                    {
                        weights[i] += letter[i] * y[k];
                    }
                    k++;
                }

                foreach (var letter in letters)
                {
                    answer.Add(GetVectorValue(letter, weights));
                }


                for (int i = 0; i < answer.Count; i++)
                {
                    if (answer[i] > 0)
                        answer[i] = 1;
                    else
                        answer[i] = -1;
                    eq.Add(answer[i] == y[i]);
                }
                //if (!eq.Contains(false))
                //{
                //    System.Windows.Forms.MessageBox.Show("Vectors equal");
                //}
            }
            return weights;
        }

        public int GetVectorValue(List<int> letter, int[] weights)
        {
            int answ = 0;
            for (int i = 1; i < letter.Count; i++)
            {
                answ += letter[i] * weights[i];
            }
            answ += weights[0];
            //System.Windows.Forms.MessageBox.Show(answ.ToString());
            return answ;
        }
    }
}
