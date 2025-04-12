using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;


public class Player_Controller : MonoBehaviour
{
    public TMP_Text scText;
    public TMP_Text scTextLose;
    public TMP_Text scWinText;
    public Rigidbody rb;
    public Transform touchCheck;
    public GameObject pinl;
    public GameObject WinPn;
    public GameObject LosePn;

    public float moveDistance = 1f;
    public float moveSpeed = 3f;
    public float moveDelay = 0.2f;
    public float touchPoin;

    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool moveL, moveR, moveU, moveD;
    private bool isTouching;
    private bool isRight = true ;
    private float score;
    private float number;
    public bool isLose = false;
    public bool isWin = false;
    public Audio_Manager Audio;

    public LayerMask whatLayer;

   
    void Start()
    {
        Audio = FindObjectOfType<Audio_Manager>();
        number = float.Parse(scWinText.text);
        targetPosition = transform.position;
    }
    void Update()
    {

        CheckMove();
    }
    void FixedUpdate()
    {
        if (rb.position == targetPosition)
        {
            isMoving = false;
        }

        if (!isMoving)
        {
            if (moveL && !IsTouchingWall(Vector3.left))
            {
                StartMove(Vector3.left);
            }
            else if (moveR && !IsTouchingWall(Vector3.right))
            {
                StartMove(Vector3.right);
            }
            else if (moveU && !IsTouchingWall(Vector3.up))
            {
                StartMove(Vector3.up);
            }
            else if (moveD && !IsTouchingWall(Vector3.down))
            {
                StartMove(Vector3.down);
            }
        }
        rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            isLose = true;
            scTextLose.text = score.ToString();
            LosePn.SetActive(true);
        }
    }

    public void Flip()
    {
        isRight = !isRight;
        transform.Rotate(0, 180, 0);
    }

    public void CheckMove()
    {
        if (isRight && moveL)
        {
            Flip();

        }
        else if (!isRight && moveR)
        {
            Flip();
        }
    }

    void StartMove(Vector3 direction)
    {
        if (!isMoving)
        {
            targetPosition += direction * moveDistance;
            isMoving = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Pin"))
        {
            score++;
        }
        scText.text = score.ToString()+"/";
        if(score == number)
        {
            isWin = true;
            WinPn.SetActive(true);
        }
    }


    // Xử lý input từ button
    public void BottonDownLeft() { moveL = true; Audio.moveSound(); }
    public void BottonUpLeft() { moveL = false;}
    public void BottonDownRight() { moveR = true; Audio.moveSound(); }
    public void BottonUpRight() { moveR = false;}
    public void BottonDownUP() { moveU = true; Audio.moveSound();}
    public void BottonUpU() { moveU = false;}
    public void BottonDownD() { moveD = true; Audio.moveSound(); }
    public void BottonUpDown() { moveD = false;}

    private bool IsTouchingWall(Vector3 direction)
    {
        return Physics.CheckSphere(touchCheck.position + direction * moveDistance, touchPoin, whatLayer);
    }
}
