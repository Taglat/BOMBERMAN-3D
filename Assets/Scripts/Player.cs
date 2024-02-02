using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private bool canMove = true;
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InputAction moveAction;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");    
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (!canMove) return;
        // Debug.Log(moveAction.ReadValue<Vector2>());
        
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * Time.deltaTime * moveSpeed;
    }
}
