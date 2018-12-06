using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MermaidController : MonoBehaviour
{

    //Two mermaid prefab
    public GameObject mermaidSmallPre;
    public GameObject mermaidBigPre;
    //public GameObject growthStone;
    public GameObject mermaidMorph;
    public GameObject bubble;
    //public GameObject MermaidMorph;

    public AudioClip[] mermailAudios;

    public bool mermaidWatered = false;
    //public bool stage2Passed = false;
    //public bool songPlayed = false;

    public bool speaking = false;
    public AudioSource audioSource;
    private Vector3 mermaidOriginPosition;

    public MagicCrystal growthCrystal;

    private float[] MermaidInstructionSpeakWaitingSet = new float[] { 0, 0 ,6 };
    private float[] MermaidDispearSet = new float[] { 0, 0, 3 };

    // Use this for initialization
    void Start()
    {
        mermaidOriginPosition = new Vector3(mermaidBigPre.transform.position.x, mermaidBigPre.transform.position.y, mermaidBigPre.transform.position.z);
    }

    float mermaidWavingFactor = 0;
    // Update is called once per frame
    void Update()
    {

        if (speaking && !audioSource.isPlaying)
        {
            speaking = false;
        }


        if (mermaidBigPre.activeSelf)
        {
            mermaidWavingFactor = mermaidWavingFactor + 1f * Time.deltaTime;
            mermaidBigPre.transform.position = new Vector3(mermaidOriginPosition.x,
                mermaidOriginPosition.y + 0.05f * Mathf.Sin(mermaidWavingFactor), mermaidOriginPosition.z );
   ;
        }

        if (MermaidInstructionSpeakWaitingSet[0] == 1)
        {
            MermaidInstructionSpeakWaitingSet[1] = MermaidInstructionSpeakWaitingSet[1] + Time.deltaTime;
            MermaidInstructionSpeakWaitingSet[0] = MermaidInstructionSpeakWaitingSet[1] < MermaidInstructionSpeakWaitingSet[2] ?
                MermaidInstructionSpeakWaitingSet[0] : 2;
            mermaidSmallPre.transform.position = new Vector3(mermaidSmallPre.transform.position.x, mermaidSmallPre.transform.position.y + Time.deltaTime * 0.1f, mermaidSmallPre.transform.position.z);
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + Time.deltaTime * 0.1f, this.gameObject.transform.position.z);
        }

        if (MermaidInstructionSpeakWaitingSet[0] == 2)
        {
            MermaidInstructionSpeak();
            MermaidInstructionSpeakWaitingSet[0] = 3;
        }

        if (MermaidDispearSet[0] == 1)
        {
            MermaidDispearSet[1] = MermaidDispearSet[1] + Time.deltaTime;
            MermaidDispearSet[0] = MermaidDispearSet[1] < MermaidDispearSet[2] ?
                MermaidDispearSet[0] : 2;
            mermaidBigPre.transform.localScale = Vector3.Lerp(mermaidBigPre.transform.localScale, new Vector3(0,0,0), Time.deltaTime * 0.5f);
          
        }

        if (MermaidDispearSet[0] == 2)
        {
            if (GameObject.Find("Highlighter"))
            {
                GameObject highlighter = GameObject.Find("Highlighter");
                Destroy(highlighter);
            }
            var inter_array = this.gameObject.GetComponentsInChildren<Interactable>();
            if (inter_array!=null) {
                foreach (Interactable i in inter_array) {
                    i.highlightOnHover = false;
                }
             }

            audioSource.clip = mermailAudios[3];
            audioSource.Play();
            bubble.SetActive(true);
            mermaidBigPre.SetActive(false);
            growthCrystal.gameObject.SetActive(true);
            growthCrystal.AbsorbMagic(2.0f);
            MermaidDispearSet[0] = 3;
        }





        if (gameController.debugMode == false || true)
            return;

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            GameObject go = new GameObject
            {
                tag = "WaterMagic"
            };
            OnParticleCollision(go);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            GameObject go = new GameObject();
            go.tag = "lovePotion";
            OnParticleCollision(go);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            GameObject go = new GameObject();
            go.tag = "truthSerum";
            OnParticleCollision(go);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            GameObject go = new GameObject();
            go.tag = "splitPotion";
            OnParticleCollision(go);
        }
    }

    //Place holder for playing the mermaid song.

    public void MermaidInstructionSpeak()
    {
       

        if (speaking)
            return;

        //MermaidMorph.SetActive(true);
        speaking = true;
        mermaidSmallPre.SetActive(false);
        mermaidBigPre.SetActive(true);
        audioSource.clip = mermailAudios[0];
        audioSource.Play();
        mermaidWatered = true;

    }


    private void OnParticleCollision(GameObject other)
    {

        if (mermaidWatered && !speaking)
        {
            speaking = true;
            if (other.tag.Equals("splitPotion"))
            {
                Debug.Log("Oh nice. I shall give you this");
                //Instantiate(growthStone, this.transform.position, new Quaternion(90f, 0, 0, 0));
                // audioSource.clip = mermailAudios[4];
                // audioSource.Play();

                MermaidDispearSet[0] = 1;
  

            }
            else if (other.tag.Equals("lovePotion"))
            {
                audioSource.clip = mermailAudios[2];
                audioSource.Play();

            }
            else if (other.tag.Equals("truthSerum"))
            {
                audioSource.clip = mermailAudios[1];
                audioSource.Play();

            }
        }

        if (!mermaidWatered)
        {
            if (other.tag.Equals("WaterMagic"))
            {
                MermaidInstructionSpeakWaitingSet[0] = 1;
                mermaidMorph.SetActive(true);
            }
        }
    }

}
