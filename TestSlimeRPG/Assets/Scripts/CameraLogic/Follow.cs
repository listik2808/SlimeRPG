using Scripts.PlayerPacages;
using UnityEngine;

namespace Scripts.CameraLogic
{
    public class Follow : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _offSetX;

        private void LateUpdate()
        {
            transform.position = new Vector3(PositionX(), transform.position.y, transform.position.z);
        }

        private float PositionX()
        {
            return _player.transform.position.x - _offSetX;
        }
    }
}