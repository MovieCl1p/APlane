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
        private Transform _list;

        [SerializeField]
        private RectTransform _content;

        private List<ShopItemView> _items = new List<ShopItemView>();

        [SerializeField]
        private Button _backBtn;

        protected override void Start()
        {
            base.Start();

            _backBtn.onClick.AddListener(OnCloseClick);
            //ResourcesCache.GetConfig<GameConfig>(ConfigData.GameConfigPath);

            UpdateView();
        }

        private void OnCloseClick()
        {
            CloseView();
        }

        public void UpdateView(List<ShopItemView> items)
        {
            ClearList();

            for (int i = 0; i < items.Count; i++)
            {
                ShopItemView item = Instantiate<ShopItemView>(_item, _list);

                item.UpdateView(items[i]);

                item.OnClick += OnShipClick;

                _items.Add(item);
            }

            Vector2 newSize = _content.sizeDelta;
            newSize.x = items.Count * _item.GetComponent<RectTransform>().sizeDelta.x;

            _content.sizeDelta = newSize;
        }

        private void OnShipClick(GameConfig config)
        {
            if (PlayerPrefs.HasKey("Eagle"))
            {
                PlayerPrefs.GetInt("Eagle");
            }
        }

        protected override void OnDestroy()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].OnClick -= OnShipClick;
            }

            base.OnDestroy();
        }

        private void ClearList()
        {
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                _items[i].OnClick -= OnShipClick;
                Destroy(_items[i].gameObject);
            }
        }

        protected override void OnReleaseResources()
        {
            _backBtn.onClick.RemoveListener(OnCloseClick);
            base.OnReleaseResources();
        }
    }
}
