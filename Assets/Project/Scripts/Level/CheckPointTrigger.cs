using Assets.Project.Scripts.Enum;
using Assets.Project.Scripts.Player;
using UnityEngine;

namespace Assets.Project.Scripts.Level
{
    public class CheckPointTrigger : MonoBehaviour
    {
        private Animation _animation;

        private void Awake()
        {
            _animation = GetComponent<Animation>();
        }

        private void OnTriggerEnter(Collider collide)
        {
            if (collide.TryGetComponent(out PlayerController player))
            {
                _animation.Play();
                SoundController.Instance.PlaySound(SoundTypes.Checkpoint);
            }
        }
    }
}