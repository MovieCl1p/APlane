using System;
using Core.ViewManager;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;

namespace Game.Gui.MainMenu
{
    public class MainMenuView : BaseView
    {
        [SerializeField] private Button _playBtn;
        [SerializeField] private Button _shopBtn;
        [SerializeField] private Button _optionsBtn;

        protected override void Start()
        {
            base.Start();
            
            _playBtn.onClick.AddListener(OnPLayClick);
            _optionsBtn.onClick.AddListener(OnOptionsClick);
            _shopBtn.onClick.AddListener(OnShip);
        }

        private void OnPLayClick()
        {
//            StartLevelCommand command = new StartLevelCommand();
//            command.Execute();
        }

        private void OnShip()
        {
//            ViewManager.Instance.SetView(ViewNames.ShipView);
            
        }

        private void OnOptionsClick()
        {
//            ViewManager.Instance.SetView(ViewNames.OptionsView);
        }
    }
}
