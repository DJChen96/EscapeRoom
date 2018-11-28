using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour
{
    public Animation _AnimationBook;
    public Texture2D PlainTexture;
    public Texture2D[] stageMagicTextureArray;
    public GameObject[] magicPages;
    //public string _NameAnimaCloseBook;
    public AnimationClip _ClipOpenBook, _ClipCloseBook, _ClipToLeftPage, _ClipToRightPage;
    public GameObject[] Pages;
    public AudioSource _AudioSource;
    public AudioClip ClipOpenBook, ClipCloseBook, ClipLeaftPages;
    private int open;
    public int i = 1;
    private int cls = 0, ct = 0, nm = 0;
    private float tm;

    void Start()
    {
        SetStage(1);
    }

    public void SetStage(int stage)
    {
        if (stage > 0 && stage < 5)
        {
            ToPage(stage);
            switch (stage)
            {
                case 1:
                    magicPages[0].GetComponent<Renderer>().material.mainTexture = stageMagicTextureArray[0];
                    magicPages[1].GetComponent<Renderer>().material.mainTexture = PlainTexture;
                    break;
                case 2:
                    magicPages[0].GetComponent<Renderer>().material.mainTexture = stageMagicTextureArray[1];
                    magicPages[1].GetComponent<Renderer>().material.mainTexture = PlainTexture;
                    break;
                case 3:
                    magicPages[0].GetComponent<Renderer>().material.mainTexture = stageMagicTextureArray[1];
                    magicPages[1].GetComponent<Renderer>().material.mainTexture = stageMagicTextureArray[2];
                    break;
                case 4:
                    magicPages[0].GetComponent<Renderer>().material.mainTexture = stageMagicTextureArray[1];
                    magicPages[1].GetComponent<Renderer>().material.mainTexture = stageMagicTextureArray[3];
                    break;
            }

        }

    }

    private void NextPage()
    {
        if (i < Pages.Length)
        {

            nm++;
            _AudioSource.PlayOneShot(ClipLeaftPages);
            Pages[i].GetComponent<Animation>().clip = _ClipToLeftPage;
            Pages[i].GetComponent<Animation>().Play();
            i++;
        }
    }

    private void PrePage()
    {
        if (i > 0)
        {

            nm--;
            _AudioSource.PlayOneShot(ClipLeaftPages);
            i--;
            Pages[i].GetComponent<Animation>().clip = _ClipToRightPage;
            Pages[i].GetComponent<Animation>().Play();

        }
    }




    private void ToPage(int j)
    {

        if (i == j)
        {
            return;
        }
        else if (j < i)
        {
            StartCoroutine(PrePage_delay(j,i));
        }
        else if (j > i)
        {
            StartCoroutine(NextPage_delay(j,i));
        }
    }


    IEnumerator PrePage_delay(int j, int i)
    {
        int pages_need_turn = i;
        while (j != i)
        {
            pages_need_turn--;
            yield return new WaitForSeconds(0.5f);
            PrePage();
        }

    }

    IEnumerator NextPage_delay(int j, int i)
    {
        int pages_need_turn = i;
        while (j != pages_need_turn)
        {
            pages_need_turn ++;
            yield return new WaitForSeconds(0.5f);
            NextPage();
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.debugMode == false)
            return;

        if (Input.GetKeyUp(KeyCode.A))
        {
            PrePage();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            NextPage();
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            PrePage();
        }
        

    }
}
