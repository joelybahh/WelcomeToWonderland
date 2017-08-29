using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WW.Interactables;

namespace WW.Managers {
    public class WW_RoomLightHandler : MonoBehaviour {

        [Header("Room Lights")]
        [SerializeField]
        private List<GameObject> m_roomLightObjs;

        [Header("Room Light Switch")]
        [SerializeField]
        private WW_PowerOutletSwitch m_lightSwitch;

        [Space(50)]

        [Header("Puzzle Lights")]
        [SerializeField]
        private List<GameObject> m_puzzleLightObjs;

        [Header("Puzzle Light Switch Settings")]
        [SerializeField]
        private WW_PowerOutletSwitch m_puzzleLightSwitch;

        private bool m_roomLightsOn = true;
        private bool m_puzzleLightsOn = true;

        void Update() {
            switch ( m_lightSwitch.m_switchState ) {
                case WW_PowerOutletSwitch.eSwitchState.OFF: SetLights(WW_PowerOutletSwitch.eSwitchState.OFF, true); break;
                case WW_PowerOutletSwitch.eSwitchState.ON: SetLights(WW_PowerOutletSwitch.eSwitchState.ON, true); break;
            }

            switch ( m_puzzleLightSwitch.m_switchState ) {
                case WW_PowerOutletSwitch.eSwitchState.OFF: SetLights(WW_PowerOutletSwitch.eSwitchState.OFF, false); break;
                case WW_PowerOutletSwitch.eSwitchState.ON: SetLights(WW_PowerOutletSwitch.eSwitchState.ON, false); break;
            }
        }

        /// <summary>
        /// Toggles the main lights in the room.
        /// </summary>
        private void ToggleLights() {
            m_roomLightsOn = !m_roomLightsOn;
            for ( int i = 0; i < m_roomLightObjs.Count; i++ ) {
                if ( m_roomLightsOn ) {
                    m_roomLightObjs[i].SetActive(false);
                } else {
                    m_roomLightObjs[i].SetActive(true);
                }
            }
        }

        private void SetLights( WW_PowerOutletSwitch.eSwitchState a_state, bool a_isMainLights ) {
            if ( a_isMainLights ) {
                for ( int i = 0; i < m_roomLightObjs.Count; i++ ) {
                    switch ( a_state ) {
                        case WW_PowerOutletSwitch.eSwitchState.OFF: m_roomLightObjs[i].SetActive(false); break;
                        case WW_PowerOutletSwitch.eSwitchState.ON: m_roomLightObjs[i].SetActive(true); break;
                    }
                }
            } else {
                for ( int i = 0; i < m_puzzleLightObjs.Count; i++ ) {
                    switch ( a_state ) {
                        case WW_PowerOutletSwitch.eSwitchState.OFF: m_puzzleLightObjs[i].GetComponent<Light>().enabled = false; break;
                        case WW_PowerOutletSwitch.eSwitchState.ON: m_puzzleLightObjs[i].GetComponent<Light>().enabled = true; break;
                    }
                }
            }
        }
    }
}
