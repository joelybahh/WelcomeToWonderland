using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class BombTimer : MonoBehaviour {
    List<UnityEvent> m_timersUIOn;
    List<UnityEvent> m_timersUIOff;

    [SerializeField] List<GameObject> UIElements;
    [Header("Final Countdown")]
    [SerializeField] UnityEvent m_explosions;
    [Header("Debugging Tools")]
    [SerializeField] float m_timer;
    [SerializeField] bool m_triggered;

    private void Start()
    {
        foreach(GameObject g in UIElements)
        {
            m_timersUIOn.Add(g.GetComponent<ScreenManipulator>().m_on);
            m_timersUIOff.Add(g.GetComponent<ScreenManipulator>().m_off);
        }
    }

    private void Update()
    {
        if (m_triggered)
        {
            m_timer -= Time.deltaTime;
            if(m_timer < 0.0f)
            {
                m_explosions.Invoke();
            }
        }
    }

    void SetTriggered(bool aBool)
    {
        m_triggered = aBool;
        if (aBool)
        {
            foreach (UnityEvent e in m_timersUIOn)
            {
                e.Invoke();
            }
        }
        else if (!aBool)
        {
            foreach (UnityEvent e in m_timersUIOff)
            {
                e.Invoke();
            }
        }
    }

    public void MAKEEVERYTHINGEXPLODEINHELLFIRE() { }
}
