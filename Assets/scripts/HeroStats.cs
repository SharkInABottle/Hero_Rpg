using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool collided=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {   if(collision.collider.name!="Terrain") collided = true;
        
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name != "Terrain")
        {
            collided = false;
            //transform.position = new Vector3(0,0,0);
        }
    }
}
