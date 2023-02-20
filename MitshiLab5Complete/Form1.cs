using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MitshiLab5Complete
{
    public partial class Form1 : Form
    {
        List<List<int>> letters = new List<List<int>>
        {
            new List<int>{1, -1, 1, -1, 1, -1, 1, -1, 1, -1 },
            new List<int>{1, 1, -1, -1, 1, -1, -1, 1, 1, 1 },
            new List<int>{1, 1, 1, 1, 1, 1, -1, 1, 1, 1 },
            new List<int>{1, 1, -1, 1, -1, 1, -1, 1, -1, 1 }
        };
        List<int[]> weights = new List<int[]>();
        HebianLogic hebianLogic = new HebianLogic();
        public Form1()
        {
            InitializeComponent();
            weights.Add(hebianLogic.HebianAlgorithm(letters, new int[] { 1, -1, -1, -1 }));

            letters = new List<List<int>>
            {
                new List<int>{1, 1, -1, -1, 1, -1, -1, 1, 1, 1 },
                new List<int>{1, -1, 1, -1, 1, -1, 1, -1, 1, -1 },
                new List<int>{1, 1, 1, 1, 1, 1, -1, 1, 1, 1 },
                new List<int>{1, 1, -1, 1, -1, 1, -1, 1, -1, 1 }
            };
            weights.Add(hebianLogic.HebianAlgorithm(letters, new int[] { 1, -1, -1, -1 }));

            letters = new List<List<int>>
            {
                new List<int>{1, 1, 1, 1, 1, 1, -1, 1, 1, 1 },
                new List<int>{1, -1, 1, -1, 1, -1, 1, -1, 1, -1 },
                new List<int>{1, 1, -1, -1, 1, -1, -1, 1, 1, 1 },
                new List<int>{1, 1, -1, 1, -1, 1, -1, 1, -1, 1 }
            };
            weights.Add(hebianLogic.HebianAlgorithm(letters, new int[] { 1, -1, -1, -1 }));

            letters = new List<List<int>>
            {
                new List<int>{1, 1, -1, 1, -1, 1, -1, 1, -1, 1 },
                new List<int>{1, -1, 1, -1, 1, -1, 1, -1, 1, -1 },
                new List<int>{1, 1, -1, -1, 1, -1, -1, 1, 1, 1 },
                new List<int>{1, 1, 1, 1, 1, 1, -1, 1, 1, 1 }
                
            };
            weights.Add(hebianLogic.HebianAlgorithm(letters, new int[] { 1, -1, -1, -1 }));

        }

        private void recognizeButton_Click(object sender, EventArgs e)
        {
            List<int> letter = new List<int>();
            List<CheckBox> checkBoxes = new List<CheckBox>();
            checkBoxes.Add(checkBox1);
            checkBoxes.Add(checkBox2);
            checkBoxes.Add(checkBox3);
            checkBoxes.Add(checkBox4);
            checkBoxes.Add(checkBox5);
            checkBoxes.Add(checkBox6);
            checkBoxes.Add(checkBox7);
            checkBoxes.Add(checkBox8);
            checkBoxes.Add(checkBox9);

            foreach(var x in checkBoxes)
            {
                if (x.Checked)
                {
                    letter.Add(1);
                }
                else
                {
                    letter.Add(-1);
                }
            }

            letter.Insert(0, 1);
            bool knownLetter = true;
            for(int i = 0; i < weights.Count; i++)
            {
                if(hebianLogic.GetVectorValue(letter, weights[i]) > 0)
                {
                    switch(i + 1)
                    {
                        case 1:
                            answerText.Text = "O";
                            break;
                        case 2:
                            answerText.Text = "L";
                            break;
                        case 3:
                            answerText.Text = "E";
                            break;
                        case 4:
                            answerText.Text = "X";
                            break;
                        
                    }
                    knownLetter = true;
                    break;
                }
                knownLetter = false;
            }

            if (!knownLetter)
            {
                answerText.Text = "Unknown Letter!!!";
            }
        }
    }
}
