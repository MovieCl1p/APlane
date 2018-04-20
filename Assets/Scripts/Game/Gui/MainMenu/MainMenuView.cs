using System;
using System.Resources;
using Core.Binder;
using Core.ResourceManager;
using Core.ViewManager;
using Game.Commands;
using Game.Config;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;
using Game.Services.Interfaces;

namespace Game.Gui.MainMenu
{
    public class MainMenuView : BaseView
    {
        [SerializeField] private Button _playBtn;
        [SerializeField] private Button _shopBtn;
        [SerializeField] private Button _optionsBtn;
        [SerializeField] private Image _shipImage;

        protected override void Start()
        {
            base.Start();
            
            _playBtn.onClick.AddListener(OnPLayClick);
            _optionsBtn.onClick.AddListener(OnOptionsClick);
            _shopBtn.onClick.AddListener(OnShopClick);
            UpdateSprite();
        }

        private void UpdateSprite()
        {
            IUserProfileService userProfileService = BindManager.GetInstance<IUserProfileService>();
            string spriteId = userProfileService.GetProfileModel().CurrentSpriteId;
            IShipSpriteLoaderService spriteLoader = BindManager.GetInstance<IShipSpriteLoaderService>();
            Texture2D texture = spriteLoader.GetSprite(spriteId);
            _shipImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }

        private void OnPLayClick()
        {
            StartLevelCommand command = new StartLevelCommand();
            command.Execute();
            
            CloseView();
        }

        private void OnShopClick()
        {
            ViewManager.Instance.SetView(ViewNames.ShopView);
        }

        private void OnOptionsClick()
        {
            ViewManager.Instance.SetView(ViewNames.OptionsView);
        }
        
        protected override void OnReleaseResources()
        {
            _playBtn.onClick.RemoveListener(OnPLayClick);
            _optionsBtn.onClick.RemoveListener(OnOptionsClick);
            _shopBtn.onClick.RemoveListener(OnShopClick);
            
            base.OnReleaseResources();
        }
    }
}
