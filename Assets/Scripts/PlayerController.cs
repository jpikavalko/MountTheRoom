using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target;

    public Rigidbody leftHand,
                     rightHand,
                     torso;

    private Hand    left, right;

    public float    pullForce,
                    jumpForce;

    private float   leftHorizontal,
                    rightHorizontal,
                    leftVertical,
                    rightVertical;

    private bool    isJumpPressed,
                    isLeftGrabbing,
                    isRightGrabbing;

    Camera          main;


    void Start()
    {
        main = Camera.main;
        InvokeRepeating("LousyExuceOfATimer", 1f, 0.1f);

        left = leftHand.transform.GetComponentInChildren<Hand>();
        right = rightHand.transform.GetComponentInChildren<Hand>();
    }

    void Update()
    {
        leftHorizontal  = Input.GetAxis("LeftHorizontal");
        rightHorizontal = Input.GetAxis("RightHorizontal");
        leftVertical    = Input.GetAxis("LeftVertical");
        rightVertical   = Input.GetAxis("RightVertical");

        isJumpPressed   = Input.GetButton("Jump");
        isLeftGrabbing  = Input.GetButton("LeftGrab");
        isRightGrabbing = Input.GetButton("RightGrab");
    }

    int a = 15;
    private void LousyExuceOfATimer()
    {
        a++;
    }

    private void FixedUpdate()
    {
        MoveHand(rightHand, new Vector3(rightHorizontal, -rightVertical, 0));
        MoveHand(leftHand, new Vector3(rightHorizontal, -rightVertical, 0));
        MoveTorso();

        if (isJumpPressed && a >= 20)
        {
            Jump();
            isJumpPressed = false;
            a = 0;
        }

        if (isLeftGrabbing) GrabObject(left);
        if (isRightGrabbing) GrabObject(right);   
    }

    private void GrabObject(Hand hand)
    {
        GameObject carryItem = hand.GetItemInHand();

        if (carryItem != null)
        {
            carryItem.GetComponent<Collider>().enabled = false;
            carryItem.transform.position = hand.transform.position;
            carryItem.transform.rotation = hand.transform.rotation;
        }
    }

    private void MoveHand(Rigidbody hand, Vector3 direction)
    {
        // Debug shows the vector of hands
        Debug.DrawRay(hand.position, direction * 4f, Color.magenta);

        direction = main.transform.TransformDirection(direction);
        hand.AddForce(direction * pullForce);
    }

    private void MoveTorso()
    {
        // Debug shows direction of vector (not the same as torso.addforce thingy)
        Debug.DrawRay(torso.position, new Vector3(leftHorizontal, -leftVertical, 0f) * 4f, Color.red);
        Debug.DrawRay(torso.position, new Vector3(leftHorizontal, -leftVertical, 0f), Color.green);

        torso.AddForce(-Vector3.forward * leftVertical * 300f);
        torso.AddForce(main.transform.TransformDirection(new Vector3(leftHorizontal, 0f, 0f) * 50f));
    }

    private void Jump()
    {
        Vector3 direction = (target.position - torso.position).normalized;
        torso.AddForce(direction * jumpForce);
        
    }
}
