using UnityEngine;

namespace Scripts.PlayerPacages
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _speed;

        private void Update()
        {
            if (_player.IsAttacks)
            {
                return;
            }
            else
            {
                transform.position += Vector3.right * _speed * Time.deltaTime;
            }
        }
    }
}