using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {

    public bool princessKissed;
   
    public bool woodStone_Obtained;

    
    public bool mermaidWatered;

    public bool waterStone_Obtained;
    public bool timeStone_Obtained;

    public GameObject candleGroup;

    public Stage1Controller s1c;
    //public Stage2Controller s2c;
    public Stage3Controller s3c;
    public Stage4Controller s4c;
    public Stage5Controller s5c;


    public magicCircle mc;

    // @Author Xiaotong Bao
    public static bool debugMode = true;

    // Use this for initialization
    void Start () {
        //Set Parameters
        princessKissed = false;

        
        StartCoroutine(GameFlow());

        
    }

    //Sample:
    //yield return new WaitForSeconds(BeginFade(-1));

    IEnumerator GameFlow() {

       // yield return StartCoroutine(FirstPuzzle());
        yield return StartCoroutine(SecondPuzzle());
        yield return StartCoroutine(ThirdPuzzle());
    }

  

   

    IEnumerator SecondPuzzle()
    {
        Debug.Log("---------SECOND PUZZLE----------");
        while (!waterStone_Obtained)
        {

            yield return null;
        }

        while (!mermaidWatered) {
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        Debug.Log("------------SECOND PUZZLE PASSED------------");
    }

    IEnumerator ThirdPuzzle()
    {
        Debug.Log("---------SECOND PUZZLE----------");
        while (!woodStone_Obtained)
        {

            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        Debug.Log("------------SECOND PUZZLE PASSED------------");
    }

    IEnumerator FourthPuzzle()
    {
        Debug.Log("---------SECOND PUZZLE----------");
        while (!timeStone_Obtained)
        {

            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        Debug.Log("------------SECOND PUZZLE PASSED------------");
    }
    IEnumerator FifthPuzzle()
    {
        Debug.Log("---------SECOND PUZZLE----------");
        while (!woodStone_Obtained)
        {

            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        Debug.Log("------------SECOND PUZZLE PASSED------------");
    }

    // Update is called once per frame
    void Update () {
		
	}

    void FixedUpdate()
    {
        
    }
}
