using Scripts.EnemyPacages;
using System;
using UnityEngine;

namespace Scripts.PlayerPacages
{
    public class Sphere : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private int _damage;
        [SerializeField][Min(1)] private float _speed;

        private bool _isMove = false;

        public event Action RemoveEvent;

        private void Update()
        {
            if (_player.IsAttack)
            {
                _isMove = true;
                if(_player.Enemy.IsDead == false)
                    transform.position = Vector3.MoveTowards(transform.position, _player.Enemy.transform.position, _speed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
                ResetPosition();
            }
        }

        private void ResetPosition()
        {
            _isMove = false;
            transform.position = transform.parent.position;
            RemoveEvent?.Invoke();
        }
    }
}