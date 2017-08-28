using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW_StageLight : MonoBehaviour {
    [SerializeField] Light m_light;
    [SerializeField] bool m_isPowered;
    [SerializeField] static int m_identifer;
    [SerializeField] public int m_SetId;
 
    public bool GetPowered{
        get {
            return m_isPowered;
        }
        set {
            m_isPowered = value;
            if ( m_isPowered ) m_SetId = m_identifer++; 
            if (!m_isPowered) { m_light.enabled = false;}
            
        }
    }
    private void Awake( ) {
        m_isPowered = false;
    }

    public void ToggleLight(bool a_bool ) {
        if(m_isPowered) m_light.enabled = a_bool;
        else { m_light.enabled = false; }
    }
}
