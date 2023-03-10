using System;
using UnityEngine;

namespace Scripts.PlayerPacages
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Trigger _trigger;

        private bool _isAttacks =false;

        public bool IsAttacks => _isAttacks;

        private void OnEnable()
        {
            _trigger.OnFire += Fire;
            _trigger.OnStopAttack += StopAttac;
        }

        private void OnDisable()
        {
            _trigger.OnFire -= Fire;
            _trigger.OnStopAttack -= StopAttac;
        }

        private void Fire()
        {
            _isAttacks = true;
        }

        private void StopAttac()
        {
            _isAttacks = false;
        }
    }
}