using Core;
using Game.Config;
using Game.Gui.ShopView;
using System;
using Core.Binder;
using Game.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.ShipView
{
    public class ShopItemView : BaseMonoBehaviour
    {
        public event Action<ShipConfig> OnClick;

        [SerializeField]
        private Text _shipName;

        [SerializeField]
        private Image _shipImage;

        [SerializeField]
        private Button _clickBtn;
        
        [SerializeField]
        private GameObject _selectedImage;
        
        private ShipConfig _config;

        protected override void Start()
        {
            base.Start();

            _clickBtn.onClick.AddListener(OnBtnClick);
        }
        
        private void OnBtnClick()
        {
            if (OnClick != null)
            {
                OnClick(_config);
            }
        }

        public void UpdateView(ShipConfig config)
        {
            _config = config;
            _shipName.text = config.SpriteId;
            Texture2D texture = config.Texture;
            _shipImage.sprite =  Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            UpdateSelectedView();
        }
        
        public void UpdateSelectedView()
        {
            IUserProfileService userProfileService = BindManager.GetInstance<IUserProfileService>();
            _selectedImage.SetActive(userProfileService.GetProfileModel().CurrentSpriteId == _config.SpriteId);
        }

        protected override void OnReleaseResources()
        {
            _clickBtn.onClick.RemoveListener(OnBtnClick);
            base.OnReleaseResources();
        }
    }
}