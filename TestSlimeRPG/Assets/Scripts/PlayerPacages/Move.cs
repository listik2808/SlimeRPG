using System;
using UnityEngine;

namespace Scripts.PlayerPacages
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private float _speed;
       
        private Player _player;
        
        public event Action Attack;

        private void Start() 
        {
            _player = GetComponent<Player>();
        }

        private void Update()
        {
            if (_player.IsAttack == false)
                transform.position += Vector3.right * _speed * Time.deltaTime;
        }
    }
}