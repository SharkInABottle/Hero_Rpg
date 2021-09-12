using UnityEngine;
using UnityEngine.UI;

public class itemStats : MonoBehaviour
{

    
    [SerializeField] GameObject inventoryContent;
    [SerializeField] Text empty;
    public Button item;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (this.gameObject.activeSelf)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    public void ItemStatsOff()
    {

        this.gameObject.SetActive(false);

    }
    
    public void DestroyItem()
    {
        Destroy(item.gameObject);
        if (inventoryContent.transform.childCount == 1) empty.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        
        
    }
}
