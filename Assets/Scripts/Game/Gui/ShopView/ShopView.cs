using Core.Binder;
using Core.ResourceManager;
using Core.ViewManager;
using Game.Commands;
using Game.Config;
using Game.Data;
using Game.Gui.ShopView;
using Game.Services.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.ShipView
{
    public class ShopView : BaseView
    {
        [SerializeField]
        private ShopItemView _item;

        [SerializeField]
        private Transform _contentTransform;

        [SerializeField]
        private RectTransform _content;

        private List<ShopItemView> _items = new List<ShopItemView>();

        [SerializeField]
        private Button _backBtn;

        protected override void Start()
        {
            base.Start();

            _backBtn.onClick.AddListener(OnCloseClick);
            UpdateView();
        }

        private void OnCloseClick()
        {
            CloseView();
        }

        public void UpdateView()
        {
            ClearList();

            GameConfig config = ResourcesCache.GetConfig<GameConfig>(ConfigData.GameConfigPath);
            
            for (int i = 0; i < config.ShipConfigs.Count; i++)
            {
                ShipConfig shipConfig = config.ShipConfigs[i];
                
                ShopItemView item = Instantiate<ShopItemView>(_item, _contentTransform);

                item.UpdateView(shipConfig);
                item.OnClick += OnShipClick;

                _items.Add(item);
            }
        }

        private void OnShipClick(ShipConfig config)
        {
            IUserProfileService userProfileService = BindManager.GetInstance<IUserProfileService>();
            userProfileService.UpdateUserProfileSprite(config.SpriteId);

            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].UpdateSelectedView();
            }
        }

        private void ClearList()
        {
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                _items[i].OnClick -= OnShipClick;
                Destroy(_items[i].gameObject);
            }
            
            _items.Clear();
        }

        protected override void OnReleaseResources()
        {
            _backBtn.onClick.RemoveListener(OnCloseClick);
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].OnClick -= OnShipClick;
            }
            
            base.OnReleaseResources();
        }
    }
}
