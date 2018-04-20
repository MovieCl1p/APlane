using Core.Database;
using Core.UnityUtils.Loom;
using Game.Data;
using Game.Model;
using Game.Model.Tables;
using Game.Services.Interfaces;
using UnityEngine;

namespace Game.Services
{
    public class UserProfileService : IUserProfileService
    {
        private UserProfileModel _userProfileModel;

        public void CreateProfileModel()
        {
            _userProfileModel = new UserProfileModel();
            if (!PlayerPrefs.HasKey("PlayerSprite"))
            {
                PlayerPrefs.SetString("PlayerSprite", "green");
            }
            
            string spriteId = PlayerPrefs.GetString("PlayerSprite");
            _userProfileModel.CurrentSpriteId = spriteId;
        }
        
        public void UpdateUserProgress(int bestScore)
        {

        }

        public UserProfileModel GetProfileModel()
        {
            return _userProfileModel;
        }
        
        public void UpdateUserProfileSprite(string spriteId)
        {
            _userProfileModel.CurrentSpriteId = spriteId;
            PlayerPrefs.SetString("PlayerSprite", spriteId);
        }

        private void OnFail()
        {
        }
    }
}