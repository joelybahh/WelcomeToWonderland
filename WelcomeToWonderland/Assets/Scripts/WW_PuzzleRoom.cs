using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WW_PuzzleRoom : MonoBehaviour {

    [Header("Audio Queue Settings")]
    [SerializeField] private List<WW_TimedAudioQueue> m_idleAudioVoiceLines;

    private static int currentIndex = 0;
    private static float TimeSinceLastProgression = 0.0f;

    void Update() {
        TimeSinceLastProgression += Time.deltaTime;
    }

    public static void ProgressionMade() {
        TimeSinceLastProgression = 0.0f;
        currentIndex = 0;
    }

    public static void CheckForTimedQueue() {
        /* TODO: 
            LOOP THROUGH QUEUE,
            CHECK INDEX
            PLAY SOUND
            UPDATE INDEX
        */
    }
}

[System.Serializable]
public class WW_TimedAudioQueue {
    public string m_voiceLineTitle;

    [Header("Audio Settings")]
    public AudioClip m_clipToPlay;

    [Header("Timed Playback Settings")]
    public float m_minutesToPlay;
    public float m_secondsToPlay;
}
