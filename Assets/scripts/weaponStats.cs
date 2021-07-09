using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponStats : MonoBehaviour
{
    
    private Text  atck;
    [SerializeField] int attackPower;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ItemStats()
    {

        GameObject.Find("Canvas").GetComponent<UiGame>().ItemStatsOn();
        GameObject.Find("itemStats").GetComponent<itemStats>().item = this.GetComponent<Button>();
        atck = GameObject.Find("attackPower").GetComponent<Text>();
        
        atck.text = "+" + attackPower.ToString();
    }
}
