using System;
using System.IO;

namespace MIS_Coding_Challenge
{
    public class StumpMeUtility
    {
        private StumpMe[] stumpMe;

        public StumpMeUtility(StumpMe[] stumpMe)
        {
            this.stumpMe = stumpMe;
        }

        public void LoadItems()
        {
            StumpMe.SetCount(0);
            StreamReader inFile = new StreamReader("stumpMeItems.txt");
            string line = inFile.ReadLine();

            while (line != null)
            {
                string[] temp = line.Split("#");

                stumpMe[StumpMe.GetCount()] = new StumpMe(temp[0], temp[1], double.Parse(temp[2]), int.Parse(temp[3]));

                StumpMe.IncCount();

                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public void AddItem(StumpMe newStumpMe)
        {
            stumpMe[StumpMe.GetCount()] = newStumpMe;
            StumpMe.IncCount();
        }
        public void SaveItemsToFile()
        {
            StreamWriter outFile = new StreamWriter("stumpMeItems.txt");
            for (int i = 0; i < StumpMe.GetCount(); i++)
            {
                if (stumpMe[i] != null)
                {
                    outFile.WriteLine(stumpMe[i].ToFile());
                }
            }
            outFile.Close();
        }

    }
}
