using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target;

    public Rigidbody leftHand,
                     rightHand,
                     torso;



    public float pullForce,
                 jumpForce;

    private float leftHorizontal,
                  rightHorizontal,
                  leftVertical,
                  rightVertical;

    private bool isJumpPressed;


    void Start()
    {
        InvokeRepeating("LousyExuceOfATimer", 1f, 0.1f);
    }

    void Update()
    {
        leftHorizontal = Input.GetAxis("LeftHorizontal");
        rightHorizontal = Input.GetAxis("RightHorizontal");
        leftVertical = Input.GetAxis("LeftVertical");
        rightVertical = Input.GetAxis("RightVertical");

        isJumpPressed = Input.GetButton("Jump");
        
        if (isJumpPressed && a >= 20) 
        {
            Debug.Log("hump");
            Jump();
            isJumpPressed = false;
            a = 0;
        }
    }
    int a = 15;
    private void LousyExuceOfATimer()
    {
        a++;
    }

    private void FixedUpdate()
    {
        MoveHand(leftHand, new Vector3(leftHorizontal, -leftVertical, 0));
        MoveHand(rightHand, new Vector3(rightHorizontal, -rightVertical, 0));

        Debug.DrawLine(target.position, torso.position, Color.green);
    }

    private void MoveHand(Rigidbody hand, Vector3 direction)
    {
        hand.AddForce(direction * pullForce);
    }

    private void Jump()
    {
        Vector3 direction = (target.position - torso.position);
        torso.AddForce(direction * jumpForce);
        
    }
}
