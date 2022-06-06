using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestThreeSixtyFive
{
    public class Calculator
    {
        internal List<string> defaultDelimiters = new List<string>() { "," , "\\n", "\n" };

        public Calculator ()
        {
        }

        // Function to add custom delimiters into default and triming the input string with delimiter definition string
        public void AddCustomDelimiters(ref string src)
        {
            if (src.StartsWith("//")) // to support other custom delimitors
            {
                try
                {
                    List<string> lines = src.Split((string[])defaultDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (lines[0].Length > 3)
                    {
                        if (!lines[0].Contains('[') || !lines[0].Contains(']'))
                            throw new Exception();

                        var charDel = new char[] { '[', ']', '#' };
                        List<string> customDelim = lines[0].Remove(0, 2).Split(charDel, StringSplitOptions.RemoveEmptyEntries).ToList();
                        foreach (var del in customDelim)
                        {
                            if (!defaultDelimiters.Contains(del)) // if already there don't repeat
                                defaultDelimiters.Add(del); // add custom delimitors into main list of delimitor
                        }
                    }
                    else if (lines[0].Length == 3) //  for //#
                    {
                        if (!lines[0].Contains('#'))
                            throw new Exception();
                        
                        var del = lines[0].Remove(0, 2);
                        if (!defaultDelimiters.Contains(del)) // if already there don't repeat
                            defaultDelimiters.Add(del);
                    }
                    
                    // updating input string by triming delimiter definition string
                    src = src.Remove(0, lines[0].Length).TrimStart(',').TrimStart('\n'); // remove delimitor definition
                }
                catch (Exception)
                {
                    throw new Exception("Exception: Custom delimiter.");
                }
            }
        }
        
        // Default allow more than max two numbers, disallow more than 1000 and Disallow negatives numbers
        public int AddNumbers(List<string> numberStrings, bool max2Numbers = false, bool allowMoreThan1K = false, bool allowNegatives = false) 
        {
            int res = 0;
            
            List<int> inValidNums = new List<int>();
            foreach (string num in numberStrings)
            {
                try
                {
                    int intNum = Int32.Parse(num);

                    if (intNum < 0) // for -ve add into invalid
                    {
                        if (!allowNegatives) // if not allowed by default
                            inValidNums.Add(intNum);
                        else
                            res += intNum;
                    }
                    else
                    {
                        if (allowMoreThan1K)
                            res += intNum;
                        else
                        {
                            if (intNum < 1000) // ignore above than 1000 -- means adding no number for above 1000
                                res += intNum;
                        }
                    }
                }
                catch
                { // no need to add if any operand is non int
                }
            }

            if (inValidNums.Count > 0)
            {
                string invalidNumbersStr = "Exception: Invalid Negative Numbers: ";

                foreach (var num in inValidNums)
                    invalidNumbersStr += num.ToString() + " ";

                throw new ExceptionNegative(invalidNumbersStr);
            }
            return res;
        }

        // Function to add Numbers from list
        public int Add(string src, bool max2Numbers = false, bool allowMoreThan1K = false, bool allowNegatives = false)
        {
            AddCustomDelimiters(ref src);

            List<string> numberStrings = src.Split((string[]) defaultDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            if (max2Numbers && numberStrings.Count > 2)
                throw new ExceptionMaxConstraint("More than 2 numbers passed to add.");

            return AddNumbers(numberStrings, max2Numbers, allowMoreThan1K, allowNegatives);
        }
       
    }
}
