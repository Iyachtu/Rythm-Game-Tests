using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    [SerializeField] float _beatTempo;
    [SerializeField] public bool _hasStarted;


    // Start is called before the first frame update
    void Start()
    {
        _beatTempo = _beatTempo / 60;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasStarted)
        {
            //if (Input.anyKeyDown)
            //{
            //    _hasStarted = true;
            //}
        }
        else
        {
            transform.position -= new Vector3(0,_beatTempo*Time.deltaTime,0);

        }
    }
}
