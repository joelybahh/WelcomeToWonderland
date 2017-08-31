using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Puzzles.Helper {
    public class SpinnerButtonTrigger : MonoBehaviour {

        private SpinnerPuzzle m_spinnerPuzzleRef;

        void Start() {
            m_spinnerPuzzleRef = transform.parent.GetComponent<SpinnerPuzzle>();
        }

        void OnTriggerEnter(Collider a_other) {
            if(a_other.tag == "CameraButton") {
                m_spinnerPuzzleRef.Button = a_other.GetComponentInChildren<NewtonVR.NVRButton>();
            }
        }

        void OnTriggerExit(Collider a_other) {
            if (a_other.tag == "CameraButton") {
                m_spinnerPuzzleRef.Button = null;
            }
        }
    }
}