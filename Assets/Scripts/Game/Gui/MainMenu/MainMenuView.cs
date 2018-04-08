using System;
using Core.ViewManager;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;

namespace Game.Gui.MainMenu
{
    public class MainMenuView : BaseView
    {
        [SerializeField]
        private Button _playBtn;
        
        [SerializeField]
        private Button _shopBtn;

        protected override void Start()
        {
            base.Start();

            //_playBtn.onClick.AddListener(OnPlayClick);
        }

        private void OnPlayClick()
        {
            ViewManager.Instance.SetView(ViewNames.GameScreen);
        }
        
        private void OnShopClick()
        {
            ViewManager.Instance.SetView(ViewNames.ShopScreen);
        }

        protected override void OnReleaseResources()
        {
            _playBtn.onClick.RemoveListener(OnPlayClick);
            base.OnReleaseResources();
        }
    }
}
