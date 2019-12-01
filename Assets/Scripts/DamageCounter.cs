using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCounter : MonoBehaviour
{

    Dictionary<Player, float> _playerTotalDamage = new Dictionary<Player, float>();
    public static DamageCounter instance = null;
    bool _dmgTaken = false;
    float _topDMG = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if (_dmgTaken)
        {
            string _dmgText = "";

            foreach (KeyValuePair<Player, float> item in _playerTotalDamage)
            {
                _dmgText += item.Key._playerName + " damage taken: " + item.Value;
            }
            Debug.Log(_dmgText);
        }    
    }


    public void AddPlayer(Player p)
    {
        _playerTotalDamage.Add(p, 1f);
    }


    public void TakeDamage(Player p, float dmg)
    {
        
        if (dmg > _topDMG)
        {
            _topDMG = dmg;
            //Debug.Log("Top Damage!! " + _topDMG);
        }
        
        if (_playerTotalDamage != null)
        {
            _playerTotalDamage[p] += dmg;
            _dmgTaken = true;
        }
        
    }
}
