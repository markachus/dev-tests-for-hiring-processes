using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Core
{
    public class Calculator
    {
        public static int Add(string numbers)
        {
            char delimiter = ','; //default delimeter
            List<int> negatives = new List<int>(); //List of negatives to show
            int sum = 0; // result

            numbers = numbers.Trim(); //remove white-spaces

            //EMPTY OR WHITE-SPACE scenario
            if (string.IsNullOrEmpty(numbers)) return 0;


            //SINGLE NUMBER scenario
            if (int.TryParse(numbers, out sum)) 
            {
                if (sum < 0) throw new Exception(String.Format("Negatives not allowed: {0}", sum));
            } else // not parsable
            {

                //PARSE CUSTOM DELIMETER
                if (numbers.StartsWith("//")) {
                    string delimeter_token = numbers.Split('\n')[0]; /*gets //[delimeter] */
                    delimiter = (char)(delimeter_token.Substring(2)[0]); //gets [delimiter]
                    numbers = numbers.Substring(4); //remove delimiter info from the original string
                }

                string[] portions = numbers.Split(new char[] { delimiter, '\n'});

                foreach(string token in portions)
                {
                    int tmp = int.Parse(token);
                    sum += tmp;
                    if (tmp < 0) negatives.Add(tmp); //store negfatives values
                }

                //DETECT AND SHOW NEGATIVES
                if (negatives.Count > 0) {
                    StringBuilder sNegatives = new StringBuilder("");
                    sNegatives.Append("[");
                    foreach (int neg in negatives) sNegatives.Append(neg.ToString() + ",");
                    sNegatives.Remove(sNegatives.Length - 1, 1);
                    sNegatives.Append("]");
                    throw new Exception(String.Format("Negatives not allowed: {0}",sNegatives.ToString()));
                } 

            }

            return sum;

        }
    }
}
