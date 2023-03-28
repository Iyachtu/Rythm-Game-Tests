using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    AudioSource _music;
    [SerializeField] bool _startMusic;
    [SerializeField] BeatScroller _beatScroller;
    public static GameManager Instance { get; private set; }
    [SerializeField] int _currentScore = 0;
    [SerializeField] int _scorePerNote = 100;
    [SerializeField] int _scorePerGoodNote = 120;
    [SerializeField] int _scorePerPerfectNote = 150;
    [SerializeField] Text _scoreText, _multiplierText;
    [SerializeField] int _currentMultiplier;
    [SerializeField] int _multiplierTracker;
    [SerializeField] int[] _multiplierTreshold;


    // Start is called before the first frame update
    void Start()
    {
        _music = GetComponent<AudioSource>();
        Instance = this;
        _scoreText.text = "Score: 0";
        _currentMultiplier= 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_startMusic)
        {
            if (Input.anyKeyDown)
            {
                _startMusic = true;
                _beatScroller._hasStarted= true;
                _music.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("hit on time");
        _multiplierTracker++;
        if (_multiplierTracker >= _multiplierTreshold[_currentMultiplier - 1] && _currentMultiplier < 4) 
        { 
            _currentMultiplier++; 
            _multiplierText.text = "Multiplier: " + _currentMultiplier; 
        }
        //_currentScore += _scorePerNote * _currentMultiplier;
        _scoreText.text = "Score: " + _currentScore;
    }

    public void NormalHit()
    {
        _currentScore += _scorePerNote * _currentMultiplier;
        NoteHit();
    }

    public void GoodHit()
    {
        _currentScore += _scorePerGoodNote * _currentMultiplier;
        NoteHit();
    }

    public void Perfect()
    {
        _currentScore += _scorePerPerfectNote * _currentMultiplier;
        NoteHit();
    }

    public void NoteMissed()
    {
        Debug.Log("missed note");
        _multiplierTracker = 0;
        _currentMultiplier = 1;
        _multiplierText.text = "Multiplier: " + _currentMultiplier;
    }
}
