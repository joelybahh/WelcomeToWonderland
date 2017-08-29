using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Interactables.Visual {
    public class WW_SwitchStatusRenderer : MonoBehaviour {

        [Header("Status Object References")]
        [SerializeField]
        private GameObject[] m_statusObjects = new GameObject[2];

        [Header("Indicator Light Materials")]
        [SerializeField]
        private Material m_greenIndicatorMat;
        [SerializeField]
        private Material m_redIndicatorMat;

        private WW_FlickSwitch m_switch;
        private Renderer m_renderer;

        private Light[] m_statusLights = new Light[2];

        void Start() {
            m_switch = GetComponent<WW_FlickSwitch>();
            m_renderer = GetComponent<Renderer>();
            for ( int i = 0; i < m_statusObjects.Length; i++ ) {
                m_statusLights[i] = m_statusObjects[i].GetComponentInChildren<Light>();
            }
        }

        public void SetStatusLight() {
            switch ( m_switch.m_switchState ) {
                case WW_FlickSwitch.eSwitchState.LEFT: {
                    m_statusObjects[0].GetComponent<Renderer>().material = m_greenIndicatorMat;
                    m_statusObjects[1].GetComponent<Renderer>().material = m_redIndicatorMat;

                    m_statusLights[0].color = Color.green;
                    m_statusLights[1].color = Color.red;
                    break;
                }
                case WW_FlickSwitch.eSwitchState.RIGHT: {
                    m_statusObjects[1].GetComponent<Renderer>().material = m_greenIndicatorMat;
                    m_statusObjects[0].GetComponent<Renderer>().material = m_redIndicatorMat;

                    m_statusLights[1].color = Color.green;
                    m_statusLights[0].color = Color.red;
                    break;
                }
            }
        }
    }
}