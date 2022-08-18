using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
           this.Name = name;
           this.OpenPositions = openPositions;
           this.Group = group;
           this.Players = new List<Player>();
        }
        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public int Count => this.Players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) && string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (this.OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            this.OpenPositions--;
            this.Players.Add(player);

            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            if (this.Players.Any(x => x.Name == name))
            {
                Player player = this.Players.FirstOrDefault(x => x.Name == name);
                this.Players.Remove(player);
                this.OpenPositions++;
                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            if (this.Players.Any(x => x.Position == position))
            {
                var playersForRemove = this.Players.FindAll(x => x.Position == position);
                this.Players.RemoveAll(x => x.Position == position);
                this.OpenPositions += playersForRemove.Count;
                return playersForRemove.Count;

            }

            return 0;
        }

        public Player RetirePlayer(string name)
        {
            if (this.Players.Any(x=>x.Name == name))
            {
                Player player = this.Players.FirstOrDefault(x => x.Name == name);
                player.Retired = true;
                return player;

            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> awardedPlayers = this.Players.FindAll(x => x.Games >= games).ToList();
            return awardedPlayers;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            var listOfNotRetiredPlayers = this.Players.Where(x => x.Retired != true).ToList();
            result.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");

            foreach (var player in listOfNotRetiredPlayers)
            {
                result.AppendLine(player.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
