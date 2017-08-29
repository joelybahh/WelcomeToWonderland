using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Puzzles {
    public class LightPuzzle : Puzzle {
        [SerializeField]
        StageLight[] m_lights;
        [SerializeField]
        float m_timer;

        public static int m_identifier = 0;

        [SerializeField]
        [Tooltip("The Number the Lights have to be assigned from 0-3. EXAMPLE Light1 = 2, light2 = 4, light3 = 1, light4 = 3. the key would be 2,4,1,3")]
        int[] m_PuzzleKey = { 2,3,1,4 };
        bool PuzzleCorrect;

        private void Awake() {
            DisableAllLights();
        }

        void DisableAllLights() {
            for ( int i = 0; i < m_lights.Length; i++ ) {
                m_lights[i].ToggleLight(false);
            }
        }

        void EnableAllLights() {
            for ( int i = 0; i < m_lights.Length; i++ ) {
                m_lights[i].ToggleLight(true);
            }
        }

        private void Update() {
            PuzzleCorrect = true;
            for ( int i = 0; i < m_lights.Length; i++ ) {

                if ( m_lights[i].m_SetId == m_PuzzleKey[i] ) { m_lights[i].Correct(); } else { m_lights[i].Incorrect(); PuzzleCorrect = false; }
            }
            m_timer += Time.deltaTime;
            if ( m_timer > 5.0f ) {
                EnableAllLights();
            }
            if ( m_timer > 5.3f ) {
                DisableAllLights();
                m_timer = 0.0f;
            }
        }
    }
}