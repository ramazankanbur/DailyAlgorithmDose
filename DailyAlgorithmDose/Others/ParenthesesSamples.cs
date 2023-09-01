using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAlgorithmDose.Others
{
    public class ParenthesesSamples
    {
        static List<string> paranthesis = new List<string>() { "(", ")" };

        public static string GenerateValidParantheses(int length)
        {
            string result = string.Empty;

            if (length % 2 != 0)
            {
                return "not valid input.";
            }
            
            var iterationCountForOpen = length / 2;
             
            bool isCloseParanthesisValid = true;

            for (int i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    result += paranthesis[i];
                    iterationCountForOpen -= 1;
                    continue;
                }

                Random random = new Random();
                var randomParamthesis = random.Next(0, 2);
                
                if (paranthesis[randomParamthesis] == "(" && iterationCountForOpen > 0 || !isCloseParanthesisValid)
                {
                    result += "(";
                    iterationCountForOpen -= 1;
                    isCloseParanthesisValid = true;
                }
                else if (paranthesis[randomParamthesis] == ")" && isCloseParanthesisValid || iterationCountForOpen == 0)
                {
                    result += ")";
                    if (result.Count(x => x == '(') <= result.Count(x => x == ')'))
                    {
                        isCloseParanthesisValid = false;
                    }
                }
            }

            return result;
        }

    }
}
