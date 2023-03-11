using Scripts.EnemyPacages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.PlayerPacages
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float _cooldown;

        private float _delay = 0;
    }
}