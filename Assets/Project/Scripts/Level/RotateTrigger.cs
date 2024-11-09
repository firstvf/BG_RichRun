using Assets.Project.Scripts.Enum;
using Assets.Project.Scripts.Player;
using UnityEngine;

namespace Assets.Project.Scripts.Level
{
    public class RotateTrigger : MonoBehaviour
    {
        [SerializeField] private RotateSideType _sideType;

        private void OnTriggerEnter(Collider collide)
        {
            if (collide.TryGetComponent(out PlayerController player))
            {
                player.RotateParent(_sideType);
                gameObject.SetActive(false);
            }
        }
    }
}