using Core.Binder;
using Core.Commands;
using Core.Dispatcher;
using Core.ViewManager;
using Core.ViewManager.Data;
using Game.Data;
using Game.Model;
using UnityEngine;

namespace Game.Gui.Game
{
    public class GameView : BaseView
    {
        
        [SerializeField] private Transform _levelHolder;

        [SerializeField] private Camera _camera;

        private IDispatcher _dispatcher;

        private LevelSessionModel _levelModel;

        private ICommand _restartLevelCommand;

        private bool _paused;
        
        protected override void Start()
        {
            base.Start();

            _dispatcher = BindManager.GetInstance<IDispatcher>();
//            _dispatcher.AddListener(LevelEventsEnum.Restart, OnLevelRestart);
//            _dispatcher.AddListener(LevelEventsEnum.Finish, OnLevelFinish);
//            _dispatcher.AddListener(LevelEventsEnum.Quit, OnLevelQuit);
//
//            _levelModel = BindManager.GetInstance<LevelSessionModel>();
//
//            _levelModel.Player.SetCamera(_camera);
//            
//            _restartLevelCommand = new RestartLevelCommand(_camera.transform);
//            _restartLevelCommand.Execute();
        }

//        protected override void Update()
//        {
//            base.Update();
//
//            _time += Time.deltaTime;
//            _levelModel.LevelTime = _time;
//        }
//        
//        private void OnLevelFinish()
//        {
//            _levelModel.LevelTime = _time;
//            
//            ViewManager.Instance.SetView(ViewNames.FinishView);
//        }
//        
//        private void OnLevelRestart()
//        {
//            _restartLevelCommand.Execute();
//
//            _time = 0;
//            _levelModel.LevelTime = 0;
//        }

        private void OnLevelQuit()
        {
            OnReleaseResources();
        }
        
        protected override void OnReleaseResources()
        {
            base.OnReleaseResources();

//            _dispatcher.RemoveListener(LevelEventsEnum.Restart, OnLevelRestart);
//            _dispatcher.RemoveListener(LevelEventsEnum.Finish, OnLevelFinish);
//            _dispatcher.RemoveListener(LevelEventsEnum.Quit, OnLevelQuit);
            
            if (_levelModel.Player != null)
            {
                Destroy(_levelModel.Player.gameObject);
            }

            if (_levelModel.Rocket != null)
            {
                Destroy(_levelModel.Rocket.gameObject);
            }

            if (_levelModel.Asteroid != null)
            {
                Destroy(_levelModel.Asteroid.gameObject);
            }
        }
    }
}
