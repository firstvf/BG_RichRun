using Assets.Project.Scripts.Player;
using UnityEngine;

namespace Assets.Project.Scripts.Level
{
    public class Exit : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collide)
        {
            if (collide.TryGetComponent(out PlayerController player))
            {
                SoundController.Instance.PlaySound(SoundTypes.Win);
                player.WinState();
            }
        }
    }
}