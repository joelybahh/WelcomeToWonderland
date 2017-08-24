using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW_PowerOutletSwitch : MonoBehaviour {

    private HingeJoint m_switchJoint;
    private JointSpring m_spring;

    private bool m_switchOn = true;

    private float m_min;
    private float m_max;

    public bool m_switchState;

    private float offsetOn;
    private float offsetOff;
    public float currentRot;

    void Start() {
        m_switchJoint = GetComponent<HingeJoint>();
        m_spring = m_switchJoint.spring;
        m_max = m_switchJoint.limits.max;
        m_min = m_switchJoint.limits.min;
        m_switchOn = true;
        offsetOn = 91.0f;
        offsetOff = 93.0f;
    }
    
    void Update() {
        m_switchState = !m_switchOn;
        currentRot = Quaternion.Angle(Quaternion.identity, this.transform.rotation);
        if (currentRot > offsetOn && m_switchOn) {
            SetSwitch(false);
        } else if(currentRot < offsetOff && !m_switchOn) {
            SetSwitch(true);
        }

        if (m_switchOn) m_spring.targetPosition = m_min;
        else m_spring.targetPosition = m_max - 1;
        
        m_switchJoint.spring = m_spring;
    }

    private void SetSwitch(bool a_on) {
        m_switchOn = a_on;
    }

    private void ToggleSwitch() {
        m_switchOn = !m_switchOn;
    }

}
