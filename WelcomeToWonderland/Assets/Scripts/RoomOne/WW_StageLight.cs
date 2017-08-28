using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW_StageLight : MonoBehaviour {
    [SerializeField] Light m_light;
    bool m_isPowered;
    private void Awake( ) {
        //m_light = GetComponent<Light>();
    }
    public bool GetPowered{
        get {
            return m_isPowered;
        }
        set {
            if ( value ) { ToggleLight(true); }
            else { ToggleLight(false); }
            m_isPowered = value;
            
        }
    }

    public void ToggleLight(bool a_bool ) {
        m_light.enabled = a_bool;
    }
}
