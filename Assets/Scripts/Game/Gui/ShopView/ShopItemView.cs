using Core;
//using Game.Config.Ship;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.ShipView
{
    public class ShopItemView : BaseMonoBehaviour
    {
//        public event Action<ShipConfig> OnClick;

        [SerializeField]
        private Text _shipName;

        [SerializeField]
        private Button _clickBtn;

//        private ShipConfig _config;

        protected override void Start()
        {
            base.Start();

//            _clickBtn.onClick.AddListener(OnClicked);
        }
        
//        private void OnClicked()
//        {
//            if (OnClick != null)
//            {
//                OnClick(_config);
//            }
//        }

//        public void UpdateView(ShipConfig config)
//        {
//            _config = config;
//
//            _shipName.text = config.ShipName;
//        }

//        protected override void OnDestroy()
//        {
//            _clickBtn.onClick.RemoveListener(OnClicked);
//
//            base.OnDestroy();
//        }
    }
}