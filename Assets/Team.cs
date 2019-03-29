using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Team : MonoBehaviour
{
    // Start is called before the first frame update

    string[] teamsFile;

    Team[] teams;

    int teamCount;

    System.Random random;

    private string teamName { get; set; }
    private ConsoleColor homeColor { get; set; }
    private ConsoleColor awayColor { get; set; }
    private int reputation { get; set; }
    private Player[] players { get; set; }



    public Team(string teamName, ConsoleColor homeColor, ConsoleColor awayColor, int reputation, Player[] players)
    {
        this.teamName = teamName;
        this.homeColor = homeColor;
        this.awayColor = awayColor;
        this.reputation = reputation;
        this.players = players;
    }

    void Start()
    {
        teamsFile = File.ReadAllLines(@"C:\Users\Krijn\Documents\Football\teams.txt", Encoding.UTF8);

        teamCount = teamsFile.Length;

        random = new System.Random();

        teams = InitTeams();

        for(int i = 0; i < teams.Length; i++)
        {
            Debug.Log(teams[i].teamName);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    Team[] InitTeams()
    {
        Team newTeam = null;

        Team[] tempTeams = new Team[teamCount/23];

        for(int i = 0; i < teamCount; i += 23)
        {
            string[] components = teamsFile[i].Split(',');
            newTeam.teamName = components[0];
            newTeam.homeColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), components[1]);
            newTeam.awayColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), components[2]);
            newTeam.reputation = Convert.ToInt32(components[3]);

            tempTeams[i / 23] = newTeam;

            //for(int j = i + 1; i < j + 23; j++)
            //{

            //}
        }

        return tempTeams;
    }
}
