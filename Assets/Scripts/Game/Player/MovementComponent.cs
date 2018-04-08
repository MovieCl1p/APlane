using UnityEngine;

namespace Game.Player
{
    public class MovementComponent
    {
        private Transform _player;
        private Camera _camera;
        
        public MovementComponent(Transform player, Camera camera)
        {
            _player = player;
            _camera = camera;
        }
        
        public void MovePlayer(float velocity, float deltaTime)
        {
            _player.Translate(Vector3.up * (velocity * deltaTime));
        }

        public void RotatePlayer()
        {
            Vector3 playerViewport = RectTransformUtility.WorldToScreenPoint(_camera, _player.position);
            
            var offset = new Vector2(Input.mousePosition.x - playerViewport.x, Input.mousePosition.y - playerViewport.y);
            var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            _player.rotation = Quaternion.Euler(0, 0, angle);
        }

        public void Rotate(float _rotateVelocity, float deltaTime)
        {
            Vector3 playerViewport = RectTransformUtility.WorldToScreenPoint(_camera, _player.position);

            //Vector3 playerViewport = _camera.WorldToScreenPoint(Input.mousePosition);

            var offset = new Vector2(Input.mousePosition.x - playerViewport.x, Input.mousePosition.y - playerViewport.y);
            var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            //_player.rotation = Quaternion.Euler(0, 0, angle);

            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            _player.rotation = Quaternion.RotateTowards(_player.rotation, targetRotation, _rotateVelocity * deltaTime);
        }

        public void Reset()
        {

        }
    }
}
