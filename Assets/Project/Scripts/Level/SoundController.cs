using UnityEngine;

namespace Assets.Project.Scripts.Level
{
    public enum SoundTypes
    {
        Unknown = 0,
        Money = 1,
        Bottle = 2,
        Checkpoint = 3,
        StatusUp = 4,
        First_Exit = 5,
        Second_Exit = 6,
        Third_Exit = 7,
        Win = 8,
        Step = 9,
    }

    public class SoundController : MonoBehaviour
    {
        public static SoundController Instance;

        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _money, _bottle, _checkpoint, _statusUp, _firstExit, _secondExit, _thirdExit, _win;

        [SerializeField] private AudioClip[] _stepSounds;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            if (Instance == null)
            {
                Instance = this;
                return;
            }

            Destroy(gameObject);
        }

        public void PlaySound(SoundTypes sound)
        {
            switch (sound)
            {
                case SoundTypes.Money:
                    _audioSource.PlayOneShot(_money);
                    break;
                case SoundTypes.Bottle:
                    _audioSource.PlayOneShot(_bottle);
                    break;
                case SoundTypes.Checkpoint:
                    _audioSource.PlayOneShot(_checkpoint);
                    break;
                case SoundTypes.StatusUp:
                    _audioSource.PlayOneShot(_statusUp);
                    break;
                case SoundTypes.First_Exit:
                    _audioSource.PlayOneShot(_firstExit);
                    break;
                case SoundTypes.Second_Exit:
                    _audioSource.PlayOneShot(_secondExit);
                    break;
                case SoundTypes.Third_Exit:
                    _audioSource.PlayOneShot(_thirdExit);
                    break;
                case SoundTypes.Win:
                    _audioSource.PlayOneShot(_win,0.2f);
                    break;
                case SoundTypes.Step:
                    _audioSource.PlayOneShot(_stepSounds[Random.Range(0,_stepSounds.Length)],0.15f);
                    break;
            }
        }
    }
}