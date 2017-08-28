using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW_LightPuzzle : WW_Puzzle {
    [SerializeField] WW_StageLight[] m_lights;
    [SerializeField] float m_timer;

    [SerializeField]
    [Tooltip("The Number the Lights have to be assigned from 0-3. EXAMPLE Light1 = 2, light2 = 4, light3 = 1, light4 = 3. the key would be 2,4,1,3")] int[] m_PuzzleKey = { 2,3,1,4 };
    bool PuzzleCorrect;

    private void Awake( ) {
        DisableAllLights();
    }

    void DisableAllLights( ) {
        for( int i = 0; i < m_lights.Length; i++ ) {
            m_lights[i].ToggleLight(false) ;
        }
    }

    private void Update( ) {
        m_timer += Time.deltaTime;
        for ( int i = 0; i < m_lights.Length; i++ ) {
            if ( !m_lights[i].GetPowered ) return;
        }

        for ( int i = 0; i < m_lights.Length; i++ ) {
            if(m_lights[i].m_SetId != m_PuzzleKey[i] ) {
                PuzzleCorrect = false;
            }
            else { PuzzleCorrect = true;}
        }

        

        if ( m_timer > 4.0f && m_timer < 6.0f ) { DisableAllLights(); }

        else if(m_timer > 6.0f) { m_timer = 0.0f; }

    }

}
