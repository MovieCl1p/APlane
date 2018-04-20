namespace Game.Model
{
    public class UserProfileModel
    {
        private int _bestScore;
        private string _currentSpriteId;
        
        public int BestScore
        {
            get { return _bestScore; }
            set { _bestScore = value; }
        }

        public string CurrentSpriteId
        {
            get { return _currentSpriteId; }
            set { _currentSpriteId = value; }
        }
    }
}