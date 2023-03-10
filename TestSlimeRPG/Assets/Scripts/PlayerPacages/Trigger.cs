using Scripts.EnemyPacages;
using System;
using UnityEngine;

namespace Scripts.PlayerPacages
{
    public class Trigger : MonoBehaviour
    {
        public event Action OnFire;
        public event Action OnStopAttack;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                OnFire?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                OnStopAttack?.Invoke();
            }
        }
    }
}