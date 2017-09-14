using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ScreenManipulator : MonoBehaviour {

   public UnityEvent m_on;
   public UnityEvent m_off;
   public UnityEvent m_start;

    public Canvas m_AngryScreen;
    public Canvas m_timerScreen;

    public void StartAngryFace()
    {
        SetTimerScreen(false);
        SetAngryFaceScreen(true);
    }

   public void SetTimerScreen(bool aBool)
    {
        if (aBool) m_timerScreen.enabled = true;
        if (!aBool) m_timerScreen.enabled = false;

    }
    public void SetAngryFaceScreen(bool aBool)
    {
        if (aBool) m_AngryScreen.enabled = true;
        if (!aBool) m_AngryScreen.enabled = false;

    }
}

