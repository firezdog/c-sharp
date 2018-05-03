﻿using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var mountVernons = 
                from artist in Artists
                where artist.Hometown == "Mount Vernon"
                select new { artist.ArtistName, artist.Age };
            // Name: DMX, age: 46

            //Who is the youngest artist in our collection of artists?
            var byAge =
                from artist in Artists
                orderby artist.Age ascending
                select new { artist.ArtistName, artist.Age };
            // Name: Chance The Rapper, Age: 23

            //Display all artists with 'William' somewhere in their real name
            var Williams =
                from artist in Artists
                where artist.RealName.Contains("William")
                select new { artist.ArtistName, artist.RealName };

            //Display the 3 oldest artist from Atlanta
            var oldest = 
                (from artist in Artists
                orderby artist.Age descending
                select artist).Take(3);

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            var nony = 
                from artist in Artists
                join artistGroup in Groups on artist.GroupId equals artistGroup.Id
                where artist.Hometown != "New York City"
                select new { artistGroup.GroupName };

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            var wuTangs = 
                from grp in Groups 
                join artist in Artists on grp.Id equals artist.GroupId
                where grp.GroupName == "Wu-Tang Clan"
                select new { artist.ArtistName };
            
            //Display groups with names less than 8 characters.
            var eightless =
                from grp in Groups
                where grp.GroupName.Length < 8 
                select new { grp.GroupName };
        }
    }
}