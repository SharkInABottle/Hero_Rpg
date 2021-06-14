using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponStats : MonoBehaviour
{
    [SerializeField] Image itemStats;
    [SerializeField] Text  atck;
    [SerializeField] int attackPower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ItemStatsOn()
    {
        itemStats.gameObject.SetActive(true);
        atck.text = "+" + attackPower.ToString();
    }
}
