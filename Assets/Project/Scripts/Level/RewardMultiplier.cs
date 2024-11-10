using UnityEngine;

namespace Assets.Project.Scripts.Level
{
    public class RewardMultiplier : MonoBehaviour
    {
        [SerializeField] private int _multiply;

        public int GetMultiply() => _multiply;
    }
}