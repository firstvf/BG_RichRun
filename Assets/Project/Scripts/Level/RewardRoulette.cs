using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Scripts.Level
{
    public class RewardRoulette : MonoBehaviour
    {
        [SerializeField] private int _multiplier;
        [SerializeField] private Text _rewardMultiplyText, _multiplyCount, _defaultReward, _currencyText;

        private void Start()
        {
            _defaultReward.text = GameController.Instance.GetMoney().ToString();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out RewardMultiplier rewardMultiplier))
                ChangeTexts(rewardMultiplier);
        }

        private void ChangeTexts(RewardMultiplier rewardMultiplier)
        {
            _multiplier = rewardMultiplier.GetMultiply();
            _rewardMultiplyText.text = (GameController.Instance.GetMoney() * _multiplier).ToString();
            _multiplyCount.text = "X" + _multiplier.ToString();
        }

        public void GetReward()
        {
            //SceneController.Instance.LoadNextScene(SceneType.Game2);
            StartCoroutine(CollectMoneyCoroutine());
        }

        private IEnumerator CollectMoneyCoroutine()
        {
            int count = 0;
            while (count < GameController.Instance.GetMoney())
            {
                count++;
                _currencyText.text = count.ToString();
                yield return null;
            }

            yield return new WaitForSeconds(2f);
            SceneController.Instance.LoadNextScene(SceneType.Game2);
        }
    }
}