using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class UI : MonoBehaviour
{
    public static string Hero { get; set; }
    public static bool gender { get; set; }

    [SerializeField] Button start, options, back, quit, choose, quitConfirm, back2, maleHero, backName, saveName,femaleHero;
    [SerializeField] Image quitConf, optionMenu, namePanel,errorPanel;
    [SerializeField] Camera mainCam, secondCam;
    public Text heroNameInput,errorMsg;

    private bool startGameBo;
    private Transform posCamStart;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicQ", 2));
        startGameBo = false;
        posCamStart = mainCam.transform;
        
    }
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
        }
        else if (!startGameBo && mainCam.transform.position.y < 8)
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

        if (PlayerPrefs.GetInt("heroNameCheck", 0) == 0)
        {
            namePanel.gameObject.SetActive(true);
            
        }
        else
        {
            options.gameObject.SetActive(false);
            optionMenu.gameObject.SetActive(false);
            start.gameObject.SetActive(false);
            quit.gameObject.SetActive(false);
            back.gameObject.SetActive(true);
            choose.gameObject.SetActive(true);
            maleHero.gameObject.SetActive(true);
            femaleHero.gameObject.SetActive(true);
            startGameBo = true;
            mainCam.GetComponent<PhysicsRaycaster>().enabled = true;
        }

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
        femaleHero.gameObject.SetActive(false);
        mainCam.GetComponent<PhysicsRaycaster>().enabled = false;
        namePanel.gameObject.SetActive(false);
    }
    public void ChooseConfirmMale()
    {
        gender = false;
        SceneManager.LoadScene("GameScene");
    }
    public void ChooseConfirmFemale()
    {
        gender = true;
        SceneManager.LoadScene("GameScene");
    }
    public void Options()
    {
        optionMenu.gameObject.SetActive(true);
    }
    public void SaveName()
    {
        if (heroNameInput.text == "" || heroNameInput.text.Length > 12)
        {
            ErrorMsg("Sorry, Please type your name that doesn't exceed <b>12 characters</b>");
        }
        else
        {
            PlayerPrefs.SetInt("heroNameCheck", 1);
            Hero = heroNameInput.text;
            namePanel.gameObject.SetActive(false);
            StartGame();
        }
    }
    public void ErrorMsgOk()
    {
        errorPanel.gameObject.SetActive(false);
    }
    public void ErrorMsg(string x)
    {
        errorPanel.gameObject.SetActive(true);
        errorMsg.text = x;
    }

}
