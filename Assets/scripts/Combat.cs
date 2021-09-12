using UnityEngine;
public class Combat : MonoBehaviour
{
    public GameObject hero;
    public float moveSpeed = 10, attackSpeed = 2, timer = 0, deadTime = 0;
    public int attackDmg = 5, maxHp = 10, rewardCoin = 100, rewardShard = 1000,xpReward=100; 
    private int currentHp;
    public GameObject hpBar3d;

    private bool initPosClose = true, dead = false;
    private Vector3 InitPos { get; set; }
    private Quaternion InitRotation { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        InitPos = transform.position;
        InitRotation = transform.rotation;
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10) timer = 5;
        if (Vector3.Distance(transform.position, InitPos) > 40) initPosClose = false;
        if (dead)
        {
            deadTime += Time.deltaTime;
            if (deadTime > 20)
            {
                this.gameObject.SetActive(false);
                this.transform.position = InitPos;
                this.GetComponent<Animator>().ResetTrigger("Up");
                this.GetComponent<Animator>().SetTrigger("Up");

            }
        }
        else if (Vector3.Distance(transform.position, hero.transform.position) < 20 && Vector3.Distance(transform.position, hero.transform.position) > 4 && initPosClose)
        {

            this.GetComponent<Rigidbody>().MovePosition(transform.position + (hero.transform.position - transform.position).normalized * Time.deltaTime * moveSpeed);
            transform.LookAt(hero.transform);
            this.GetComponent<Animator>().SetFloat("speedh", 1);
            this.GetComponent<Animator>().SetFloat("speedv", 1);



        }
        else if (!initPosClose)
        {


            this.GetComponent<Rigidbody>().MovePosition(transform.position + (InitPos - transform.position).normalized * Time.deltaTime * moveSpeed);
            transform.LookAt(InitPos);
            this.GetComponent<Animator>().SetFloat("speedh", 1);
            this.GetComponent<Animator>().SetFloat("speedv", 1);
            ;
            if (Vector3.Distance(transform.position, InitPos) < 1)
            {
                this.GetComponent<Animator>().SetFloat("speedh", 0);
                this.GetComponent<Animator>().SetFloat("speedv", 0);

                transform.rotation = InitRotation;

                initPosClose = true;
            }
        }
        else if (Vector3.Distance(transform.position, hero.transform.position) <= 4)
        {
            this.GetComponent<Animator>().SetFloat("speedh", 0);
            this.GetComponent<Animator>().SetFloat("speedv", 0);

            transform.LookAt(hero.transform);
            if (timer > attackSpeed)
            {
                Attacking();
                timer = 0;
            }
            else if (hero.GetComponent<PlayerInput>().attackBool)
            {
                ReceiveDmg(hero.GetComponent<HeroStats>().attackPow);

            }
        }
    }
    private void Attacking()
    {

        hero.GetComponent<HeroStats>().ReceiveDmg(attackDmg);
        this.GetComponent<Animator>().ResetTrigger("attack");
        this.GetComponent<Animator>().SetTrigger("attack");



    }
    private void ReceiveDmg(int x)
    {
        currentHp -= x;
        hero.GetComponent<PlayerInput>().attackBool = false;

        if (currentHp <= 0)
        {
            hpBar3d.transform.localScale = Vector3.zero;
            this.GetComponent<Animator>().SetTrigger("Fall1");
            if (!dead) dead = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<BoxCollider>().enabled = false;
            hero.GetComponent<HeroStats>().Rewards(rewardCoin, rewardShard,xpReward);
        }
        else
        {
            hpBar3d.transform.localScale = new Vector3((float)currentHp / (float)maxHp * 5, hpBar3d.transform.localScale.y, hpBar3d.transform.localScale.z);
            this.GetComponent<Animator>().ResetTrigger("Hit1");
            this.GetComponent<Animator>().SetTrigger("Hit1");
        }

    }
}
