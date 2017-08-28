using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW_LightPuzzle : WW_Puzzle {
    [SerializeField]
    WW_StageLight[] m_lights;
    [SerializeField]

    float m_timer;

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
        if ( m_timer > 0.0f && m_timer < 1.0f ) { DisableAllLights(); m_lights[2].ToggleLight(true); }

        if ( m_timer > 1.0f && m_timer < 2.0f ) { DisableAllLights(); m_lights[0].ToggleLight(true); }

        if ( m_timer > 2.0f && m_timer < 3.0f ) { DisableAllLights(); m_lights[1].ToggleLight(true); }

        if ( m_timer > 3.0f && m_timer < 4.0f ) { DisableAllLights(); m_lights[3].ToggleLight(true); }

        if ( m_timer > 4.0f && m_timer < 6.0f ) { DisableAllLights(); }

        else if(m_timer > 6.0f) { m_timer = 0.0f; }

    }

}
