using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostTrigger : MonoBehaviour
{
public enum BoostDirection { right, left, up }
    public BoostDirection _boostDirection;

    [Range(1, 10)]
    public int _forceMultiplier;


    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            Debug.Log(other.name.ToString());
            switch (_boostDirection)
            {
                case BoostDirection.right:
                    other.attachedRigidbody.AddForce(Vector3.right * _forceMultiplier * 500);
                    break;
                case BoostDirection.left:
                    other.attachedRigidbody.AddForce(Vector3.left * _forceMultiplier * 500);
                    break;
                case BoostDirection.up:
                    other.attachedRigidbody.AddForce(Vector3.up * _forceMultiplier * 1000);
                    break;
                default:
                    break;
            }
        }
    }
}
