using Core.UnityUtils;
using Game.Gui.Components;
using Game.Player.Control;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

namespace Game.Player.Control
{
    public class MobilePlayerControl //: IPlayerControl, IUpdateHandler
    {
        private PlayerControlView _playerView;
        
        public event Action OnRightClick;

        public event Action OnLeftClick;

        private bool _jumpPress = false;

        public bool IsUpdating { get; set; }

        public bool IsRegistered { get; set; }

        public bool IsClickPressed
        {
            get
            {
                return _jumpPress;
            }
        }

        public MobilePlayerControl()
        {
            //UpdateNotifier.Instance.Register(this);
        }
        
        public void OnUpdate()
        {
           
        }
        
        public void SetView(PlayerControlView playerControlView)
        {
            _playerView = playerControlView;

            _playerView.LeftButton.OnClick += OnLeftClicked;
            _playerView.RightButton.OnClick += OnRightClicked;
            _playerView.RightButton.OnPointDown += _rightBtn_OnPointDown;
            _playerView.LeftButton.OnPointDown += _leftBtn_OnPointDown;
            _playerView.RightButton.OnPointUp += _rightBtn_OnPointUp;
            _playerView.LeftButton.OnPointUp += _leftBtn_OnPointUp;
        }

        private void _rightBtn_OnPointUp()
        {
            _jumpPress = false;
        }

        private void _leftBtn_OnPointUp()
        {
            _jumpPress = false;
        }

        private void _rightBtn_OnPointDown()
        {
            _jumpPress = true;
            if (OnRightClick != null)
            {
                OnRightClicked();
            }
        }

        private void _leftBtn_OnPointDown()
        {
            _jumpPress = true;
            if (OnLeftClick != null)
            {
                OnLeftClicked();
            }
        }

        private void OnRightClicked()
        {
            _jumpPress = false;
        }

        private void OnLeftClicked()
        {
            if (OnLeftClick != null)
            {
                OnLeftClicked();
            }
        }
    }
}
