using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Managers {
    [RequireComponent(typeof(AudioSource))]
    public class WW_AudioManager : MonoBehaviour {

        public static WW_AudioManager Instance;

        private AudioSource m_audioSource;

        [Header("Voice Lines")]
        [SerializeField]
        private List<WW_VoiceLine> m_voiceLines;

        void Awake() {
            if ( Instance == null ) {
                Instance = this;
            } else if ( Instance != this ) {
                Destroy(gameObject);
            }

            m_audioSource = GetComponent<AudioSource>();
        }

        [ExecuteInEditMode]
        void Start() {
            for(int i = 0; i < m_voiceLines.Count; i++) {
                m_voiceLines[i].m_index = i;
            }
        }

        /// <summary>
        /// Plays an audio file based on its index in the list of voiceLines
        /// </summary>
        /// <param name="a_voiceLineIndex">The index at which you want to grab the voice line to play</param>
        public void PlayVoiceLine( uint a_voiceLineIndex ) {
            if ( a_voiceLineIndex > m_voiceLines.Count - 1 ) {
                Debug.LogError("Error Detected! -- Attempting to play an audio clip at an index that exceeds the array length! Exiting function to avoid issues!");
                return;
            }

            AudioClip aClip = m_voiceLines[(int)a_voiceLineIndex].m_clipToPlay;
            if ( aClip == null ) {
                Debug.LogError("Error Detected! -- The voice line you are attempting to play at index [" + a_voiceLineIndex + "] does not contain an audio clip!");
                return;
            }

            if ( m_voiceLines[(int) a_voiceLineIndex].m_onlyPlaysOnce) {
                if ( m_voiceLines[(int) a_voiceLineIndex].m_hasPlayed) {
                    return;
                } else {
                    m_voiceLines[(int) a_voiceLineIndex].m_hasPlayed = true;
                }
            }           

            m_audioSource.PlayOneShot(aClip);
        }

        /// <summary>
        /// Simply plays the audio file via the name (LESS EFFICIENT THAN INDEX)
        /// </summary>
        /// <param name="a_nameOfVoiceline">The name of the voiceLine you wish to play</param>
        public void PlayVoiceLine( string a_nameOfVoiceline ) {
            AudioClip clipToPlay = null;
            for ( int i = 0; i < m_voiceLines.Count; i++ ) {
                if ( m_voiceLines[i].m_nameOfLine.ToLower() == a_nameOfVoiceline.ToLower() ) {
                    clipToPlay = m_voiceLines[i].m_clipToPlay;
                    break;
                }
            }

            if ( clipToPlay == null ) {
                Debug.LogError("Error Detected! -- The voice line you are attempting to play with the name [" + a_nameOfVoiceline + "] does not contain an audio clip!");
                return;
            }

            m_audioSource.PlayOneShot(clipToPlay);
        }
    }

    [System.Serializable]
    public class WW_VoiceLine {
        public string m_nameOfLine;
        public AudioClip m_clipToPlay;

        public bool m_onlyPlaysOnce;
        public int m_index;

        [HideInInspector] public bool m_hasPlayed;
    }
}