using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Puzzles {
    public class LightPuzzle : Puzzle {
        [SerializeField] private StageLight[] m_lights;
        public StageLight[] Lights { get { return m_lights; } }
        [SerializeField] private float m_timer;
        Animator m_ani;
        [Tooltip("The Number the Lights have to be assigned from 0-3. EXAMPLE Light1 = 2, light2 = 4, light3 = 1, light4 = 3. the key would be 2,4,1,3")]
        [SerializeField] private int[] m_PuzzleKey = { 2, 3, 1, 4 };

        public static int m_identifier = 4;
        
        private bool PuzzleCorrect;  
        void Start() {
            m_ani = GetComponent<Animator>();
        }
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
        public void DisableAllLights() {
            for (int i = 0; i < m_lights.Length; i++) {
                m_lights[i].SetLight(false);
            }
        }

        /// <summary>
        /// Enables all lights
        /// </summary>
        public void EnableAllLights() {
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
        public override void CompletePuzzle()
        {
            base.CompletePuzzle();
            for (int i = 0; i < 2; i++)
            {
                m_lights[i].Light.color = Color.red;
            }
            for (int i = 2; i < 4; i++)
            {
                m_lights[i].Light.color = Color.blue;
            }
            m_ani.SetTrigger("PuzzleCompleted");
        }
    }
}