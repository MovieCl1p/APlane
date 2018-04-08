using System;
using Core;
using Core.Binder;
using Core.ViewManager;
using Game.Model;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;
//using Game.Events;
using Core.Dispatcher;

namespace Game.Gui.LevelWindow
{
    public class FinishView : BaseView
    {
        [SerializeField] private Text _levelTime;

        [SerializeField] private Button _backButton;

        [SerializeField] private Button _menuButton;

        private LevelSessionModel _levelModel;

//        private GameView.GameView _gameView;

        protected override void Start()
        {
            base.Start();

            _backButton.onClick.AddListener(OnBackClick);

            _menuButton.onClick.AddListener(OnMenuClick);

            _levelModel = BindManager.GetInstance<LevelSessionModel>();

            _levelTime.text = _levelModel.LevelTime.ToString();
        }

        private void OnBackClick()
        {
            Time.timeScale = 1;
            
//            ViewManager.Instance.GetLayerById(LayerNames.ThreeDLayer).RemoveCurrentView();
            
        }

        private void OnMenuClick()
        {
            ViewManager.Instance.SetView(ViewNames.MainMenuScreen);

            IDispatcher dispatcher = BindManager.GetInstance<IDispatcher>();
//            dispatcher.Dispatch(LevelEventsEnum.Quit);

            Time.timeScale = 1;
        }
    }
}
