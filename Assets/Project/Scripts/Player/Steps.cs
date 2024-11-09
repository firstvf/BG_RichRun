using Assets.Project.Scripts.Level;
using UnityEngine;

namespace Assets.Project.Scripts.Player
{
    public class Steps :MonoBehaviour
    {
        public void StepSound()
        => SoundController.Instance.PlaySound(SoundTypes.Step);
    }
}