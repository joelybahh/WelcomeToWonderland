using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
         if(Input.GetMouseButtonUp(2)) {
            ScreenCapture.CaptureScreenshot("Screenshot.png", 10);
        }
    }
}
