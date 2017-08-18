using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NewtonVR.Example;
using TMPro;

public class WW_BlueLightPuzzle : MonoBehaviour {

    [Header("Desired Color Settings")]
    private Color m_colourCheck;
    public NVRExampleRGBResult m_result;

    [Header("Threshold Settings")]
    [Tooltip("The min value of the combined red and green values")]
    [SerializeField] private float m_minOffColourThreshold = 0.2f;

    [Header("Hidden Text")]
    [SerializeField] private List<TextMeshPro> m_blueLightText;
    [SerializeField] private List<TextMeshPro> m_redLightText;
    [SerializeField] private List<TextMeshPro> m_greenLightText;

    [HideInInspector] public bool LightsOn = false;

    private bool m_blueGood = false;
    private bool m_redGood = false;
    private bool m_greenGood = false;
    private float m_bDiff = 0.0f;
    private float m_rDiff = 0.0f;
    private float m_gDiff = 0.0f;
    
    void Update() {
        m_colourCheck = m_result.Result.material.color;  

        if (LightsOn) DisableHiddenText();
        else          CheckColours();

    }

    #region Private Methods

    private void DisableHiddenText() {
        // TODO: set this once instead, no need doing this every frame
        for (int i = 0; i < m_blueLightText.Count; i++) {
            m_blueLightText[i].color = new Color(1, 1, 1, 0);
        }
        for (int i = 0; i < m_blueLightText.Count; i++) {
            m_redLightText[i].color = new Color(1, 1, 1, 0);
        }
        for (int i = 0; i < m_blueLightText.Count; i++) {
            m_greenLightText[i].color = new Color(1, 1, 1, 0);
        }
    }

    private void CheckColours() {
        CheckForBlueAmount();
        CheckForGreenAmount();
        CheckForRedAmount();
    }

    private void CheckForBlueAmount() {
        if (m_colourCheck.b >= 0.8f) m_blueGood = true;
        else m_blueGood = false;
        // If blue good,
        // check min max threshhold between the rg values, if they are fairly low, its close to blue.

        //TODO: have the fade in start earlier, making the fade in less abrupt
        if (m_blueGood) {
            if (m_colourCheck.r + m_colourCheck.g <= m_minOffColourThreshold) {
                m_bDiff = (m_colourCheck.r + m_colourCheck.g);
                // Set hidden texts alpha value, based off the differences 
                for (int i = 0; i < m_blueLightText.Count; i++) {
                    m_blueLightText[i].color = new Color(1, 1, 1, ((m_minOffColourThreshold) - m_bDiff) * 0.75f);
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
    private void CheckForRedAmount() {
        if (m_colourCheck.r >= 0.8f) m_redGood = true;
        else m_redGood = false;
        // If blue good,
        // check min max threshhold between the rg values, if they are fairly low, its close to blue.

        //TODO: have the fade in start earlier, making the fade in less abrupt
        if (m_redGood) {
            if (m_colourCheck.b + m_colourCheck.g <= m_minOffColourThreshold) {
                m_rDiff = (m_colourCheck.b + m_colourCheck.g);
                // Set hidden texts alpha value, based off the differences 
                for (int i = 0; i < m_redLightText.Count; i++) {
                    m_redLightText[i].color = new Color(1, 1, 1, ((m_minOffColourThreshold) - m_rDiff) * 0.75f);
                }
            } else {
                for (int i = 0; i < m_redLightText.Count; i++) {
                    m_redLightText[i].color = new Color(1, 1, 1, 0);
                }
            }
        } else {
            for (int i = 0; i < m_redLightText.Count; i++) {
                m_redLightText[i].color = new Color(1, 1, 1, 0);
            }
        }

        // if the total value of the red and green combined is greater than a min threshold, it is blue enough?
        // so check how close the red and green values are to 0, add the two, and compare that to a hacked in float value...
    }
    private void CheckForGreenAmount() {
        if (m_colourCheck.g >= 0.8f) m_greenGood = true;
        else m_greenGood = false;
        // If blue good,
        // check min max threshhold between the rg values, if they are fairly low, its close to blue.

        //TODO: have the fade in start earlier, making the fade in less abrupt
        if (m_greenGood) {
            if (m_colourCheck.r + m_colourCheck.b <= m_minOffColourThreshold) {
                m_gDiff = (m_colourCheck.r + m_colourCheck.b);
                // Set hidden texts alpha value, based off the differences 
                for (int i = 0; i < m_greenLightText.Count; i++) {
                    m_greenLightText[i].color = new Color(1, 1, 1, ((m_minOffColourThreshold) - m_gDiff) * 0.75f);
                }
            } else {
                for (int i = 0; i < m_greenLightText.Count; i++) {
                    m_greenLightText[i].color = new Color(1, 1, 1, 0);
                }
            }
        } else {
            for (int i = 0; i < m_greenLightText.Count; i++) {
                m_greenLightText[i].color = new Color(1, 1, 1, 0);
            }
        }

        // if the total value of the red and green combined is greater than a min threshold, it is blue enough?
        // so check how close the red and green values are to 0, add the two, and compare that to a hacked in float value...
    }

    #endregion
}
