using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour {

	public Animation _AnimationBook;
	//public string _NameAnimaCloseBook;
	public AnimationClip _ClipOpenBook, _ClipCloseBook, _ClipToLeftPage, _ClipToRightPage;
	public GameObject[] Pages;
	public AudioSource _AudioSource;
	public AudioClip ClipOpenBook, ClipCloseBook, ClipLeaftPages;
	private int open, i = 0;
	private int cls = 0, ct = 0, nm = 0;
	private float tm;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(cls == 1)
		{
			tm += Time.deltaTime;
			for(int i = 0; i < nm; i++)
			{
				Pages[i].GetComponent<Animation>().clip = _ClipToRightPage;
				Pages[i].GetComponent<Animation>().Play();

			}
		 cls = 0;
		}

		if(open == 1)
		{
			if(Input.GetKeyUp(KeyCode.LeftArrow))
			{
				if(i < Pages.Length)
				{
					nm ++;
					_AudioSource.PlayOneShot(ClipLeaftPages);
					Pages[i].GetComponent<Animation>().clip = _ClipToLeftPage;
					Pages[i].GetComponent<Animation>().Play();
					//Pages[i].GetComponent<Animation>().CrossFade(_NameToLeftPage);
					i++;
				}
			}
			if(Input.GetKeyUp(KeyCode.RightArrow))
			{
				if(i > 0)
				{
					nm --;
					_AudioSource.PlayOneShot(ClipLeaftPages);
					i--;
					Pages[i].GetComponent<Animation>().clip = _ClipToRightPage;
					Pages[i].GetComponent<Animation>().Play();
					//Pages[i].GetComponent<Animation>().CrossFade(_NameToRightPage);
				}
			}
		}

	  if(Input.GetKeyUp(KeyCode.E))
		{
			open++;
			if(open> 1)
				open = 0;
			if(open == 1)
			{
				i = 0;
				nm = 0;
				_AudioSource.PlayOneShot(ClipOpenBook);
				_AnimationBook.clip = _ClipOpenBook;
				_AnimationBook.Play();
				//_AnimationBook.CrossFade(_NameOpenBook);
			}
			if(open == 0)
			{
				cls = 1;
				_AudioSource.PlayOneShot(ClipCloseBook);
				_AnimationBook.clip = _ClipCloseBook;
				_AnimationBook.Play();
				//_AnimationBook.CrossFade(_NameCloseBook);

			}
		}
	}
}
