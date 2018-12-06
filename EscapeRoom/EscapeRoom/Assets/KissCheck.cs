using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class KissCheck : MonoBehaviour {

    public Transform camera_Player;
    private SoundEffectAudioSource soundEffectAudioSource;
    public AudioClip happy_aduio;

    //public float offset = 1.0f;

    bool start_Coroutine = false;
    // Use this for initialization
    void Start() {
        soundEffectAudioSource = FindObjectOfType<SoundEffectAudioSource>();

    }

    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(camera_Player.position, this.transform.position) < 1.0f && !start_Coroutine)
        {
            StartCoroutine(Reload());
            start_Coroutine = true;
        }

    }

    IEnumerator Reload() {
        FadeToWhite(happy_aduio.length);
        
        soundEffectAudioSource.Play(happy_aduio);
        yield return new WaitForSeconds(happy_aduio.length);

        //Invoke
        //Debug.Log("---------------------RELOAD SCENE---------------------------");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        while (!scene.isLoaded) {
            yield return null;
        }

        //yield return new WaitForSeconds(3.0f);


    }


    private void FadeToWhite(float _fadeDuration)
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.white, _fadeDuration);
    }



}
