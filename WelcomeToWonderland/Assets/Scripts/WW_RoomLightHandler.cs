using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class WW_RoomLightHandler : MonoBehaviour {

    [Header("Room Lights")]
    [SerializeField] private List<GameObject> m_roomLightObjs;

    [Header("Light Switch Settings")]
    [SerializeField] private NVRButton m_lightSwitch;

    [Header("Hidden Text Settings")]
    [SerializeField] private WW_BlueLightPuzzle m_blPuzzle;

    private bool m_lightsOn = true;
	
	void Update () {
		if(m_lightSwitch.ButtonDown) {
            ToggleLights();        
        }
	}

    /// <summary>
    /// Toggles the main lights in the room.
    /// </summary>
    private void ToggleLights() {
        m_lightsOn = !m_lightsOn;
        
        for (int i = 0; i < m_roomLightObjs.Count; i++) {
            if(m_lightsOn) {
                m_roomLightObjs[i].SetActive(false);
                m_blPuzzle.LightsOn = false;
            } else {
                m_roomLightObjs[i].SetActive(true);
                m_blPuzzle.LightsOn = true;
            }
        }
    }
}
