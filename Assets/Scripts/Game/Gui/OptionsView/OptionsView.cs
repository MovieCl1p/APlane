using Core.ViewManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Game.Data;

namespace Game.Gui.OptionsView
{
    public class OptionsView : BaseView
    {
        [SerializeField] private Button _backBtn;

        [SerializeField] private Button _soundVolume;

        
        protected override void Start()
        {
            base.Start();

            _backBtn.onClick.AddListener(OnCloseClick);
        }
        
        private void OnCloseClick()
        {
            CloseView();
        }

        protected override void OnReleaseResources()
        {
            _backBtn.onClick.RemoveListener(OnCloseClick);
            base.OnReleaseResources();
        }
    }
}