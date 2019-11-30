using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyDamage : MonoBehaviour
{
    Player _parentPlayer;

    public void SetupRigidbodyDamage(Player p)
    {
        _parentPlayer = p;
    }


    private void OnCollisionEnter(Collision collision)
    {
        float dmg = collision.impulse.magnitude;

        if(collision.impulse.magnitude >= 100f)
        {
            Debug.Log(transform.name + " Damage: " + dmg);

            DamageCounter.instance.TakeDamage(_parentPlayer, dmg);
        }

    }
}
