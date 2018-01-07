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
        private Image _logo;

        [SerializeField]
        private Image _bg;

        protected override void Start()
        {
            base.Start();
            ScheduleUpdate(2, false);

            _logo.DOFade(1, 1);
            _bg.DOFade(1, 1);
            
            _logo.transform.DOScale(1, 1);
        }

        protected override void OnScheduledUpdate()
        {
            base.OnScheduledUpdate();
            ViewManager.Instance.SetView(ViewNames.MainMenuScreen);
        }
    }
}
