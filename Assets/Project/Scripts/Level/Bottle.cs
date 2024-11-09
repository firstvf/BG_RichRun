using Assets.Project.Scripts.Player;
using UnityEngine;

namespace Assets.Project.Scripts.Level
{
    public class Bottle : MonoBehaviour
    {
        [SerializeField] private int _currency = 20;

        private void OnTriggerEnter(Collider collide)
        {
            if (collide.TryGetComponent(out PlayerController player))
            {
                GameController.Instance.RemoveMoney(_currency);
                SoundController.Instance.PlaySound(SoundTypes.Bottle);
            }

            Destroy(gameObject);
        }
    }
}