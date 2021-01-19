using System;
using System.Linq;
using System.Collections.Generic;

namespace Task01_Ranking_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwords = new Dictionary<string, string>();

            while (true)
            {
                string[] nextComand = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (nextComand[0].ToLower() == "end of contests")
                {
                    break;
                }

                string nextContest = nextComand[0];
                string nextPassword = nextComand[1];

                if (passwords.ContainsKey(nextContest))
                {
                    passwords[nextContest] = nextPassword;
                }
                else
                {
                    passwords.Add(nextContest, nextPassword);
                }
            }

            Dictionary<string, Dictionary<string, int>> ranking = new Dictionary<string, Dictionary<string, int>>();

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

                if(passwords.ContainsKey(nextContest) && passwords[nextContest] == nextPassword)
                {
                    if (ranking.ContainsKey(nextUser))
                    {
                        if (ranking[nextUser].ContainsKey(nextContest))
                        {
                            if (ranking[nextUser][nextContest] < nextPoints)
                            {
                                ranking[nextUser][nextContest] = nextPoints;
                            }
                        }
                        else
                        {
                            ranking[nextUser] = new Dictionary<string, int>();

                        }
                    }
                    else
                    {
                        ranking.Add(nextUser, new Dictionary<string, int>());
                    }
                }
            }

            Console.WriteLine($"Best candidate is {ranking.OrderBy(x => x.Value.Values.Sum()).Last().Key} with total {ranking.OrderBy(x => x.Value.Values.Sum()).Last().Value.Values.Sum()} points.");
            /*
            foreach (var name in userPoints)
            {
                Console.WriteLine(name.Key);
                foreach (var item in name.Value.OrderByDescending(x => x))
                {

                    Console.WriteLine($"# {name.Value} -> {item}");
                }

            }
            */
        }
    }
}
