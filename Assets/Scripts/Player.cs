using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private bool canMove = true;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameInput gameInput;
    // [SerializeField] private int countBombs = 1;

    private bool isWalking;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Player instance!");
        }
        Instance = this;
    }
    private void Start()
    {
        gameInput.OnPlantAction += GameInput_OnPlantAction;
    }
    private void Update()
    {
        HandleMovement();
    }

    private void GameInput_OnPlantAction(object sender, System.EventArgs e)
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit raycastHit))
        {
            if (raycastHit.transform.TryGetComponent(out FloorBlock floorBlock))
            {
                floorBlock.Plant();
            }
        }
    }
    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        if (canMove)
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
