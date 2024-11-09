using Assets.Project.Scripts.Player;
using UnityEngine;

namespace Assets.Project.Scripts.Level
{
    public class Money : MonoBehaviour
    {
        [SerializeField] private int _currency = 1;

        private void OnTriggerEnter(Collider collide)
        {
            if (collide.TryGetComponent(out PlayerController player))
            {
                GameController.Instance.AddMoney(_currency);
                SoundController.Instance.PlaySound(SoundTypes.Money);
            }

            Destroy(gameObject);
        }
    }
}