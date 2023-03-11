using System;
using UnityEngine;

namespace Scripts.EnemyPacages
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;

        private BoxCollider _boxCollider;
        private MeshRenderer _meshRenderer;
        private bool _isActiv = false;
        private bool _isdead = false;
        public int Health => _health;
        public bool IsActiv => _isActiv;
        public bool IsDead => _isdead;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _boxCollider = GetComponent<BoxCollider>();
        }

        public void TakeDamage(int damage)
        {
            if(_health - damage <= 0)
            {
                _health = 0;
                _isActiv = false;
                _isdead = true;
                _meshRenderer.enabled = false;
                _boxCollider.enabled = false;
            }

            _health -= damage;
        }

        public void Selected()
        {
            _isActiv = true;
        }

        public void Deselect()
        {
            _isActiv = false;
        }
    }
}