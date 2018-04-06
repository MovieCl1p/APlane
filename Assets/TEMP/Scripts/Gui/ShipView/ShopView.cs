using Core.Binder;
using Core.ViewManager;
using Game.Commands;
using Game.Config.Ship;
using Game.Data;
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
        private ShipItemView _item;

        [SerializeField]
        private Transform _list;

        [SerializeField]
        private RectTransform _content;

        private List<ShipItemView> _items = new List<ShipItemView>();

        [SerializeField]
        private Button _BackBtn;

        protected override void Start()
        {
            base.Start();

            IShipService service = BindManager.GetInstance<IShipService>();
            _BackBtn.onClick.AddListener(OnMainMenuClick);
        }

        private void OnMainMenuClick()
        {
            ViewManager.Instance.SetView(ViewNames.MainMenuScreen);
        }

        public void UpdateView(List<ShipConfig> ships )
        {
            ClearList();

            for (int i = 0; i < ships.Count; i++)
            {
                ShipItemView item = Instantiate<ShipItemView>(_item, _list);

                item.UpdateView(ships[i]);

                item.OnClick += OnShipClick;

                _items.Add(item);
            }

            Vector2 newSize = _content.sizeDelta;
            newSize.x = ships.Count * _item.GetComponent<RectTransform>().sizeDelta.x;

            _content.sizeDelta = newSize;
        }

        private void OnShipClick(ShipConfig config)
        {
            CloseView();

            StartLevelCommand command = new StartLevelCommand();
            command.Execute();
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
    }
}
