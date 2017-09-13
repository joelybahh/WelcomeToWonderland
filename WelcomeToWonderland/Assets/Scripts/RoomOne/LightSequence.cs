using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSequence : MonoBehaviour {

    [SerializeField] private float m_delayTime;

    private eSequenceState m_sequenceState;
    private bool m_poweredOn = false;
    private bool m_inUse = false;
	void Start () {
        m_sequenceState = eSequenceState.FLASHING;
	}
	
	void Update () {
        if (m_poweredOn && !m_inUse) {
            switch (m_sequenceState) {
                case eSequenceState.FLASHING: FlashInSequence(); break;
                case eSequenceState.DELAY: WaitDelayTime(m_delayTime); break;
            }
        }
	}

    public void DisableActiveLights() {

    }
      
    public void SetState(eSequenceState a_state) {
        m_sequenceState = a_state;
    }

    private void FlashInSequence() {

    }
    private void WaitDelayTime(float a_timeToWait) {

    }
}

public enum eSequenceState {
    FLASHING,
    DELAY
}