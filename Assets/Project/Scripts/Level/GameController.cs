using Assets.Project.Scripts.Enum;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Scripts.Level
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        [SerializeField] private TMP_Text _addMoney, _removeMoney;
        [SerializeField] private int _money = 40;
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _status;
        [SerializeField] private Image _sliderFillImage;
        [SerializeField] private Color32 _orange;
        [SerializeField] private GameObject _ui;
        [SerializeField] private Text _pointsText;
        [SerializeField] private GameObject _winUI;
        private StatusType _statusType;

        public Action<StatusType> OnStatusTypeRefreshHandler { get; set; }
        public bool IsAbleInput { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }

            Destroy(gameObject);
        }

        private void Start()
        {
            _slider.maxValue = 100;
            _slider.value = _money;
            _statusType = StatusType.Poor;

            _pointsText.text = _money.ToString();
        }

        public void AcceptGuide()
        {
            IsAbleInput = true;
            _ui.SetActive(false);
        }

        public void TurnOffInput() => IsAbleInput = false;

        public void SetWinUI()
        {
            _winUI.SetActive(true);
            _pointsText.gameObject.SetActive(false);
        }

        public int GetMoney() => _money;

        public void AddMoney(int money)
        {
            _money += money;

            _addMoney.gameObject.SetActive(false);
            _addMoney.gameObject.SetActive(true);
            _addMoney.text = $"+ {money} $";

            UpdateStatus();
        }

        public void RemoveMoney(int money)
        {
            _money -= money;

            _removeMoney.gameObject.SetActive(false);
            _removeMoney.gameObject.SetActive(true);
            _removeMoney.text = $"- {money} $";

            UpdateStatus();
        }

        private void UpdateStatus()
        {
            _slider.value = _money;

            _pointsText.text = _money.ToString();

            if (_money >= 60)
                SetStatus(Color.green, "БОГАТЫЙ", StatusType.Rich);

            else if (_money >= 40)
                SetStatus(Color.yellow, "СОСТОЯТЕЛЬНЫЙ", StatusType.Wealthy);

            else if (_money >= 20)
                SetStatus(_orange, "БЕДНЫЙ", StatusType.Poor);
        }

        private void SetStatus(Color color, string name, StatusType statusType)
        {
            if (_statusType == statusType)
                return;

            SoundController.Instance.PlaySound(SoundTypes.StatusUp);

            _statusType = statusType;
            _status.color = color;
            _status.text = name;
            _sliderFillImage.color = color;

            OnStatusTypeRefreshHandler?.Invoke(statusType);
        }
    }
}