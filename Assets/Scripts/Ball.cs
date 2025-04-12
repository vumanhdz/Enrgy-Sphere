using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float moveDistance = 1f;
    public float moveSpeed = 5f;
    public float checkDistance = 1f;
    public float checkDistance_45 = 1f;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool isBlockedLeft;
    private bool isBlockedRight;
    private bool isBlocked45;
    private bool isBlocked_45;


    private bool isFalling = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isFalling)
        {
            StartCoroutine(FallStep());
        }

    }

    IEnumerator FallStep()
    {
        isFalling = true;

        isGrounded = Physics.Raycast(transform.position, Vector3.down, checkDistance, groundLayer);
        isBlockedLeft = Physics.Raycast(transform.position, Vector3.left, checkDistance, groundLayer);
        isBlockedRight = Physics.Raycast(transform.position, Vector3.right, checkDistance, groundLayer);
        isBlocked45 = Physics.Raycast(transform.position, Quaternion.AngleAxis(45, Vector3.forward) * Vector3.left, checkDistance_45, groundLayer);
        isBlocked_45 = Physics.Raycast(transform.position, Quaternion.AngleAxis(135, Vector3.forward) * Vector3.left, checkDistance_45, groundLayer);

        Vector3 moveDirection = Vector3.zero;
     
        if (!isGrounded)
        {
            moveDirection = Vector3.down;
        }
        else if (!isBlockedLeft && !isBlocked45 && isGrounded)
        {
            moveDirection = new Vector3(-1, 0, 0).normalized;
        }
        else if (!isBlockedRight && !isBlocked_45)
        {
            moveDirection = new Vector3(1, 0, 0).normalized;
        }

        Vector3 targetPosition = transform.position + moveDirection * moveDistance;

        float elapsedTime = 0;
        Vector3 startPosition = transform.position;

        while (elapsedTime < 1f / moveSpeed)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime * moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isFalling = false;
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * checkDistance);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * checkDistance);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * checkDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(45, Vector3.forward) * Vector3.left * checkDistance_45);// Kiểm tra phải
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(135, Vector3.forward) * Vector3.left * checkDistance_45);
    }
}
