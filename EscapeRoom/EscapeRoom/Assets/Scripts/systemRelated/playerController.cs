using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

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

   
    //magic cooldown

    public float sphere_radius = 2.0f;

    public gameController gc;
    public Vector3 SC_offset = new Vector3(0,0,0);

    

    public interactItem carryItem = null;

    public Book book;
    public bool bookL;
    public bool bookR;

    public Hand righthand;

    //public wandController wc;

    //public GameObject choice_prefab;

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
      
        //RayCasting();
        //switchMagic();
    }

    

    //void RayCasting() {
    //    //Raycasting part
    //    // Bit shift the index of the layer (8) to get a bit mask

    //    int layerMask = 1 << 2;

    //    // This would cast rays only against colliders in layer 8.
    //    // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
    //    layerMask = ~layerMask;

    //    RaycastHit hit;
    //    // Does the ray intersect any objects excluding the player layer
    //    //raycast(origin, direction, hitInfo, maxdistance, layermask, queryTriggerInteraction)   
    //    if (Physics.SphereCast(transform.position+SC_offset, sphere_radius,transform.TransformDirection(Vector3.forward), out hit, 1.5f, layerMask))
    //    {
    //        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
           

    //        GameObject hitObject = hit.collider.gameObject;
    //        HighlightObject(hitObject);

    //        if (hit.collider.tag == "princess")
    //        {

    //        }
    //        else if (hit.collider.tag == "interactItem")
    //        {
    //            if (carryItem != null)
    //            {
    //                if (carryItem.name.Equals("FireStone"))
    //                {
    //                    Debug.Log("Obtained fireStone");
    //                    gc.fireStone_Obtained = true;
    //                }
    //            }
    //        }
    //        else if (hit.collider.tag == "book") {
    //            if (hitObject.name.Equals("BookR"))
    //            {
    //                Debug.Log("bookR is true");
    //                bookR = true;
    //                bookL = false;
    //            }
    //            else if (hitObject.name.Equals("BookL")) {
    //                Debug.Log("bookL is true");
    //                bookR = false;
    //                bookL = true;
    //            }
    //        }
    //            //Debug.Log("hit " + hit.collider.tag.ToString());
    //    }
    //    else
    //    {
    //        ClearHighlighted();
    //    }
    //}

    //void OnDrawGizmosSelected()
    //{
    //    // Draw a yellow sphere at the transform's position
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(transform.position, sphere_radius);
    //}

    void HighlightObject(GameObject gameObject)
    {
        if (lastHighlightedObject != gameObject)
        {
            if (gameObject.GetComponent<MeshRenderer>() != null)
            {
                ClearHighlighted();
                originalMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
                
                gameObject.layer = 8;
                lastHighlightedObject = gameObject;
            }
        }

    }

    void ClearHighlighted()
    {
        if (lastHighlightedObject != null)
        {
            //lastHighlightedObject.GetComponent<MeshRenderer>().sharedMaterial = originalMaterial;
            //Debug.Log("leave");
            lastHighlightedObject.layer = 0;
            lastHighlightedObject = null;
        }
    }


    
}