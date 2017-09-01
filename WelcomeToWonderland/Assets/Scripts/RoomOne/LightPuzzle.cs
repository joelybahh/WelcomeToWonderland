using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Puzzles {
    public class LightPuzzle : Puzzle {
        [SerializeField] private StageLight[] m_lights;
        [SerializeField] private float m_timer;

        [Tooltip("The Number the Lights have to be assigned from 0-3. EXAMPLE Light1 = 2, light2 = 4, light3 = 1, light4 = 3. the key would be 2,4,1,3")]
        [SerializeField] private int[] m_PuzzleKey = { 2, 3, 1, 4 };

        public static int m_identifier = 0;
        
        private bool PuzzleCorrect;  

        private void Update() {
            PuzzleCorrect = true;
            for ( int i = 0; i < m_lights.Length; i++ ) {
                if ( m_lights[i].m_SetId == m_PuzzleKey[i] ) { m_lights[i].Correct(); } else { m_lights[i].Incorrect(); PuzzleCorrect = false; }
            }

            if(PuzzleCorrect) CompletePuzzle();
        }

        /// <summary>
        /// Disables all lights
        /// </summary>
        private void DisableAllLights() {
            for (int i = 0; i < m_lights.Length; i++) {
                m_lights[i].SetLight(false);
            }
        }

        /// <summary>
        /// Enables all lights
        /// </summary>
        private void EnableAllLights() {
            for (int i = 0; i < m_lights.Length; i++) {
                m_lights[i].SetLight(true);
            }
        }

        /// <summary>
        /// Sets the power of all the lights
        /// </summary>
        /// <param name="a_On">On or Off</param>
        public void SetPowerLights( bool a_On ) {
            for ( int i = 0; i < m_lights.Length; i++ ) {
                m_lights[i].GetPowered = a_On;
            }
        }
    }
}