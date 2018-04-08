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

        [SerializeField] private AudioSource _audioSource;
        
        protected override void Start()
        {
            base.Start();

            _backBtn.onClick.AddListener(OnMainMenuClick);
            _soundVolume.onClick.AddListener(OnSound);
        }
        
        protected override void Update()
        { 
            base.Update();
            
        }

        private void OnMainMenuClick()
        {
            CloseView();
            //ViewManager.Instance.SetView(ViewNames.MainMenuScreen);
        }

        private void OnSound()
        {
            if (_audioSource.volume == 0)
            {
                _audioSource.volume = 1;
            }
            else
            {
                _audioSource.volume = 0;
            }
            
        }
    }
}