using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Project.Scripts.Level
{
    public enum SceneType
    {
        Game = 0,
        Game2 = 1,
    }

    public class SceneController : MonoBehaviour
    {
        public static SceneController Instance { get; private set; }

        [SerializeField] private Text _levelText;
        private SceneType _sceneType;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }

            Destroy(gameObject);
        }

        private void Start()
        {
            _levelText.text = Convert.ToInt32(_sceneType).ToString();
        }

        public void LoadNextScene(SceneType sceneType)
        {
            _sceneType = sceneType;
            SceneManager.LoadSceneAsync(_sceneType.ToString());
        }
    }
}