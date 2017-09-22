using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Puzzles.Helper {
    public class SpinnerButtonTrigger : MonoBehaviour {

        private SpinnerPuzzle m_spinnerPuzzleRef;

        [SerializeField] private NewtonVR.NVRHand m_leftHand;
        [SerializeField] private NewtonVR.NVRHand m_rightHand;

        void Start() {
            m_spinnerPuzzleRef = transform.parent.GetComponent<SpinnerPuzzle>();
        }

        void OnTriggerStay(Collider a_other) {
            if ( m_spinnerPuzzleRef.Button != null ) return; // if the spinner already has a button attatched, exit out of the loop.

            if ( a_other.tag == "CameraButton" ) {
                if ( a_other.GetComponent<NewtonVR.NVRInteractableItem>().AttachedHands.Count == 0 ) {
                    StartCoroutine(SetKinematicAfterTime(1.0f, a_other));
                }
            }
            else if ( a_other.tag != "CameraButton" ) {

                //Needs to be corrected to the correct voice line index/string
                WW.Managers.AudioManager.Instance.PlayVoiceLine(0);
                

            }
        }

        void OnTriggerExit(Collider a_other) {
            if (a_other.tag == "CameraButton") {
                m_spinnerPuzzleRef.Button = null;
            }
        }

        private IEnumerator SetKinematicAfterTime(float a_time, Collider a_other) {
            yield return new WaitForSeconds(a_time);

            Destroy(a_other.GetComponent<NewtonVR.NVRInteractableItem>());
            m_spinnerPuzzleRef.Button = a_other.GetComponentInChildren<NewtonVR.NVRButton>();

            m_spinnerPuzzleRef.Button.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                
            Rigidbody rbRef = a_other.GetComponent<Rigidbody>();
            rbRef.isKinematic = true;
            rbRef.useGravity = false;
        }
    }
}