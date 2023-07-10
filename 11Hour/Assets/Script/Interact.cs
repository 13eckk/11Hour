using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public List<GameObject> interactable;
    public int interactNum;
    public GameObject E;
    public Canvas _canvas;
    public bool canrotate;
    public bool Hasinteract = false;
    public bool Caninteract = false;
    [SerializeField] private string Textsss;
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float leftLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float rightLookLimit = 80.0f;
    private float rotationX = 0;
    private float rotationY = 0;
    public static Interact Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        E = GetComponent<GameObject>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {

        if (Caninteract)
        {
            rotationX -= Input.GetAxis("Mouse X") * lookSpeedY;
            rotationY -= Input.GetAxis("Mouse Y") * lookSpeedX;
            rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
            rotationY = Mathf.Clamp(rotationY, -leftLookLimit, rightLookLimit);
            E.transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);
        }
        
        //this.transform.localRotation = Quaternion.Euler(rotationY,0 , 0);
        //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }
    public void createObj()
    {
        
            E = Instantiate(interactable[interactNum], new Vector3(100f, 1, 100f), Quaternion.identity);
            rotationX = 0;
            rotationY = 0;
            _canvas.gameObject.SetActive(true);
            
            Hasinteract = true;
            
            Time.timeScale = 0;


    }
    public void DestroyObj()
    {
        Destroy(E);
        _canvas.gameObject.SetActive(false);
        Hasinteract = false;
        Cursor.visible = false;
        Time.timeScale = 1;
    }


    }
