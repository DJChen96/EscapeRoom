using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Controller : MonoBehaviour {

    //Two mermaid prefab
    public GameObject mermaidSmallPre;
    public GameObject mermaidBigPre;
    public GameObject growthStone;
    public bool mermaidWatered = true;
    public bool stage2Passed = false;
    public bool songPlayed = false;

	// Use this for initialization
	void Start () {
        		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Place holder for playing the mermaid song.
    IEnumerator playSong()
    {
        songPlayed = true;
        yield return new WaitForSeconds(1f);
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (mermaidWatered && songPlayed)
        {
            if (other.tag.Equals("splitPotion"))
            {
                Debug.Log("Oh nice. I shall give you this");
                Instantiate(growthStone, this.transform.position, new Quaternion(90f, 0, 0, 0));
                stage2Passed = true;
            }
            else if (other.tag.Equals("lovePotion"))
            {
                Debug.Log("Only if I had this before");

            }
            else if (other.tag.Equals("truthSerum"))
            {
                Debug.Log("Use Polymorph potion on me");

            }
        }

        else if (!mermaidWatered&&!songPlayed) {
            if (other.tag.Equals("waterMagic")) {
                Debug.Log("Thank you adventurer, let me sing you a song for return");
                mermaidWatered = true;
                StartCoroutine(playSong());
            }

        }
    }

}
