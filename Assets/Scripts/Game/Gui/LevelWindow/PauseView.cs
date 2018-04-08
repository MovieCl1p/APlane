using System;
using Core.Binder;
using Core.Dispatcher;
using Core.ViewManager;
using Game.Data;
//using Game.Events;
using Game.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.LevelWindow
{
    public class PauseView : BaseView
    {
        [SerializeField] private LevelSessionModel _levelModel;

        [SerializeField] private Button _backButton;

        [SerializeField] private Button _menuButton;

        [SerializeField] private Text _levelTime;
        
        

        protected override void Start()
        {
            base.Start();

            _backButton.onClick.AddListener(OnBackClick);

            _menuButton.onClick.AddListener(OnMenuClick);
            
            _levelModel = BindManager.GetInstance<LevelSessionModel>();
            
            _levelTime.text = Math.Round(_levelModel.LevelTime, 1).ToString();
        }

        private void OnMenuClick()
        {
            CloseView();
            ViewManager.Instance.SetView(ViewNames.MainMenuScreen);

            IDispatcher dispatcher = BindManager.GetInstance<IDispatcher>();
//            dispatcher.Dispatch(LevelEventsEnum.Quit);

            Time.timeScale = 1;
        }

        private void OnBackClick()
        {
            Time.timeScale = 1;
            CloseView();
        }
    }
}
