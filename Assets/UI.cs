using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Button start, options, back, quit, choose, quitConfirm, back2;
    [SerializeField] Image quitConf;
    [SerializeField] Camera mainCam;
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
            mainCam.transform.Translate(new Vector3(0, -0.5f, 2f));
        }else if (!startGameBo && mainCam.transform.position.y < 8)
        {
            mainCam.transform.Translate(new Vector3(0, 0.5f, -2f));
        }
    }
    public void StartGame()
    {
        options.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        choose.gameObject.SetActive(true);
        startGameBo = true;
        //Debug.Log("is the boolen true?" + startGameBo.ToString());
    }
    public void QuitGame()
    {
        quitConf.gameObject.SetActive(true);
    }
    public void QuitGameFinal()
    {
        Application.Quit();
    }
    public void CancelQuitGame()
    {
        quitConf.gameObject.SetActive(false);
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
    }

}
