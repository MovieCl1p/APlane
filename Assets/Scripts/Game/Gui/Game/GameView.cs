using Core.Binder;
using Core.Camera;
using Core.Commands;
using Core.Dispatcher;
using Core.ViewManager;
using Core.ViewManager.Data;
using Game.Commands.Level;
using Game.Data;
using Game.Factory;
using Game.Model;
using UnityEngine;

namespace Game.Gui.Game
{
    public class GameView : BaseView
    {
        [SerializeField] 
        private Transform _content;
        
        [SerializeField] 
        private CameraSmoothFollow _camera;
        
        private IDispatcher _dispatcher;

        private LevelSessionModel _levelSessionModel;

        protected override void Start()
        {
            base.Start();

            _dispatcher = BindManager.GetInstance<IDispatcher>();
            
            _dispatcher.AddListener(LevelEvent.Restart, OnLevelRestart);
            _dispatcher.AddListener(LevelEvent.Finish, OnLevelFinish);
            _dispatcher.AddListener(LevelEvent.Quit, OnLevelQuit);

            _levelSessionModel = BindManager.GetInstance<LevelSessionModel>();
            
            CreateLevel();
            
            RestartLevelCommand command = new RestartLevelCommand();
            command.Execute();
            
            _dispatcher.Dispatch(LevelEvent.Start);
        }

        private void CreateLevel()
        {
            CreatePlayerCommand playerCommand = new CreatePlayerCommand(_content);
            playerCommand.Execute();
            
            playerCommand.Player.SetCamera(_camera.Camera);
            
            CreateAsteroidCommand asteroidCommand = new CreateAsteroidCommand(Vector3.back);
            asteroidCommand.Execute();
            
            CreateRocketCommand rocketCommand = new CreateRocketCommand(playerCommand.Player.CachedTransform);
            rocketCommand.Execute();
            
            _camera.FollowTarget(playerCommand.Player.CachedTransform);
        }

        protected override void Update()
        {
            base.Update();
            _levelSessionModel.LevelTime += Time.deltaTime;
        }
        
        private void OnLevelFinish()
        {
            ViewManager.Instance.SetView(ViewNames.FinishView);
        }
        
        private void OnLevelRestart()
        {
            RestartLevelCommand command = new RestartLevelCommand();
            command.Execute();
        }

        private void OnLevelQuit()
        {
            ViewManager.Instance.SetView(ViewNames.MainMenuScreen);
        }
        
        protected override void OnReleaseResources()
        {
            base.OnReleaseResources();

            _dispatcher.RemoveListener(LevelEvent.Restart, OnLevelRestart);
            _dispatcher.RemoveListener(LevelEvent.Finish, OnLevelFinish);
            _dispatcher.RemoveListener(LevelEvent.Quit, OnLevelQuit);
            
            
        }
    }
}
