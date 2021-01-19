using System;
using System.Linq;
using System.Collections.Generic;

namespace Tasl01_Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwords = new Dictionary<string, string>();

            SortedDictionary<string, List<int>> userPoints = new SortedDictionary<string, List<int>>();

            SortedDictionary<string, List<string>> userContests = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string[] nextComand = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(nextComand[0].ToLower() == "end of contests")
                {
                    break;
                }

                string nextContest = nextComand[0];
                string nextPassword = nextComand[1];

                if(passwords.ContainsKey(nextContest))
                {
                    passwords[nextContest] = nextPassword;
                }
                else
                {
                    passwords.Add(nextContest, nextPassword);
                }
            }

            while (true)
            {
                string[] nextComand = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (nextComand[0].ToLower() == "end of submissions")
                {
                    break;
                }

                string nextContest = nextComand[0];
                string nextPassword = nextComand[1];
                string nextUser = nextComand[2];
                int nextPoints = int.Parse(nextComand[3]);

                if(!(passwords.ContainsKey(nextContest)))
                {
                    continue;
                }

                if (!(passwords[nextContest] == nextPassword))
                {
                    continue;
                }

                if (userContests.ContainsKey(nextUser))
                {
                    if (userContests[nextUser].Contains(nextContest))
                    {
                        int index = userContests[nextUser].IndexOf(nextContest);

                        if (userPoints[nextUser][index] < nextPoints)
                        {
                            userPoints[nextUser].RemoveAt(index);
                            userPoints[nextUser].Insert(index, nextPoints);
                        }
                    }
                    else
                    {
                        userContests[nextUser].Add(nextContest);
                        userPoints[nextUser].Add(nextPoints);
                    }
                }
                else
                {
                    userContests.Add(nextUser, new List<string> { nextContest });
                    userPoints.Add(nextUser, new List<int> { nextPoints });
                }
                
                

            }
            
            Console.WriteLine($"Best candidate is {userPoints.Keys.Max()} with total {userPoints[userPoints.Keys.Max()].Sum()} points.");

            foreach (var name in userPoints)
            {
                Console.WriteLine(name);
                foreach (var item in name.Value.OrderByDescending(x => x))
                {
                    Console.WriteLine($"# {userContests[name][item]} -> {item}");
                }
                
            }
        }
    }
}

/*
foreach (var name in userPoints )
            {
                Console.WriteLine(name.Key);
                foreach (var item in name.Value.OrderByDescending(x => x))
                {
                    
                    Console.WriteLine($"# {userContests.} -> {item}");
                }
                
            }
*/