using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<IPlayerController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerController.SelectObject();
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            _playerController.MoveSoldier();
        }
    }
}