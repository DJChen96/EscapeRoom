using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public bool dead = false;
    public Animator monster_ani;
    public GameObject deadEffect;

	// Use this for initialization
	void Start () {
        monster_ani = GetComponent<Animator>();
        deadEffect.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag.Equals("apple")) {
            
            monster_ani.SetBool("apple", true);
            GameObject.Destroy(collision.collider.gameObject);
        }
    }

    public void KillMonster()
    {
        dead = true;
    }

    

}
