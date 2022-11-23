using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerMode
{
    NONE,
    PLAYERMODE_CUBE,
    PLAYERMODE_AIRPLANE,
    PLAYERMODE_SPIDER,
    PLAYERMODE_HUMAN,
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
    private Dictionary<PlayerMode, PlayerMovement_Base> _playerMovementTypeDictionary = new Dictionary<PlayerMode, PlayerMovement_Base>();
    public Dictionary<PlayerMode, PlayerMovement_Base> PLAYERMOVEMENTTYPEDICTIONARY => _playerMovementTypeDictionary;
    [SerializeField] private PlayerMode _currentPlayerMode = PlayerMode.NONE;


    private  void Awake() => Init();
    public void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _customGravity = GetComponent<CustomGravity>();
        _cameraController = Camera.main.GetComponent<CameraController>();

        SetPlayerMovementDictionary();

        TransMode();
    }

    public void SetPlayerMovementDictionary()
    {
        _playerMovementTypeDictionary.Clear();

        _playerMovementTypeDictionary.Add(PlayerMode.PLAYERMODE_CUBE, transform.Find("Player_Cube").GetComponent<PlayerMovement_Cube>());
        _playerMovementTypeDictionary.Add(PlayerMode.PLAYERMODE_AIRPLANE, transform.Find("Player_Airplane").GetComponent<PlayerMovement_Airplane>());

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
