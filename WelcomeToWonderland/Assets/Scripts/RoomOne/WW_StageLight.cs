using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Puzzles {
    public class WW_StageLight : MonoBehaviour {
        [SerializeField]
        Light m_light;
        [SerializeField]
        bool m_isPowered;
        [SerializeField]
        public int m_SetId;

        public bool GetPowered {
            get {
                return m_isPowered;
            }
            set {
                m_isPowered = value;
                if ( m_isPowered ) m_SetId = WW_LightPuzzle.m_identifier++;
                if ( !m_isPowered ) { m_SetId = 0; WW_LightPuzzle.m_identifier--; m_light.enabled = false; }
                Debug.Log(WW_LightPuzzle.m_identifier);
            }
        }
        private void Awake() {
            m_isPowered = false;
        }

        public void ToggleLight( bool a_bool ) {
            if ( m_isPowered ) m_light.enabled = a_bool;
            else { m_light.enabled = false; }
        }
        public void Incorrect() {
            m_light.color = Color.red;
        }
        public void Correct() {
            m_light.color = Color.green;
        }
    }
}