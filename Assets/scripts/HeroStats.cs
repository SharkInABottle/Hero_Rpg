using UnityEngine;
using UnityEngine.UI;

public class HeroStats : MonoBehaviour
{
    // Start is called before the first frame update
    public Text hp, hpStats, xp, level, nameHero, attackPower, attackSpeed, Movespeed, Scoins, shards;
    public Image hpBar, xpBar, heroStatsView;
    public static bool collided = false;
    [SerializeField] Button helmet, chest, gloves, cape, pants, weapon, shield, boots;
    public int maxHp { get; set; }
    public int experiencePoints { get; set; }
    public int levelExp { get; set; }
    public int currentHp { get; set; }
    public int attackPow { get; set; }
    public int currentLevel { get; set; }
    public int silver { get; set; }
    public int lifeShard { get; set; }


    void Start()
    {
        nameHero.text = "Name : <color=green>" + UI.Hero + "</color>";
        maxHp = PlayerPrefs.GetInt("maxHp", 100);
        currentHp = maxHp;
        hpStats.text = "hp : <color=green>" + currentHp + "/" + maxHp + "</color>";
        currentLevel = PlayerPrefs.GetInt("level", 1);
        level.text = "Level : <color=green>" + currentLevel + "</color>";
        experiencePoints = PlayerPrefs.GetInt("experience", 1);
        attackPow = PlayerPrefs.GetInt("attackPower", 10);
        attackPower.text = "attackPower: <color=green>" + attackPow + "</color>";
        hp.text = (currentHp / maxHp) * 100 + "%";
        xp.text = "lvl: " + currentLevel;
        
        hpBar.fillAmount = currentHp / maxHp;

        silver = PlayerPrefs.GetInt("silverCoins", 0);
        lifeShard = PlayerPrefs.GetInt("lifeshards", 0);
        UpdateSilverShardUi(silver, lifeShard, experiencePoints);
    }
    void Update()
    {
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name != "Terrain") collided = true;


    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name != "Terrain")
        {
            collided = false;
        }
    }
    public void herostatsviewOn()
    {
        if (heroStatsView.gameObject.activeSelf)
        {
            heroStatsView.gameObject.SetActive(false);
        }
        else
        {
            heroStatsView.gameObject.SetActive(true);
        }
    }
    public void ReceiveDmg(int x)
    {
        currentHp -= x;
        hpStats.text = "hp : <color=green>" + currentHp + "/" + maxHp + "</color>";
        hpBar.fillAmount = ((float)currentHp) / maxHp;
        hp.text = hpBar.fillAmount * 100 + "%";
    }
    public void Rewards(int x, int y, int z)
    {
        experiencePoints += z;
        silver += x;
        lifeShard += y;
        currentLevel = 1 + (experiencePoints / 1000);
        PlayerPrefs.SetInt("silverCoins", silver);
        PlayerPrefs.SetInt("lifeshards", lifeShard);
        PlayerPrefs.SetInt("experience", experiencePoints);
        PlayerPrefs.SetInt("level", currentLevel);
        xp.text = "lvl: " + currentLevel;
        UpdateSilverShardUi(silver, lifeShard, experiencePoints);

    }
    private void UpdateSilverShardUi(int x, int y, int z)
    {
        Scoins.text = x.ToString();
        shards.text = y.ToString();
        xpBar.fillAmount = ((float)(z % 1000)) / 1000;


    }

}
