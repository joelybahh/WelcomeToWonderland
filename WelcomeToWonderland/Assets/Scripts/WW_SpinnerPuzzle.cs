using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A class that handles the logic for the spinner puzzle
/// </summary>
public class WW_SpinnerPuzzle : MonoBehaviour {

    [Header("Ring References")]
    [SerializeField] private Transform m_outerRing;
    [SerializeField] private Transform m_middleRing;
    [SerializeField] private Transform m_centerRing;

    [Header("Ring Rotation Settings")]
    [SerializeField] private float m_outerDesiredRot;
    [SerializeField] private float m_middleDesiredRot;
    [SerializeField] private float m_centerDesiredRot;

    [Header("Ring Rotation Error Thresholds")]
    [Tooltip("The error threshold in degrees")]
    [SerializeField] private float m_errorThresh = 10.0f;

    [Header("Puzzle Events")]
    [SerializeField] private UnityEvent m_OnPuzzleInitialized;
    [SerializeField] private UnityEvent m_OnPuzzleComplete;

    private float m_spinnerOuterRot;
    private float m_spinnerMiddleRot;
    private float m_spinnerCenterRot;

    private bool m_poweredOn = false;
    
    public bool PowerOn {
        get { return m_poweredOn; }
        set { m_poweredOn = value; }
    }

    private void Update() {       
        if (!m_poweredOn) return; 
        else InitializeRotations();

        if (PuzzleComplete()) m_OnPuzzleComplete.Invoke();
    }

    /// <summary>
    /// Sets up the rotations values, normalizes them, and sets the rotation.
    /// </summary>
    private void InitializeRotations() {
        m_spinnerOuterRot = m_outerRing.transform.rotation.z;
        m_spinnerMiddleRot = m_middleRing.transform.rotation.z;
        m_spinnerCenterRot = m_centerRing.transform.rotation.z;

        NormalizeRotation(ref m_spinnerOuterRot);
        NormalizeRotation(ref m_spinnerMiddleRot);
        NormalizeRotation(ref m_spinnerCenterRot);

        m_outerRing.transform.rotation = new Quaternion(m_outerRing.transform.rotation.x, m_outerRing.transform.rotation.y, m_spinnerOuterRot, 1);
        m_middleRing.transform.rotation = new Quaternion(m_middleRing.transform.rotation.x, m_middleRing.transform.rotation.y, m_spinnerMiddleRot, 1);
        m_centerRing.transform.rotation = new Quaternion(m_centerRing.transform.rotation.x, m_centerRing.transform.rotation.y, m_spinnerCenterRot, 1);

        m_OnPuzzleInitialized.Invoke();
    }

    /// <summary>
    /// Clamps the rotation value between 0 and 360
    /// </summary>
    /// <param name="a_inputRot">A reference to the input rotation</param>
    private void NormalizeRotation(ref float a_inputRot) {
        a_inputRot = (a_inputRot % 360) + (a_inputRot < 0 ? 360: 0);
    }

    /// <summary>
    /// Checks if the puzzle is complete.
    /// </summary>
    /// <returns>A bool that states whether or not you have completed the puzzle</returns>
    private bool PuzzleComplete() {
        return (m_spinnerOuterRot >= (m_outerDesiredRot - m_errorThresh) && m_spinnerOuterRot <= (m_outerDesiredRot + m_errorThresh)) &&
           (m_spinnerMiddleRot >= (m_middleDesiredRot - m_errorThresh) && m_spinnerMiddleRot <= (m_middleDesiredRot + m_errorThresh)) &&
           (m_spinnerCenterRot >= (m_centerDesiredRot - m_errorThresh) && m_spinnerCenterRot <= (m_centerDesiredRot + m_errorThresh)) ? true : false;
    }
}
