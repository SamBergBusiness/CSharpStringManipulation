using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeetupsKitMaker
{
    public partial class Form1 : Form
    {
        int kitNumber = 0;

        public Form1()
        {
            InitializeComponent();
            tbKit.Text = "kits:";
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            // The string to return that can then be copy pasted
            kitNumber++;

            //ARMOUR
            // Sets the type and level given to all armour prices (>309 = diamond, <310 = iron)
            int helmetType = 310;
            int chestplateType = 311;
            int leggingsType = 312;
            int bootsType = 313;
            int helmetLevel = 1;
            int chestplateLevel = 1;
            int leggingsLevel = 1;
            int bootsLevel = 1;

            int maxIron = 0;

            // Decides the type of armour the user will wear (with a max of 2 iron pieces) and the level
            if (random.Next(3) == 0)
            {
                if (maxIron < 2)
                {
                    maxIron++;
                    helmetType = 306;
                    helmetLevel++;
                }
            }
            if (random.Next(3) == 0)
            {
                if (maxIron < 2)
                {
                    maxIron++;
                    chestplateType = 307;
                    chestplateLevel++;
                }
            }
            if (random.Next(3) == 0)
            {
                if (maxIron < 2)
                {
                    maxIron++;
                    leggingsType = 308;
                    leggingsLevel++;
                }
            }
            if (random.Next(3) == 0)
            {
                if (maxIron < 2)
                {
                    maxIron++;
                    bootsType = 309;
                    bootsLevel++;
                }
            }

            // Can set some armour values to 5, make sure they are distributed to not be above 5
            for (int i = 0; i < 3; i++)
            {
                int number = random.Next(4);

                if (number == 0)
                {
                    helmetLevel++;
                }
                else if (number == 1)
                {
                    chestplateLevel++;
                }
                else if (number == 2)
                {
                    leggingsLevel++;
                }
                else if (number == 3)
                {
                    bootsLevel++;
                }
            }

            //SWORD+BOW

            int sharpnessLevel = 0;
            int powerLevel = random.Next(2, 4);

            if (helmetLevel + chestplateLevel + leggingsLevel + bootsLevel == 7)
            {
                sharpnessLevel = random.Next(1, 3);
            }
            else if (helmetLevel + chestplateLevel + leggingsLevel + bootsLevel == 8)
            {
                sharpnessLevel = random.Next(1, 4);
            }
            else if (helmetLevel + chestplateLevel + leggingsLevel + bootsLevel == 9)
            {
                sharpnessLevel = random.Next(2, 4);
            }

            //GOLDEN APPLES/HEADS
            // Gives a random number between 3 and 7 (exclusive)
            int goldenApples = random.Next(5, 7);
            int goldenHeads = 9 - goldenApples;

            String returnValue = System.Environment.NewLine+"  kit"+kitNumber+":";
            returnValue += System.Environment.NewLine + "    inventory: ";

            returnValue += "t@276:e@16@"+ sharpnessLevel + ";t@346;t@261:e@48@"+powerLevel+";";

            returnValue += "t@326;t@327;";
            returnValue += "t@322:a@" + goldenApples + ";t@322:a@" + goldenHeads + ":dn@§6§lGolden Head;";
            returnValue += "t@4:a@64;t@262:a@64;null;null;null;null;null;null;null;null;null;null;null;null;null;null;null;null;null;null;t@116;t@145;t@384:a@64;t@326;t@327;t@278;t@279;t@4:a@64;t@364:a@64;";

            returnValue += System.Environment.NewLine + "    armor: ";

            returnValue += "t@"+bootsType+":e@0@"+bootsLevel+";t@"+leggingsType+":e@0@"+leggingsLevel+";t@"+chestplateType+":e@0@"+chestplateLevel+";t@"+helmetType+":e@0@"+helmetLevel+";";

            tbKit.Text += returnValue;
        }
    }
}
