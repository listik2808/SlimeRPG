using Scripts.PlayerPacages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.EnemyPacages
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField][Min(1)] private int _countEnemy;
        [SerializeField] private Transform _container;
        [SerializeField] private Enemy _enemy;

        private List<Enemy> _enemies = new List<Enemy>();

        Coroutine coroutineEnemy;

        private void Start()
        {
            coroutineEnemy = StartCoroutine(Instantoate());
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                player.SetEnemy(_enemies);
            }
        }

        private IEnumerator Instantoate()
        {
            while(_countEnemy != 0)
            {
                var randomX = UnityEngine.Random.Range(transform.position.x, transform.position.x + 3);
                var randomZ = UnityEngine.Random.Range(transform.position.z, transform.position.z + 3);

                var pointx = randomX;
                var pointz = randomZ;

                _container.transform.position = new Vector3(randomX,_container.transform.position.y,randomZ);

                Enemy prefab = Instantiate(_enemy, _container.transform.position, Quaternion.identity);
                _enemies.Add(prefab);
                _countEnemy--;
                yield return null;
            }
        }
    }
}