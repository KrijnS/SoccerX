using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {

        string[] lastNames;
        string[] frontNames;
        string[] playerNames;

        string[] teams;
        
        static void Main(string[] args)
        {
            Program program = new Program();
            program.AssignPlayerPositions();
        }

        void FillPlayerFile()
        {
            lastNames = File.ReadAllLines(@"C:\Users\Krijn\Documents\Football\Football App\last name.txt", Encoding.UTF8);
            frontNames = File.ReadAllLines(@"C:\Users\Krijn\Documents\Football\Football App\front name.txt", Encoding.UTF8);
            playerNames = new string[1500];

            int lastNamesCount = lastNames.Length;
            int frontNamesCount = frontNames.Length;

            Random random = new Random();

            for(int i = 0; i < 1500; i++)
            {
                int frontNameInt = random.Next(frontNamesCount);
                int lastNameInt = random.Next(lastNamesCount);
                string name = frontNames[frontNameInt] + " " + lastNames[lastNameInt];
                playerNames[i] = name;
                Console.WriteLine(name);
            }

            File.WriteAllLines(@"C:\Users\Krijn\Documents\Football\Football App\player names.txt", playerNames);
        }

        void MakeCitiesClubs()
        {
            teams = File.ReadAllLines(@"C:\Users\Krijn\Documents\Football\teams.txt", Encoding.UTF8);

            int teamCount = teams.Length;

            Random random = new Random();

            string[] additions = { " United", " FC", " City", " SC", " Club"};

            int additionsCount = additions.Length;
            
            for(int i = 0; i < teamCount; i++)
            {
                int addition = random.Next(additionsCount);
                teams[i] += additions[addition];
            }

            File.WriteAllLines(@"C:\Users\Krijn\Documents\Football\teams.txt", teams);
        }

        void AssignTeamColours()
        {
            teams = File.ReadAllLines(@"C:\Users\Krijn\Documents\Football\teams.txt", Encoding.UTF8);

            int teamCount = teams.Length;

            Random random = new Random();
            
            string[] additions = {"Black", "Blue", "Cyan", "DarkBlue", "DarkRed", "Gray", "Green", "Magenta", "Red", "White", "Yellow"};

            int additionsCount = additions.Length;

            for (int i = 0; i < teamCount; i++)
            {
                int homeColor = random.Next(additionsCount);
                int awayColor = random.Next(additionsCount);
                while(homeColor == awayColor)
                {
                    awayColor = random.Next(additionsCount);
                }

                teams[i] += ",ConsoleColor." + additions[homeColor] + ",ConsoleColor." + additions[awayColor];
            }

            File.WriteAllLines(@"C:\Users\Krijn\Documents\Football\teams.txt", teams);
        }

        void AssignPlayersToTeams()
        {
            playerNames = File.ReadAllLines(@"C:\Users\Krijn\Documents\Football\Football App\player names.txt", Encoding.UTF8);    

            Random random = new Random();

            teams = File.ReadAllLines(@"C:\Users\Krijn\Documents\Football\teams.txt", Encoding.UTF8);

            ArrayList tempTeams = new ArrayList();

            int teamCount = teams.Length;

            for(int i = 0; i < teamCount; i++)
            {
                tempTeams.Add(teams[i]);
                for(int j = 0; j < 22; j++)
                {
                    int playerCount = playerNames.Length;

                    int randomPlayer = random.Next(playerCount);

                    tempTeams.Add(playerNames[randomPlayer]);

                    playerNames = playerNames.Where(val => val != playerNames[randomPlayer]).ToArray();
                }
            }

            File.WriteAllLines(@"C:\Users\Krijn\Documents\Football\teams.txt", tempTeams.ToArray(typeof(string)) as string[]);
        }

        void AssignPlayerPositions()
        {
            Random random = new Random();

            teams = File.ReadAllLines(@"C:\Users\Krijn\Documents\Football\teams.txt", Encoding.UTF8);

            int teamCount = teams.Length;

            int counter = 0;

            for (int i = 0; i < teamCount / 23; i++)
            {
                counter++;
                for (int j = 0; j < 22; j++)
                {
                    if (j < 2)
                    {
                        teams[counter] += ",GK";
                    }
                    else if (j < 4)
                    {
                        teams[counter] += ",RB";
                        if (random.Next(0, 2) == 1)
                        {
                            teams[counter] += "/RWB";
                        }
                    }
                    else if (j < 8)
                    {
                        teams[counter] += ",CB";
                        if (random.Next(0, 2) == 1)
                        {
                            teams[counter] += "/CDM";
                        }
                    }
                    else if (j < 10)
                    {
                        teams[counter] += ",LB";
                        if (random.Next(0, 2) == 1)
                        {
                            teams[counter] += "/LWB";
                        }
                    }
                    else if (j < 16)
                    {
                        teams[counter] += ",CM";
                        if (random.Next(0, 2) == 1)
                        {
                            teams[counter] += "/CAM";
                        }
                    }
                    else if (j < 18)
                    {
                        teams[counter] += ",RW";
                        if (random.Next(0, 2) == 1)
                        {
                            teams[counter] += "/RM";
                        }
                    }
                    else if (j < 20)
                    {
                        teams[counter] += ",ST";
                        if (random.Next(0, 2) == 1)
                        {
                            teams[counter] += "/CF";
                        }
                    }
                    else if (j < 22)
                    {
                        teams[counter] += ",LW";
                        if (random.Next(0, 2) == 1)
                        {
                            teams[counter] += "/LM";
                        }
                    }
                    counter++;
                }
            }

            File.WriteAllLines(@"C:\Users\Krijn\Documents\Football\teams.txt", teams);
        }
    }
}
