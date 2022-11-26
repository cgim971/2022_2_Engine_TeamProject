using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerMode
{
    NONE,
    PLAYERMODE_CUBE,
    PLAYERMODE_UFO,
    PLAYERMODE_AIRPLANE,
    PLAYERMODE_SPIDER,
    PLAYERMODE_ROBOT,
    END
}

[RequireComponent(typeof(CustomGravity))]
public class PlayerController : MonoBehaviour
{
    #region Caching
    private Rigidbody _rigidbody = null;
    public Rigidbody RIGIDBODY { get => _rigidbody; set => _rigidbody = value; }
    private CustomGravity _customGravity = null;
    public CustomGravity CUSTOMGRAVITY { get => _customGravity; set => _customGravity = value; }
    private CameraController _cameraController = null;
    public CameraController CAMERACONTROLLER { get => _cameraController; set => _cameraController = value; }
    #endregion

    [SerializeField] private PlayerMode _currentPlayerMode = PlayerMode.NONE;

    private Dictionary<PlayerMode, PlayerMovement_Base> _playerMovementTypeDictionary = new Dictionary<PlayerMode, PlayerMovement_Base>();


    public StageSO stage;

    private void Awake() => Init();
    public void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _customGravity = GetComponent<CustomGravity>();
        _cameraController = Camera.main.GetComponent<CameraController>();

        SetPlayerMovementDictionary();
        TransMode();

        SetStage();
    }

    public void SetStage()
    {
        GameManager.Instance.CURRENTSTAGE = stage;
        transform.position = GameManager.Instance.CURRENTSTAGE._stageStartPosition;
        _customGravity.SetGravity(GameManager.Instance.CURRENTSTAGE._stageGravity);
    }

    public void SetPlayerMovementDictionary()
    {
        _playerMovementTypeDictionary.Clear();

        _playerMovementTypeDictionary.Add(PlayerMode.PLAYERMODE_CUBE, transform.Find("Player_Cube").GetComponent<PlayerMovement_Cube>());
        _playerMovementTypeDictionary.Add(PlayerMode.PLAYERMODE_UFO, transform.Find("Player_UFO").GetComponent<PlayerMovement_UFO>());
        _playerMovementTypeDictionary.Add(PlayerMode.PLAYERMODE_AIRPLANE, transform.Find("Player_Airplane").GetComponent<PlayerMovement_Airplane>());
        _playerMovementTypeDictionary.Add(PlayerMode.PLAYERMODE_ROBOT, transform.Find("Player_Robot").GetComponent<PlayerMovement_Robot>());

        foreach (PlayerMode playerMode in _playerMovementTypeDictionary.Keys)
        {
            _playerMovementTypeDictionary[playerMode].gameObject.SetActive(false);
        }
    }

    public void TransMode(PlayerMode mode = PlayerMode.NONE)
    {
        if (mode != PlayerMode.NONE)
        {
            _playerMovementTypeDictionary[_currentPlayerMode].gameObject.SetActive(false);
            _currentPlayerMode = mode;
        }
        if (_currentPlayerMode != PlayerMode.NONE)
        {
            _playerMovementTypeDictionary[_currentPlayerMode].gameObject.SetActive(true);
            _playerMovementTypeDictionary[_currentPlayerMode].UseInit();
        }
    }
}
