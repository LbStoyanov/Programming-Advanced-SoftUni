using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new List<Player>();
        }
        public int Count 
            => Roster.Count;

        public List<Player> Roster { get; set; }

        public string Name { get; set; }
        public int  Capacity { get; set; }


        public void AddPlayer(Player player)
        {
            if (this.Capacity > 0)
            {
                this.Roster.Add(player);
                this.Capacity--;
            }
        }

        public bool RemovePlayer(string name)
        {
            if (this.Roster.Any(p => p.Name == name))
            {
                Player playerToRemove = Roster.FirstOrDefault(p => p.Name == name);
                this.Roster.Remove(playerToRemove);
                this.Capacity++;
                return true;    
            }
            
            return false;
        }

        public void PromotePlayer(string name)
        {
            if (this.Roster.Any(p => p.Name == name))
            {
                Player player = this.Roster.FirstOrDefault(p => p.Name == name);
                if (player.Rank != "Member")
                {
                    player.Rank = "Member";
                }
                
            }
        }

        public void DemotePlayer(string name)
        {
            if (this.Roster.Any(p => p.Name == name))
            {
                Player player = this.Roster.FirstOrDefault(p => p.Name == name);

                if (player.Rank != "Trial")
                {
                    player.Rank = "Trial";
                }
            }
        }

        public Player[] KickPlayersByClass(string _class)
        {
            Player[] playersToReturn = this.Roster.FindAll(x => x.Class == _class).ToArray();
            this.Roster.RemoveAll(x => x.Class == _class);
            this.Capacity += playersToReturn.Length;
            return playersToReturn;
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in Roster)
            {
                sb.AppendLine($"Player {player.Name}: {player.Class}");
              
                sb.AppendLine($"Rank: {player.Rank}");
                
                sb.AppendLine($"Description: {player.Description}");
            }

            return sb.ToString();
        }

    }
}
