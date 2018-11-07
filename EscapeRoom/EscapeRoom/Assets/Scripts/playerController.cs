using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

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

    public float fire_cooldown = 2.0f;
    public bool fire_inCD = false;
    public bool firemode = false;

    public float thunder_cooldown = 5.0f;
    public bool thunder_inCD = false;
    public bool thundermode = false;
    //magic cooldown

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
        
    }

    void Update()
    {


    }


    void FixedUpdate()
    {

        CastFireMagic();
        CastThunderMagic();
        Moving();
        RayCasting();
    }

    void Moving() {

        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);


        var x = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * Speed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    void RayCasting() {
        //Raycasting part
        // Bit shift the index of the layer (8) to get a bit mask

        int layerMask = 1 << 2;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        //raycast(origin, direction, hitInfo, maxdistance, layermask, queryTriggerInteraction)   
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.5f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            GameObject hitObject = hit.collider.gameObject;
            HighlightObject(hitObject);

            if (hit.collider.tag == "princess")
            {

                print("Hit Princess, kiss her!");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("CLEAR!");

                }
            }
            else
            {

                Debug.Log("hit " + hit.collider.tag.ToString());
            }


        }
        else
        {
            ClearHighlighted();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);

        }
    }
    
    void HighlightObject(GameObject gameObject)
    {
        if (lastHighlightedObject != gameObject)
        {
            if (gameObject.GetComponent<MeshRenderer>() != null)
            {
                ClearHighlighted();
                originalMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
                gameObject.GetComponent<MeshRenderer>().sharedMaterial = highlightMaterial;
                lastHighlightedObject = gameObject;
            }
        }

    }

    void ClearHighlighted()
    {
        if (lastHighlightedObject != null)
        {
            lastHighlightedObject.GetComponent<MeshRenderer>().sharedMaterial = originalMaterial;
            lastHighlightedObject = null;
            print("cleaning highlight effect");
        }
    }


    void CastFireMagic()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1) && !fire_inCD)
        {
            print("IN FIRE MODE");
            firemode = true;
            thundermode = false;
        }
        if (Input.GetMouseButton(0) && !fire_inCD && firemode)
        {
            fire_inCD = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && fire_inCD) {

        //on CD
        }
        if(fire_inCD&& fire_cooldown>0.0f)
            fire_cooldown -= Time.deltaTime;
        if (fire_cooldown <= 0.0f) {
            fire_cooldown = 2.0f;
            fire_inCD = false;
        }
    }

    void CastThunderMagic()
    {

        if (Input.GetKeyDown(KeyCode.Alpha2) && !thunder_inCD)
        {
            print("IN THUNDER MODE");
            thundermode = true;
            firemode = false;
        }

        if (Input.GetMouseButton(0) && !thunder_inCD && thundermode) {

            thunder_inCD = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && thunder_inCD)
        {//on CD
        }
        if (thunder_inCD && thunder_cooldown > 0.0f)
            thunder_cooldown -= Time.deltaTime;
        if (thunder_cooldown <= 0.0f)
        {
            thunder_cooldown = 5.0f;
            thunder_inCD = false;
        }
    }
}