using Core;
using Game.Config;
using Game.Gui.ShopView;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.ShipView
{
    public class ShopItemView : BaseMonoBehaviour
    {
        public event Action<GameConfig> OnClick;

        [SerializeField]
        private Text _shipName;

        [SerializeField]
        private Image _shipImage;

        [SerializeField]
        private int _iconId;

        [SerializeField]
        private Button _clickBtn;
        
        private GameConfig _config;

        private int iconId;
        
        protected override void Start()
        {
            base.Start();

            _clickBtn.onClick.AddListener(OnClicked);

            iconId = _iconId;

            SaveShips(iconId);

            LoadShip(iconId);
        }
        
        private void OnClicked()
        {
            if (OnClick != null)
            {
                OnClick(_config);
            }
        }

        public void UpdateView(GameConfig config)
        {
            _config = config;

            _shipName.text = config.PlayerPrefab;
        }

        public void SaveShips(int id)
        {
            switch (id)
            {
                case 1:
                    Resources.Load<GameObject>("Ships/Eagle");
                    PlayerPrefs.SetInt("Eagle",1);
                    break;

                case 2:
                    Resources.Load<GameObject>("Ships/Shuttle");
                    PlayerPrefs.SetInt("Shuttle", 2);
                    break;

                case 3:
                    Resources.Load<GameObject>("Ships/XFighter");
                    PlayerPrefs.SetInt("XFighter", 3);
                    break;

                case 4:
                    Resources.Load<GameObject>("Ships/DeltaFighter");
                    PlayerPrefs.SetInt("DeltaFighter", 4);
                    break;

                default:
                    break;
            }
        }

        public void LoadShip(int id)
        {
            switch (id)
            {
                case 1:
                    PlayerPrefs.GetInt("Eagle", 1);
                    Resources.Load<GameObject>("Ships/Eagle");
                    break;

                case 2:
                    PlayerPrefs.GetInt("Shuttle", 2);
                    Resources.Load<GameObject>("Ships/Shuttle");
                    break;

                case 3:
                    PlayerPrefs.GetInt("XFighter", 3);
                    Resources.Load<GameObject>("Ships/XFighter");
                    break;

                case 4:
                    PlayerPrefs.GetInt("DeltaFighter", 4);
                    Resources.Load<GameObject>("Ships/DeltaFighter");
                    break;

                default:
                    break;
            }
        }
        
        protected override void OnDestroy()
        {
            _clickBtn.onClick.RemoveListener(OnClicked);
            
            base.OnDestroy();
        }
    }
}