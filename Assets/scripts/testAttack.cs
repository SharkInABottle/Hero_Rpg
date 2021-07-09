using System.Collections;
using UnityEngine;

public class testAttack : MonoBehaviour
{
    public GameObject heroTest;
    public float moveSpeed = 10,attackSpeed=2,timer=0;
    public int attackDmg=5;
    
    private bool initPosClose = true;
    private Vector3 initPos { get; set; }
    private Quaternion initRotation { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        initRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10) timer = 5;
        if (Vector3.Distance(transform.position, initPos) > 40) initPosClose = false;
        if (Vector3.Distance(transform.position, heroTest.transform.position) < 20 && Vector3.Distance(transform.position, heroTest.transform.position) > 4 && initPosClose)
        {
            
            this.GetComponent<Rigidbody>().MovePosition(transform.position + (heroTest.transform.position - transform.position).normalized * Time.deltaTime * moveSpeed);
            transform.LookAt(heroTest.transform);
            this.GetComponent<Animator>().SetFloat("speedh", 1);
            this.GetComponent<Animator>().SetFloat("speedv", 1);
            


        }
        else if (!initPosClose)
        {

            
            this.GetComponent<Rigidbody>().MovePosition(transform.position + (initPos - transform.position).normalized * Time.deltaTime * moveSpeed);
            transform.LookAt(initPos);
            this.GetComponent<Animator>().SetFloat("speedh", 1);
            this.GetComponent<Animator>().SetFloat("speedv", 1);
            ;
            if (Vector3.Distance(transform.position,initPos) <1 )
            {
                this.GetComponent<Animator>().SetFloat("speedh", 0);
                this.GetComponent<Animator>().SetFloat("speedv", 0);
                
                transform.rotation = initRotation;
                Debug.Log(initPosClose + "should be false");
                initPosClose = true;
            }
        }
        else if (Vector3.Distance(transform.position, heroTest.transform.position) <= 4)
        {
            this.GetComponent<Animator>().SetFloat("speedh", 0);
            this.GetComponent<Animator>().SetFloat("speedv", 0);
            
            transform.LookAt(heroTest.transform);
            if (timer > attackSpeed)
            {
                Attacking();
                timer = 0;
            }


        }
    }
    private void Attacking()
    {

        heroTest.GetComponent<HeroStats>().ReceiveDmg(attackDmg);
        this.GetComponent<Animator>().ResetTrigger("attack");
        this.GetComponent<Animator>().SetTrigger("attack");
        
            
        
    }
}
