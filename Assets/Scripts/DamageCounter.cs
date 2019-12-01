using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCounter : MonoBehaviour
{

    Dictionary<Player, float> _playerTotalDamage = new Dictionary<Player, float>();
    public TMPro.TMP_Text _oswaldDamage;
    public TMPro.TMP_Text _topDMGtext;
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

                if (item.Key._playerName == "Oswald") _oswaldDamage.text = ((int)item.Value).ToString();
            }

            _dmgTaken = false;
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
            _topDMGtext.text = Mathf.RoundToInt(_topDMG).ToString();
        }
        
        if (_playerTotalDamage != null)
        {
            _playerTotalDamage[p] += dmg;
            _dmgTaken = true;
        }
        
    }
}
