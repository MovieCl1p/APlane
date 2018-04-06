﻿using Core.ViewManager;
using UnityEngine;
using UnityEngine.UI;
using Core.Binder;
using Game.Model;
using Game.Data;
using Game.Player.Control;
using Game.Player;
using Game.Gui.Components;
using System;

namespace Game.Gui.GameView
{
    public class GameHudView : BaseView
    {
        [SerializeField] private Text _levelTime;

        [SerializeField] private Button _pauseBtn;

        [SerializeField] private ExtendedButton _LeftBtn;

        [SerializeField] private ExtendedButton _RightBtn;

        private bool _paused;

        private LevelSessionModel _levelModel;

        protected override void Start()
        {
            base.Start();

            _pauseBtn.onClick.AddListener(OnPauseClick);

            _levelModel = BindManager.GetInstance<LevelSessionModel>();

            _levelTime.text = _levelModel.LevelTime.ToString();
            

            var control = BindManager.GetInstance<IPlayerControl>();

            PlayerControlView controlView = new PlayerControlView();

            controlView.LeftButton = _LeftBtn;
            controlView.RightButton = _RightBtn;

            //control.SetView(controlView);
        }

        private void OnPauseClick()
        {
            Time.timeScale = 0;
            
            ViewManager.Instance.SetView(ViewNames.PauseView);
        }

        protected override void Update()
        {
            base.Update();
            
            _levelTime.text = Math.Round(_levelModel.LevelTime, 1).ToString();
            
        }

        protected override void OnReleaseResources()
        {
            base.OnReleaseResources();
            
            _pauseBtn.onClick.RemoveListener(OnPauseClick);
        }
    }
}
