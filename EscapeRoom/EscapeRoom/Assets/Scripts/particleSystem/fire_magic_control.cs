using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_magic_control : MonoBehaviour {
    private ParticleSystem ps;
    public Component[] childrenList;
   
    // Use this for initialization
    void Start () {
        //print("SUCCESSFULLY INSTANSTIATED");
        ps = GetComponent<ParticleSystem>();
        var trigger = ps.trigger;
        var collision_s = ps.collision;
        collision_s.enabled = true;
        collision_s.type = ParticleSystemCollisionType.World;
        collision_s.sendCollisionMessages = true;
        collision_s.bounce = 0;
        collision_s.dampen = 0;
        ps.tag = "FireMagic";

       // trigger.SetCollider(0,GameObject.Find("Dissolve").transform);
       // trigger.enabled = true;


       // trigger.enabled = true;
       // trigger.SetCollider(0,GameObject.Find("Dissolve").GetComponent<Transform>());
       // trigger.enter = ParticleSystemOverlapAction.Callback;

        childrenList = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem child in childrenList)
        {
            collision_s = child.collision;
            //trigger = child.trigger;
            //trigger.enabled = true;
            //trigger.SetCollider(0, GameObject.Find("Candle").GetComponent<Transform>());
            //trigger.enter = ParticleSystemOverlapAction.Callback;
            collision_s.enabled = true;
            collision_s.type = ParticleSystemCollisionType.World;
            collision_s.sendCollisionMessages = true;
            collision_s.lifetimeLoss = 1f;
            collision_s.bounce = 0;
            collision_s.dampen = 0;
            child.tag = "FireMagic";

        }

        if (ps != null)
        {
            ps.Play();
        }

    }
	
	// Update is called once per frame
	void Update () {
        bool stopped = true;
        if (childrenList != null)
        {
            foreach (ParticleSystem child in childrenList)
            {
                stopped &= child.isStopped;
            }
        }

        stopped &= ps.isStopped;

        if (stopped) {
            GameObject.Destroy(this.transform.parent.gameObject);
        }
    }

    


    void FixedUpate()
    {
        
    }


}
