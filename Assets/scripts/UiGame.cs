using UnityEngine;
using UnityEngine.UI;

public class UiGame : MonoBehaviour
{
    [SerializeField] Image equip, inventory, menu, itemStats;
    [SerializeField] GameObject inventoryContent;
    [SerializeField] Text empty;
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
        else menu.gameObject.SetActive(true);
    }
}
