using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UnitMovement : MonoBehaviour
{
    enum UnitState
    {
        Idle,
        Move
    }
    
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private ScriptableObject _unitCoonfig;
    [SerializeField] private UnitSelectionManager _unitSelectionManager;
    [SerializeField] private float _force = 5f;
    
    private Vector3 target;
    private Rigidbody2D _rigidbody;
    private UnitState currentState;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
        target = transform.position;
        currentState = UnitState.Idle;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && _unitSelectionManager.selectedUnits.Count>0)
        {
            target = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            currentState = UnitState.Move;
        }
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case UnitState.Move:
                Move(target);
                break;
        }
    }

    private void Move(Vector3 targetPosition)
    {
        if ((targetPosition - transform.position).magnitude > 0.1f)
        {
            Vector2 direction = (targetPosition - transform.position).normalized;
            _rigidbody.MovePosition(_rigidbody.position + direction * _force * Time.deltaTime);
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
            ChangeState(UnitState.Idle);
        }
    }

    void ChangeState(UnitState newState)
    {
        currentState = newState;
    }
}
