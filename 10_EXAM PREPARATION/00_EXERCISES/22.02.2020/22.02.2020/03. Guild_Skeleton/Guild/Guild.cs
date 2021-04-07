using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster = new List<Player>();

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Player> Roster { get; set; }
        public int Count { get { return Roster.Count; } }

        public void AddPlayer(Player player)
        {
            if (Roster.Count < Capacity)
            {
                Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = Roster.FirstOrDefault(p => p.Name == name);
            if (player == null)
            {
                return false;
            }
            Roster.Remove(player);
            return true;
        }
        public void PromotePlayer(string name)
        {
            Player player = Roster.FirstOrDefault(p => p.Name == name);
            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player player = Roster.FirstOrDefault(p => p.Name == name);
            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string xclass)
        {
            List<Player> players = new List<Player>();

            for (int i = 0; i < Roster.Count; i++)
            {
                Player player = Roster[i];
                if (player.Class == xclass)
                {
                    players.Add(player);
                    Roster.Remove(player);
                }
            }
            return players.ToArray();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");
            foreach (Player player in Roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
