using TMPro;
using UnityEngine;

public class HUDTimerController : MonoBehaviour
{

    [SerializeField] private TMP_Text CurrentClock;
    [SerializeField] private TMP_Text Act1Clock;
    [SerializeField] private TMP_Text Act2Clock;
    [SerializeField] private TMP_Text Act3Clock;
    
    private bool _isAct1Running, _isAct2Running, _isAct3Running, _isCurrentRunning;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCurrentTimer(bool start)
    {
        _isCurrentRunning = start;
    }

    public void StartAct1Timer(bool start)
    {
        _isAct1Running = start;
    }

    public void StartAct2Timer(bool start)
    {
        _isAct2Running = start;
    }

    public void StartAct3Timer(bool start)
    {
        _isAct3Running = start;
    }

    private void ConvertSecondsToMinutesText(int seconds)
    {
        CurrentClock.text = seconds.ToString();
    }
}
