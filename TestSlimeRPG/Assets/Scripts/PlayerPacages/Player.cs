using Scripts.EnemyPacages;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.PlayerPacages
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private Sphere _sphere;

        private List<Enemy> _enemys;
        private Enemy _enemy;
        private bool _isAttack = false;

        public Enemy Enemy => _enemy;
        public bool IsAttack => _isAttack;

        private void OnEnable()
        {
            _sphere.RemoveEvent += RemoveDead;
        }

        private void OnDisable()
        {
            _sphere.RemoveEvent -= RemoveDead;
        }

        public void Attack() =>
           _isAttack = true;

        public void StopaAttack() =>
            _isAttack = false;

        public void SetEnemy(List<Enemy> enemys)
        {
            _enemys = enemys;
            ActivateEnemy();
            TryGetEnemy();
        }

        private void SelectedEnemy(List<Enemy> enemy)
        {
            _enemys = enemy;

            if (_enemys.Count == 0)
                StopaAttack();
            else
                TryGetEnemy();
        }

        private void ActivateEnemy()
        {
            foreach (Enemy enemy in _enemys)
            {
                if(enemy.IsActiv == false)
                {
                    enemy.Selected();
                }
            }
        }

        private void TryGetEnemy()
        {
            foreach (var enemy in _enemys)
            {
                if (enemy.IsDead == false)
                {
                    _enemy = enemy;
                    Attack();
                    break;
                }
            }
        }

        private void RemoveDead()
        {
            List<Enemy> newEnemy = new List<Enemy>();

            foreach (var enemy in _enemys)
            {
                if (enemy.IsDead == false)
                {
                    newEnemy.Add(enemy);
                }
            }
            _enemys.Clear();
            SelectedEnemy(newEnemy);
        }
    }
}