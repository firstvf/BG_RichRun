using Assets.Project.Scripts.Player;
using UnityEngine;

namespace Assets.Project.Scripts.Level
{
    public class DoorTrigger :MonoBehaviour
    {
        private void OnTriggerEnter(Collider collide)
        {
            if (collide.TryGetComponent(out PlayerController player))
            {
                GameController.Instance.AddMoney(20);
            }
        }
    }
}