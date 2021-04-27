using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Button start, options, back, quit, choose, quitConfirm, back2;
    [SerializeField] Image quitConf;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {

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

}
