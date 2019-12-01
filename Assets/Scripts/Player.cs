using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody[] _playerRigidbodies;
    public string _playerName;

    private void Awake()
    {
        _playerRigidbodies = transform.GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < _playerRigidbodies.Length; i++)
        {
            _playerRigidbodies[i].gameObject.AddComponent<RigidbodyDamage>().SetupRigidbodyDamage(this);
        }
    }

    private void Start()
    {
        DamageCounter.instance.AddPlayer(this);
    }
}
