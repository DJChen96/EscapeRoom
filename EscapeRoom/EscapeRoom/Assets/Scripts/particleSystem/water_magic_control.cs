using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_magic_control : MonoBehaviour
{
    private ParticleSystem ps;
    public Component[] childrenList;

    // Use this for initialization
    void Start()
    {
        //print("SUCCESSFULLY INSTANSTIATED");
        ps = GetComponent<ParticleSystem>();
        
        ps.tag = "WaterMagic";

        childrenList = GetComponentsInChildren<ParticleSystem>();
        if(childrenList != null)
        foreach (ParticleSystem child in childrenList)
        {
           
            child.tag = "WaterMagic";
            var child_collision = child.collision;
            child_collision.sendCollisionMessages = true;

        }

        if (ps != null)
        {
            ps.Play();
            var ps_collision = ps.collision;
            ps_collision.sendCollisionMessages = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        bool stopped = true;
        if (childrenList != null)
        {
            foreach (ParticleSystem child in childrenList)
            {
                stopped &= child.isStopped;
            }
        }

        stopped &= ps.isStopped;

        if (stopped)
        {
            GameObject.Destroy(this.transform.parent.gameObject);
        }
    }




    void FixedUpate()
    {

    }


}
