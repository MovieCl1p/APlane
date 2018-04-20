using Core;
using Core.Binder;
using Core.Dispatcher;
using Game.Player.Control;
using Game.Services.Interfaces;
using UnityEngine;

namespace Game.Player
{
    public class PlayerController : MonoScheduledBehaviour
    {
        private Camera _camera;

        [SerializeField]
        private float _moveVelocity = 40;
        
        [SerializeField]
        private SpriteRenderer _shipSprite;

        private IDispatcher _dispatcher;
        private IShipSpriteLoaderService _spriteLoader;
        private IPlayerControl _control;
        private MovementComponent _move;

        protected override void Awake()
        {
            base.Awake();
            
            _dispatcher = BindManager.GetInstance<IDispatcher>();
            _spriteLoader = BindManager.GetInstance<IShipSpriteLoaderService>();
            _control = BindManager.GetInstance<IPlayerControl>();
            _control.OnTouch += OnTouch;

            UpdateSprite();
        }

        public void SetCamera(Camera playerCamera)
        {
            _move = new MovementComponent(CachedTransform, playerCamera);
        }
        
        protected override void Update()
        {
            base.Update();

            if (_move != null)
            {
                _move.MovePlayer(_moveVelocity, Time.deltaTime);
            }
        }

        private void OnTouch(Vector2 mousePosition)
        {
            if (_move != null)
            {
                _move.Rotate(Time.deltaTime);
            }
        }

        protected override void OnReleaseResources()
        {
            _control.OnTouch -= OnTouch;
            base.OnReleaseResources();
        }

        private void UpdateSprite()
        {
            IUserProfileService userProfileService = BindManager.GetInstance<IUserProfileService>();
            string spriteId = userProfileService.GetProfileModel().CurrentSpriteId;
            
            Texture2D texture = _spriteLoader.GetSprite(spriteId);
            _shipSprite.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }
}
