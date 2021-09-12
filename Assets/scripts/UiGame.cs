using UnityEngine;
using UnityEngine.UI;

public class UiGame : MonoBehaviour
{
    public Image equip, inventory, menu, itemStats;
    public GameObject inventoryContent, soundI, supportI;
    public Text empty;
    public Slider musicVolume;
    public Toggle musicOn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!itemStats.gameObject.activeSelf)
            {
                if (equip.gameObject.activeSelf || inventory.gameObject.activeSelf || menu.gameObject.activeSelf)
                {
                    equip.gameObject.SetActive(false);
                    inventory.gameObject.SetActive(false);
                    menu.gameObject.SetActive(false);

                }

            }
        }
    }
    public void EquipUi()
    {
        if (equip.gameObject.activeSelf)
        {
            equip.gameObject.SetActive(false);
        }
        else equip.gameObject.SetActive(true);
    }
    public void inventoryUi()
    {
        if (inventory.gameObject.activeSelf)
        {
            inventory.gameObject.SetActive(false);
            itemStats.gameObject.SetActive(false);
        }
        else
        {


            inventory.gameObject.SetActive(true);
            if (inventoryContent.transform.childCount > 0) empty.gameObject.SetActive(false);
            else empty.gameObject.SetActive(true);
        }
    }
    public void MenuUi()
    {
        if (menu.gameObject.activeSelf)
        {
            menu.gameObject.SetActive(false);
        }
        else
        {
            menu.gameObject.SetActive(true);
            OptionsSound();
        }
    }
    public void ItemStatsOn()
    {
        itemStats.gameObject.SetActive(true);
    }
    public void OptionsSupport()
    {
        soundI.SetActive(false);
        supportI.SetActive(true);
    }
    public void OptionsSound()
    {
        soundI.SetActive(true);
        supportI.SetActive(false);
    }
    public void SoundVolume()
    {
        PlayerPrefs.SetFloat("SoundVolume", musicVolume.value);
    }
    public void MusicOn()
    {
        if (musicOn.enabled)
            PlayerPrefs.SetInt("musicOn", 1);
        else PlayerPrefs.SetInt("musicOn", 0);
    }


}
