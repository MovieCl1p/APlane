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

        public void UpdateUserProgress(int bestScore)
        {

        }

        private void OnFail()
        {
            Debug.Log("Fail");
        }
    }
}