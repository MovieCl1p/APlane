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
            _player.Translate(Vector3.right * (velocity * deltaTime));
        }

        public void Rotate(float deltaTime)
        {
            Vector3 playerViewport = _camera.WorldToScreenPoint(_player.position);
            var offset = new Vector2(Input.mousePosition.x - playerViewport.x, Input.mousePosition.y - playerViewport.y);
            var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            _player.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
