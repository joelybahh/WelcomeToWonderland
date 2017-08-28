﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HingeJoint))]
public class WW_FlickSwitch : MonoBehaviour {

    public enum eSwitchState {
        LEFT,
        RIGHT
    }
    [SerializeField]
    UnityEvent m_LeftON;
    [SerializeField]
    UnityEvent m_RightOFF;

    private HingeJoint m_switchJoint;
    private JointSpring m_spring;

    private int m_switchOn = 0;

    private float m_min;
    private float m_max;

    public float offsetOn = 91.0f;
    public float offsetOff = 93.0f;
    public float currentRot;

    public bool isFlicker = false;

    public eSwitchState m_switchState = eSwitchState.RIGHT;

    void Start() {
        m_switchJoint = GetComponent<HingeJoint>();
        m_spring = m_switchJoint.spring;
        m_max = m_switchJoint.limits.max;
        m_min = m_switchJoint.limits.min;
        m_switchOn = 0;
    }

    void Update() {
        currentRot = transform.rotation.eulerAngles.y;
        switch (m_switchState) {
            case eSwitchState.LEFT: CheckForSwitchOff(); break;
            case eSwitchState.RIGHT: CheckForSwitchOn(); break;
        }



        UpdateSwitchLimits();
    }

    private void SetSwitch(int a_on) {
        m_switchOn = a_on;
        m_switchState = (eSwitchState)m_switchOn;

    }

    // always check
    private void CheckForSwitchOff() {
        if (currentRot < offsetOn) {
            SetSwitch(1);
            m_RightOFF.Invoke();
        }
    }

    private void CheckForSwitchOn() {
        if (currentRot > offsetOff) {
            SetSwitch(0);
            m_LeftON.Invoke();
        }

    }

    private void UpdateSwitchLimits() {
        if (m_switchState == eSwitchState.RIGHT) m_spring.targetPosition = m_min;
        else m_spring.targetPosition = m_max - 1;

        m_switchJoint.spring = m_spring;
    }
}
