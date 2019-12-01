using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCylinderHandler : MonoBehaviour
{
    Rigidbody _rig;

    private void Awake()
    {
        _rig = GetComponent<Rigidbody>();
    }

    public void RoomSpinning()
    {
        if (_rig.isKinematic)
        {
            _rig.isKinematic = false;
        }
        else
        {
            _rig.isKinematic = true;
        }
    }

    public void RoomSpinning(bool b)
    {
        _rig.isKinematic = b;
    }
}
