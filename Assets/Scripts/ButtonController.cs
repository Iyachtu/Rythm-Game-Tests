using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer _sr;
    public Sprite defaultImg, pressedImg;
    public KeyCode keyToPress;


    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            _sr.sprite = pressedImg;
        }
        if (Input.GetKeyUp(keyToPress))
        {
            _sr.sprite = defaultImg;
        }
    }
}
