using Assets.Project.Scripts.Enum;
using Assets.Project.Scripts.Level;
using System.Collections;
using UnityEngine;

namespace Assets.Project.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _statusTypes;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private GameObject _model;
        private bool _isAbleInput => GameController.Instance.IsAbleInput;
        private Animator _animator;
        private int IS_MOVEMENT = Animator.StringToHash("isWalk");
        private int SPIN = Animator.StringToHash("Spin");
        private int WIN = Animator.StringToHash("Dance");

        private RotateSideType _rotateSide = RotateSideType.Right;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            GameController.Instance.OnStatusTypeRefreshHandler += CheckStatusType;
        }

        private void Update()
        {
            if (!_isAbleInput)
                return;

            PlayerMovement();
            _animator.SetBool(IS_MOVEMENT, true);
        }

        public void WinState()
        => _animator.SetTrigger(WIN);

        private void PlayerMovement()
        {
            var horizontal = Input.GetAxis("Horizontal");

            if (_rotateSide == RotateSideType.Right)
                transform.position += new Vector3(horizontal * _speed * 2.5f, transform.position.y, 1 * _speed) * Time.deltaTime;
            else if (_rotateSide == RotateSideType.Left)
                transform.position += new Vector3(1 * _speed, transform.position.y, -horizontal * _speed * 2.5f) * Time.deltaTime;

            Rotation(horizontal);
        }

        private void Rotation(float horizontal)
        {
            float multiplyRotation = 0;

            if (_rotateSide == RotateSideType.Left)
                multiplyRotation = 90;

            if (horizontal < 0)
                _model.transform.rotation = Quaternion.Euler(_model.transform.rotation.x, _model.transform.rotation.y - 45 + multiplyRotation, _model.transform.rotation.z);
            else if (horizontal > 0)
                _model.transform.rotation = Quaternion.Euler(_model.transform.rotation.x, _model.transform.rotation.y + 45 + multiplyRotation, _model.transform.rotation.z);
            else
                _model.transform.rotation = Quaternion.Euler(_model.transform.rotation.x, _model.transform.rotation.y + multiplyRotation, _model.transform.rotation.z);
        }

        public void RotateParent(RotateSideType side)
        {
            _rotateSide = side;

            StartCoroutine(RotateParentCoroutine(side));
        }

        private IEnumerator RotateParentCoroutine(RotateSideType side)
        {
            int count = 0;

            switch (side)
            {
                case RotateSideType.Left:
                    while (count <= 90)
                    {
                        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + count, transform.rotation.z);
                        count += 5;
                        yield return null;
                    }
                    break;

                case RotateSideType.Right:
                    count = 90;
                    while (count >= 0)
                    {
                        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + count, transform.rotation.z);
                        count -= 5;
                        yield return null;
                    }
                    break;
            }
        }

        private void CheckStatusType(StatusType status)
        {
            foreach (var item in _statusTypes)
                item.SetActive(false);

            _animator.SetTrigger(SPIN);

            switch (status)
            {
                case StatusType.Poor:
                    _statusTypes[0].SetActive(true);
                    break;
                case StatusType.Wealthy:
                    _statusTypes[1].SetActive(true);
                    break;
                case StatusType.Rich:
                    _statusTypes[2].SetActive(true);
                    break;
            }
        }

        private void OnDestroy()
        {
            GameController.Instance.OnStatusTypeRefreshHandler -= CheckStatusType;
        }
    }
}