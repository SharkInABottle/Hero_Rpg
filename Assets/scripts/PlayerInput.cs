using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] GameObject cam, touchPadPanel;
    private Animator hero;
    private float width, height;
    [SerializeField] GameObject heroF, heroM;
    [SerializeField] Button move, attack;
    public Text test1;
    [SerializeField] ParticleSystem sword, shield;
    private Transform movePos, camPos, camPosInit;
    private RectTransform touchPadPanelRect;
    // Start is called before the first frame update
    void Start()
    {
        width = (float)Screen.width / 2;
        height = (float)Screen.height / 2;
        movePos = move.transform;
        touchPadPanelRect = touchPadPanel.GetComponent<RectTransform>();
        hero = this.GetComponent<Animator>();
        camPos = camPosInit = cam.transform;
    }
    private float x1, y1, x2, y2, timer;
    private Vector2 touchStart, touchEnd;

    private bool attackBool = false, moveBool = false, rotateCamBool = false, restartCamRotation;
    // Update is called once per frame
    void Update()
    {   //this for testing input, don't mind it.

        /*x1 = Input.GetAxis("Horizontal") * Time.deltaTime;
        y1 = Input.GetAxis("Vertical") * Time.deltaTime * 10;*/


        x1 = 0;
        y1 = 0;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
                if (touch.position.x <= width / 2 && touch.position.y < height)
                {
                    movePos.position = touch.position;
                    moveBool = true;
                }
                else if (touch.position.y >= height) rotateCamBool = true;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {

                touchEnd = touch.position;

                if (moveBool)
                {
                    x1 = (touchEnd.x - touchStart.x) / (width / 8);
                    y1 = (touchEnd.y - touchStart.y) / (height / 4);
                    if (touchEnd.x < touchPadPanelRect.rect.xMax * 2 && touchEnd.x > touchPadPanelRect.rect.xMin * 2 && touchEnd.y > touchPadPanelRect.rect.yMin * 2 && touchEnd.y < touchPadPanelRect.rect.yMax * 2) movePos.position = touchEnd;
                }
                else if (rotateCamBool)
                {

                    if (touch.phase == TouchPhase.Stationary)
                    {
                        x2 = 0;
                        touchStart = touchEnd;
                    }
                    else x2 = touchEnd.x - touchStart.x;
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (moveBool)
                {
                    movePos.position = touchPadPanel.transform.position;
                    x1 = 0;
                    y1 = 0;
                    moveBool = false;
                }
                else if (rotateCamBool)
                {
                    rotateCamBool = false;
                    x2 = 0;
                    y2 = 0;
                    restartCamRotation = true;
                }
            }
        }
        if (x1 > 1) x1 = 1; else if (x1 < -1) x1 = -1;
        if (y1 > 1) y1 = 1; else if (y1 < -1) y1 = -1;
        if (x2 > 1) x2 = 1; else if (x2 < -1) x2 = -1;
        transform.Translate(0, 0, y1 * Time.deltaTime * 10);
        transform.Rotate(0, x1 * Time.deltaTime * 100, 0);
        camPos.RotateAround(transform.position, Vector3.up, 200 * Time.deltaTime * x2);
        HeroWalk(y1);
        if (restartCamRotation)
        {
            if (camPos.position != camPosInit.position)
            {
                camPos.RotateAround(transform.position, Vector3.up, 200 * Time.deltaTime);
            }
            else restartCamRotation = false;
        }

        timer += Time.deltaTime;
        if (timer > 10) timer = 3;

    }
    private void HeroWalk(float a)
    {
        if (a != 0)
            hero.SetBool("walk", true);
        else hero.SetBool("walk", false);
    }
    private void MovePad()
    {

    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void Attack()
    {
        if (timer > 2)
        {
            hero.Play("arthur_attack");
            sword.Play();
            shield.Play();
            attackBool = true;
            timer = 0;
        }
        else attackBool = false;

    }
}
