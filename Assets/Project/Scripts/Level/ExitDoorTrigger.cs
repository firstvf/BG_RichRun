using Assets.Project.Scripts.Player;
using UnityEngine;

namespace Assets.Project.Scripts.Level
{
    public class ExitDoorTrigger : MonoBehaviour
    {
        private Animation _animation;
        [SerializeField] private int _exitDoorNumber;

        private void Awake()
        {
            _animation = GetComponent<Animation>();
        }

        private void OnTriggerEnter(Collider collide)
        {
            if (collide.TryGetComponent(out PlayerController player))
            {
                _animation.Play();

                switch (_exitDoorNumber)
                {
                    case 1:
                        SoundController.Instance.PlaySound(SoundTypes.First_Exit);
                        break;

                    case 2:
                        SoundController.Instance.PlaySound(SoundTypes.Second_Exit);
                        break;

                    case 3:
                        SoundController.Instance.PlaySound(SoundTypes.Third_Exit);
                        break;
                }
            }
        }
    }
}