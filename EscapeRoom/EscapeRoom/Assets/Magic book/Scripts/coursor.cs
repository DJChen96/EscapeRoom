using UnityEngine;
using System.Collections;

public class coursor : MonoBehaviour {


	// Use this for initialization
	void Start () {
		Application.runInBackground = true;
		//Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnApplicationFocus(bool boolFocus){
		if(boolFocus){
			Cursor.visible = false;
			//Screen.lockCursor = true;
		}else{
			Cursor.visible = true;
			//Screen.lockCursor = false;
		}
	}
}
