using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBrokenController : MonoBehaviour {

    public AudioClip breakAudioClip;
    public SoundEffectAudioSource soundEffectAudioSource;
    public GameObject completeObj;
    public GameObject brokenObj;
    private float waitingTime = 3f;
    public bool debug_triger = false;

    public GameObject objectAppearBeforeBroken;

    private bool breaked =false;
	// Use this for initialization
	void Start () {
 
    }

    public void Break()
    {
        if (breaked) return;
        breaked = true;
        brokenObj.SetActive(true);
        soundEffectAudioSource.Play(breakAudioClip);
        StartCoroutine(Broken_box_disappear());
        this.gameObject.GetComponent<Collider>().enabled = false;

        if (objectAppearBeforeBroken) {
            objectAppearBeforeBroken.SetActive(true);
        }

        Destroy(completeObj.gameObject);

    }


    // Update is called once per frame
    void Update () {
		
        if(debug_triger == true && gameController.debugMode == true)
        {
            Break();
        }

	}
    IEnumerator Broken_box_disappear()
    {
        yield return new WaitForSeconds(waitingTime);
        Destroy(brokenObj.gameObject);
        Destroy(this.gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("FireMagic")) {
            Break();

        }
    }
}
