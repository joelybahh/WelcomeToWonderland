using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsetClipping : MonoBehaviour {

    public static bool m_isClipping = false;

    void OnTriggerStay(Collider a_other) {
        if (a_other.tag != "MainCamera") {
            m_isClipping = true;
        } else {
            m_isClipping = false;
        }

        //Debug.Log(m_isClipping);
    }
}
