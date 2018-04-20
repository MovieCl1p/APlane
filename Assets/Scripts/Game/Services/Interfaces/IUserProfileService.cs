using Game.Model;

namespace Game.Services.Interfaces
{
    public interface IUserProfileService
    {
        void CreateProfileModel();

        UserProfileModel GetProfileModel();

        void UpdateUserProfileSprite(string spriteId);
    }
}