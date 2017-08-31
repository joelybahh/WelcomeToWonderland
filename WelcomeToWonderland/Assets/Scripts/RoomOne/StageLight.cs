using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Puzzles {
    public class StageLight : MonoBehaviour {
        [SerializeField]
        Light m_light;
        [SerializeField]
        bool m_isPowered;
        bool m_isOn;
        [SerializeField]
        public int m_SetId = 0;

        public bool GetPowered {
            get {
                return m_isPowered;
            }
            set {
                m_isPowered = value;
                if ( m_isPowered && m_isOn ) { ToggleLight(true); }
                if ( !m_isPowered ) { m_light.enabled = false; }
                Debug.Log(LightPuzzle.m_identifier);
            }
        }
        private void Awake( ) {
            m_isPowered = false;
        }

        public void ToggleLight(bool a_bool) {
            m_isOn = a_bool;
            if ( m_isOn ) m_SetId = LightPuzzle.m_identifier++;
            if ( !m_isOn ) m_SetId = LightPuzzle.m_identifier--;
            if ( GetPowered )  m_light.enabled = a_bool; 
            else  m_light.enabled = false; 
            Debug.Log(LightPuzzle.m_identifier);
        }
        public void Incorrect() {
            m_light.color = Color.red;
        }
        public void Correct() {
            m_light.color = Color.green;
        }
    }
}