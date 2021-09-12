using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public float moveSpeed = 10;
    [SerializeField] GameObject touchPadPanel, followCam;
    private Animator hero;
    private float width, height, x1, y1, x2, y2, timer, r1 = 0, r2 = 0;
    private int touchPadId, freeLookId;
    private Rigidbody heroBody;

    private Vector2 touchStart, touchEnd;
    [SerializeField] Button move;

    [SerializeField] ParticleSystem sword, shield;
    private Transform movePos;
    private RectTransform touchPadPanelRect;
    // Start is called before the first frame update
    void Start()
    {
        heroBody = this.GetComponent<Rigidbody>();
        width = ((float)Screen.width) / 2;
        height = ((float)Screen.height) / 2;
        movePos = move.transform;
        touchPadPanelRect = touchPadPanel.GetComponent<RectTransform>();
        hero = this.GetComponent<Animator>();
        this.transform.SetPositionAndRotation(new Vector3(PlayerPrefs.GetFloat("heroPosX", 237.00f), PlayerPrefs.GetFloat("heroPosy", 1.12f), PlayerPrefs.GetFloat("heroPosz", 283.4f)),
                                         new Quaternion(PlayerPrefs.GetFloat("heroRotX", 0), PlayerPrefs.GetFloat("heroRotY", 157.0f), PlayerPrefs.GetFloat("heroRotZ", 0), 0));

    }


    private Touch touch;
    public bool attackBool = false, moveBool = false, rotateCamBool = false, restartCamRotation;
    // Update is called once per frame
    void Update()
    {



        if (Input.touchCount > 0) for (int i = 0; i < Input.touchCount; i++)
            {
                touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {
                    touchStart = touch.position;
                    if (touch.position.x <= (width / 4) && touch.position.y < (height / 2))
                    {
                        movePos.position = touch.position;
                        moveBool = true;
                        touchPadId = touch.fingerId;

                    }
                    /*else if (touch.position.y >= height && touch.position.x > width / 2)
                    {
                        rotateCamBool = true;
                        freeLookId = touch.fingerId;
                    }*/
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    touchEnd = touch.position;
                    if (touchPadId == touch.fingerId)
                    {
                        x1 = (touchEnd.x - touchStart.x) / (width / 8);
                        y1 = (touchEnd.y - touchStart.y) / (height / 4);
                        if (touchEnd.x < touchPadPanelRect.rect.xMax * 2 && touchEnd.x > touchPadPanelRect.rect.xMin * 2 && touchEnd.y > touchPadPanelRect.rect.yMin * 2 && touchEnd.y < touchPadPanelRect.rect.yMax * 2)
                            movePos.position = touchEnd;
                    }
                    /*else if (freeLookId == touch.fingerId)
                    {
                        if (touch.phase == TouchPhase.Stationary)
                        {
                            x2 = 0;
                            y2 = 0;
                            touchStart = touchEnd;
                        }
                        else
                        {
                        x2 = touchEnd.x - touchStart.x;
                        y2 = touchEnd.y - touchStart.y;

                    }*/
                }
                else if (touch.phase == TouchPhase.Stationary)
                {

                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    if (touchPadId == touch.fingerId)
                    {
                        movePos.position = touchPadPanel.transform.position;
                        x1 = 0;
                        y1 = 0;
                        moveBool = false;
                    }
                    /*else if (freeLookId == touch.fingerId)
                    {
                        rotateCamBool = false;
                        x2 = 0;
                        y2 = 0;
                        restartCamRotation = true;
                    }*/
                }
            }
        if (x1 > 1) x1 = 1; else if (x1 < -1) x1 = -1;
        if (y1 > 1) y1 = 1; else if (y1 < -1) y1 = -1;
        if (x2 > 1) x2 = 1; else if (x2 < -1) x2 = -1;
        if (y2 > 1) y2 = 1; else if (y2 < -1) y2 = -1;
#if UNITY_EDITOR
        y1 = Input.GetAxis("Vertical");
        x1 = Input.GetAxis("Horizontal");
#endif



        heroBody.MovePosition(transform.position + transform.forward * y1 * Time.deltaTime * moveSpeed);
        heroBody.rotation *= Quaternion.AngleAxis(x1 * Time.deltaTime * 50, Vector3.up);


        /*if (Input.GetKey(KeyCode.E)) r1 = 1; else r1 = 0;
        if (Input.GetKey(KeyCode.A)) r2 = 1; else r2 = 0;
        followCam.transform.rotation *= Quaternion.AngleAxis(x2 * 50 * Time.deltaTime, Vector3.up);
        followCam.transform.rotation *= Quaternion.AngleAxis(y2 * 50 * Time.deltaTime, Vector3.right);*/
        //followCam.transform.rotation *= Quaternion.AngleAxis(r2 * 50 * Time.deltaTime, Vector3.down);
        //if (!rotateCamBool) followCam.transform.rotation = transform.rotation;
        //transform.Translate(0, 0, y1 * Time.deltaTime * 10);
        //transform.Rotate(0, x1 * Time.deltaTime * 100, 0);

        HeroWalk(y1);


        timer += Time.deltaTime;
        if (timer > 10)
        {
            timer = 3; attackBool = false;
        }
    }
    private void HeroWalk(float a)
    {
        if (a != 0)                             //this method here will pass parameter to the animation component when needed
            hero.SetBool("walk", true);
        else hero.SetBool("walk", false);
    }
    public void BackToMainMenu()
    {
        
        PlayerPrefs.SetFloat("heroPosX", transform.position.x);
        PlayerPrefs.SetFloat("heroPosy", transform.position.y);
        PlayerPrefs.SetFloat("heroPosz", transform.position.z);
        PlayerPrefs.SetFloat("heroRotX", transform.rotation.x);
        PlayerPrefs.SetFloat("heroRotY", transform.rotation.y);
        PlayerPrefs.SetFloat("heroRotZ", transform.rotation.z);
        SceneManager.LoadScene("MenuScene");
    }
    public void Attack()
    {
        if (timer > 2)
        {
            hero.Play("arthur_attack");                 //this method here will pass parameter of attacking to the animation component  
            sword.Play();
            shield.Play();                              // these sword and shield are particles that are played on the moment of attacking.particle is a VFX
            attackBool = true;
            timer = 0;
        }
    }
}
