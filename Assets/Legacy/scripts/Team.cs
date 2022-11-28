namespace Legacy.scripts
{
    public struct Team
    {
        private teamColor _teamColor;

        public teamColor GetTeam()
        {
            return _teamColor;
        }

        public bool Equals(Team other)
        {
            return _teamColor == other._teamColor;
        }

        public static bool operator ==(Team team1, Team team2)
        {
            return team1._teamColor.Equals(team2._teamColor);
        }
        public static bool operator !=(Team team1, Team team2)
        {
            return !team1._teamColor.Equals(team2._teamColor);
        }
        //public static bool operator !(Team team)
        public Team(teamColor teamColor)
        {
            this._teamColor = teamColor;
        }
        public enum teamColor
        {
            Red,
            Blue
        }

        public bool CompareTeam(Team team)
        {
            if (this._teamColor == team._teamColor) 
                return true;
            return false;
        }
    }
}
