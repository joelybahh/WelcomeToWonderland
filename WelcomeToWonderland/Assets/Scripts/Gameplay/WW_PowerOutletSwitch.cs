using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW_PowerOutletSwitch : MonoBehaviour {

    public enum eSwitchState {
        ON,
        OFF
    }

    private HingeJoint m_switchJoint;
    private JointSpring m_spring;

    private int m_switchOn = 0;

    private float m_min;
    private float m_max;

    private float offsetOn;
    private float offsetOff;
    public float currentRot;

    public eSwitchState m_switchState = eSwitchState.OFF;

    void Start() {
        m_switchJoint = GetComponent<HingeJoint>();
        m_spring = m_switchJoint.spring;
        m_max = m_switchJoint.limits.max;
        m_min = m_switchJoint.limits.min;
        m_switchOn = 0;
        offsetOn = 91.0f;
        offsetOff = 93.0f;
    }
    
    void Update() {
        currentRot = Quaternion.Angle(Quaternion.identity, this.transform.rotation);

        switch(m_switchState) {
            case eSwitchState.ON:  CheckForSwitchOff(); break;
            case eSwitchState.OFF: CheckForSwitchOn();  break;
        }

        UpdateSwitchLimits();
    }

    private void SetSwitch(int a_on) {
        m_switchOn = a_on;
        m_switchState = (eSwitchState)m_switchOn;
    }

    private void CheckForSwitchOff() {
        if (currentRot < offsetOn)
            SetSwitch(1);
    }

    private void CheckForSwitchOn() {
        if(currentRot > offsetOff)
            SetSwitch(0);
    }

    private void UpdateSwitchLimits() {
        if (m_switchState == eSwitchState.OFF) m_spring.targetPosition = m_min;
        else m_spring.targetPosition = m_max - 1;

        m_switchJoint.spring = m_spring;
    }
}
