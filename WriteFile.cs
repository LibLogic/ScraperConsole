using System;
using System.IO;
using System.Collections.Generic;

namespace WebScraperNet
{
    class WriteFile
    {
        public static void WriteToFile(List<string> innerText)
        {
            String theFile = @"C:\Users\Tom\Desktop\Development\CapstoneProject\WebScraperNet\tableData.txt";
            File.Delete(theFile);
            File.WriteAllLines(theFile, innerText);
        }
    }
}
