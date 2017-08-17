using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NewtonVR;
using NewtonVR.Example;

public class WW_BlueLightPuzzle : MonoBehaviour {

    [Header("Desired Color Settings")]
    private Color m_colourCheck;
    public NVRExampleRGBResult result;

    [Header("Threshold Settings")]
    [Tooltip("The min value of the combined red and green values")]
    [SerializeField] private float minOffColourThreshold = 0.2f;

    [Header("Hidden Text")]
    [SerializeField] private List<Text> m_blueLightText;

    private bool blueGood = false;
    [SerializeField]float diff = 0.0f;
    // Use this for initialization
    void Start () {
	}
    
    void Update() {
        m_colourCheck = result.Result.material.color;
        Debug.Log(m_colourCheck.b);

        Debug.Log("Diff = " + (m_colourCheck.r + m_colourCheck.g));
        Debug.Log("Thresh = " + minOffColourThreshold);

        CheckForBlueAmount();
    }

    void CheckForBlueAmount() {
        if (m_colourCheck.b >= 0.8f) blueGood = true;
        else blueGood = false;
        // If blue good,
        // check min max threshhold between the rg values, if they are fairly low, its close to blue.

        if (blueGood) {
            if (m_colourCheck.r + m_colourCheck.g <= minOffColourThreshold) {
                diff = (m_colourCheck.r + m_colourCheck.g);
                // Set hidden texts alpha value, based off the differences 
                for (int i = 0; i < m_blueLightText.Count; i++) {
                    m_blueLightText[i].color = new Color(1, 1, 1, (minOffColourThreshold) - diff);
                }
            } else {
                for (int i = 0; i < m_blueLightText.Count; i++) {
                    m_blueLightText[i].color = new Color(1, 1, 1, 0);
                }
            }
        } else {
            for (int i = 0; i < m_blueLightText.Count; i++) {
                m_blueLightText[i].color = new Color(1, 1, 1, 0);
            }
        }

        // if the total value of the red and green combined is greater than a min threshold, it is blue enough?
        // so check how close the red and green values are to 0, add the two, and compare that to a hacked in float value...
    }
}
