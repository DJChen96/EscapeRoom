using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour
{

    public Animation _AnimationBook;
    //public string _NameAnimaCloseBook;
    public AnimationClip _ClipOpenBook, _ClipCloseBook, _ClipToLeftPage, _ClipToRightPage;
    public GameObject[] Pages;
    public AudioSource _AudioSource;
    public AudioClip ClipOpenBook, ClipCloseBook, ClipLeaftPages;
    private int open, i = 1;
    private int cls = 0, ct = 0, nm = 0;
    private float tm;

    void Start()
    {

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

    private void ToPage()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


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
