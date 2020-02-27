using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIapp.Service
{
    public class TestService : ITestService
    {
        public async Task<int> StreamProcessingScore(string input)
        {
            int totalScore = 0;
            int depth = 0;
            bool inGarbage = false;
            bool ignore = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (ignore)
                {
                    ignore = false;
                    continue;
                }
                else if(input[i] == '!') 
                    { ignore = true; }

                else if (inGarbage)
                {
                    if (input[i] == '>') 
                    { inGarbage = false; }
                }

                else if (input[i] == '<') 
                    { inGarbage = true; }

                else if(input[i]=='{')
                {
                    depth += 1;
                    totalScore += depth;
                }
                else if(input[i] == '}')
                {
                    depth -= 1;
                }

                
            }

            return totalScore;
        }
    }
}
