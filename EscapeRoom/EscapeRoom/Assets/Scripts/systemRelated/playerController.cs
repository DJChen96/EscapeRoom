using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class playerController : MonoBehaviour
{

    public Hand right;
    public Hand left;

    public float Speed = 5f;
    public float GroundDistance = 0.2f;
    public LayerMask Ground;

    
    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;
    public float turnSpeed = 100f;
    private Vector3 moveDirection = Vector3.zero;
    //Moving parameters

    public Material highlightMaterial;
    public Material originalMaterial;
    GameObject lastHighlightedObject;
    //highlight effect parameters

   
    //magic cooldown

    public float sphere_radius = 2.0f;

    public gameController gc;
    public Vector3 SC_offset = new Vector3(0,0,0);

    

    public interactItem carryItem = null;

    public Book book;
    public bool bookL;
    public bool bookR;

    public Hand righthand;

    public float feetHeight = 0f;

    //public wandController wc;

    //public GameObject choice_prefab;

    void Start()
    {
        right.HideController(true);
        left.HideController(true);
        _body = GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
        

    }

    void Update()
    {

        LockPlayerYAxis();
    }





    void LockPlayerYAxis() {
        if (this.transform.position.y > 0.766) {
            transform.position = new Vector3(this.transform.position.x, 0.766f, this.transform.position.z);
        };
    }
    
}