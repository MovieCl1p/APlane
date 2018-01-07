using Core.ViewManager;
using DG.Tweening;
using Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.Splash
{
    public class SplashView : BaseView
    {
        [SerializeField]
        private Transform _logo;

        protected override void Start()
        {
            base.Start();
            ScheduleUpdate(3, false);

            var tween = _logo.DOScale(1, 1);
            
            
            _logo.DOShakePosition(2, 2, 20, 90, true);
        }

        protected override void OnScheduledUpdate()
        {
            base.OnScheduledUpdate();
            ViewManager.Instance.SetView(ViewNames.MainMenuScreen);
        }
    }
}
