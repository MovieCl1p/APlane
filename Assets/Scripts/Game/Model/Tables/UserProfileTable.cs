using SQLite4Unity3d;

namespace Game.Model.Tables
{
    public class UserProfileTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        public int Score { get; set; }
    }
}