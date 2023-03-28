using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    [SerializeField] bool _canBePressed;
    [SerializeField] KeyCode _keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_keyToPress))
        {
            if (_canBePressed) 
            { 
                gameObject.SetActive(false);
                GameManager.Instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            _canBePressed= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            _canBePressed= false;
            GameManager.Instance.NoteMissed();
        }
    }
}
