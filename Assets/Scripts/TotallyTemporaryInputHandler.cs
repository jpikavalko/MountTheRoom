using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotallyTemporaryInputHandler : MonoBehaviour
{
    public Transform characterPart;
    private Rigidbody characterRig;

    public Transform explosionVector;
    
    public float explosionForce = 10f;

    private void Awake()
    {
        characterRig = characterPart.GetComponent<Rigidbody>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("h");
            characterRig.AddForce((explosionVector.position.normalized) * explosionForce);
        }
    }
}
