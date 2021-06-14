using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


 

public class UI : MonoBehaviour
{
    public static string Hero { get; set; }
    [SerializeField] Button start, options, back, quit, choose, quitConfirm, back2, maleHero;
    [SerializeField] Image quitConf,optionMenu;
    [SerializeField] Camera mainCam,secondCam;
    
    private bool startGameBo;
    private Transform posCamStart;
    // Start is called before the first frame update
    void Start()
    {
        
        startGameBo = false;
        posCamStart = mainCam.transform;


    }
    private float temp;
    // Update is called once per frame
    void Update()
    {
        /*temp += Time.deltaTime;
        if (temp > 4)
        {
            Debug.Log("condition" + startGameBo.ToString());
            temp = 0;
        }*/
        
        if (startGameBo && mainCam.transform.position.y > 3)
        {
            mainCam.transform.Translate(new Vector3(0, -0.025f, 0.1f));
        }else if (!startGameBo && mainCam.transform.position.y < 8)
        {
            mainCam.transform.Translate(new Vector3(0, 0.025f, -0.1f));
        }
        if (Input.GetKeyDown("escape"))
        {
            QuitGame();
        }

    }
    public void StartGame()
    {
        
        options.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        choose.gameObject.SetActive(true);
        maleHero.gameObject.SetActive(true);
        startGameBo = true;
        mainCam.GetComponent<PhysicsRaycaster>().enabled = true;
        //Debug.Log("is the boolen true?" + startGameBo.ToString());
    }
    public void QuitGame()
    {
        quitConf.gameObject.SetActive(true);
        optionMenu.gameObject.SetActive(false);
    }
    public void QuitGameFinal()
    {
        Application.Quit();
    }
    public void CancelQuitGame()
    {
        quitConf.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(false);
    }
    public void BackToMainMenu()
    {
        mainCam.transform.SetPositionAndRotation(posCamStart.position, posCamStart.rotation);
        startGameBo = false;
        start.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        back.gameObject.SetActive(false);
        choose.gameObject.SetActive(false);
        maleHero.gameObject.SetActive(false);
        mainCam.GetComponent<PhysicsRaycaster>().enabled = false;
    }
    public void ChooseConfirmMale()
    {
        //SceneManager.LoadScene("MainScene");
        Hero = "male";

        //test1.text += "hello  " + Event.current;
        SceneManager.LoadScene("MainScene");
    }
    public void ChooseConfirmFemale()
    {
        //SceneManager.LoadScene("MainScene");
        Hero = "Female";
        Debug.Log("hero chosen is " + Hero);
    }
    public void Options()
    {
        optionMenu.gameObject.SetActive(true);
    }
    public void OnGUI()
    {
        //test1.text +=  Event.current;
    }

}
