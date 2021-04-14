using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Animator hero;
    // Start is called before the first frame update
    void Start()
    {
        hero=player.GetComponent<Animator>();
    }
    private float x1,y1,z1;
    // Update is called once per frame
    void Update()
    {
        x1=Input.GetAxis("Horizontal")*Time.deltaTime*2;
        y1 = Input.GetAxis("Vertical")* Time.deltaTime*5;
        z1 = 0;
        if (x1 > 0 || y1 > 0|| x1 < 0 || y1 < 0)
        { 
            transform.Translate(0, z1, y1);
            transform.Rotate(0, x1 * Time.deltaTime*1000, 0);
            hero.SetBool("walk", true);
            
        }else hero.SetBool("walk", false);


    }
}
