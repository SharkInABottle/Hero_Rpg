using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject cam;
    private Animator hero;
    // Start is called before the first frame update
    void Start()
    {
        hero=this.GetComponent<Animator>();
    }
    private float x1,y1,z1;
    // Update is called once per frame
    void Update()
    {   //this for testing input, don't mind it.
        x1=Input.GetAxis("Horizontal")*Time.deltaTime*2;
        y1 = Input.GetAxis("Vertical")* Time.deltaTime*5;
        z1 = 0;
        if (x1 > 0 || y1 > 0|| x1 < 0 || y1 < 0)
        { 
            transform.Translate(0, z1, y1);
            transform.Rotate(0, x1 * Time.deltaTime*5000, 0);
            hero.SetBool("walk", true);
            cam.transform.position=transform.position + new Vector3(0, 3, -6);
            cam.transform.rotation = transform.rotation;
            
        }else hero.SetBool("walk", false);
        //end test.

    }
}
