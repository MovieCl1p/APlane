using Core.ViewManager;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;
using System;
using Game.Commands;

namespace Game.Gui.MainMenu
{
    public class MainMenuView : BaseView
    {
        [SerializeField] private Button PlayBtn;
        [SerializeField] private Button ShipBtn;
        [SerializeField] private Button OptionsBtn;

        protected override void Start()
        {
            base.Start();

            PlayBtn.onClick.AddListener(OnPLayClick);
            OptionsBtn.onClick.AddListener(OnOptionsClick);
            ShipBtn.onClick.AddListener(OnShip);
        }

        private void OnPLayClick()
        {
            StartLevelCommand command = new StartLevelCommand();
            command.Execute();
        }

        private void OnShip()
        {
            ViewManager.Instance.SetView(ViewNames.ShipView);
            
        }

        private void OnOptionsClick()
        {
            ViewManager.Instance.SetView(ViewNames.OptionsView);
        }
    }
}