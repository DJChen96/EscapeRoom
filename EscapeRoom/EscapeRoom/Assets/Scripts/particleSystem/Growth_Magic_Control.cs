using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth_Magic_Control : MonoBehaviour {

    private ParticleSystem ps;
    public Component[] childrenList;

    // Use this for initialization
    void Start()
    {
        //print("SUCCESSFULLY INSTANSTIATED");
        ps = GetComponent<ParticleSystem>();

        ps.tag = "GrowthMagic";

        childrenList = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem child in childrenList)
        {

            child.tag = "GrowthMagic";

        }

        if (ps != null)
        {
            ps.Play();
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
