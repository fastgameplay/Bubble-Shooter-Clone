using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public bool Tap { get { return _tap; } }
    public bool Hold { get { return _hold; } }

    public float Horizontal { get { return _movementDelta.x; } }
    public float Vertical { get { return _movementDelta.y; } }
    public Vector2 Axis { get { return _movementDelta; } }

    private Vector2 _startTouch, _movementDelta;
    private bool _tap,_hold;

    #region Instance
    private static TouchInput _instance;
    public static TouchInput Instance
    {
        get{
            if (_instance == null){
                _instance = FindObjectOfType<TouchInput>();
                if (_instance == null){
                    _instance = new GameObject("Spawned TouchInput", typeof(TouchInput)).GetComponent<TouchInput>();
                }

            }
            return _instance;
        }
        set { _instance = value; }
    }
    #endregion

    void Awake(){
        _startTouch = Camera.main.WorldToScreenPoint(transform.position);
    }

    private void Update(){
        _tap = false;
#if UNITY_EDITOR
    UpdateStandalone();
#else
    UpdateMobile();
#endif


    
    }

    private void UpdateStandalone(){
        if (Input.GetMouseButtonDown(0))
            _tap = _hold = true;
    
        else if (Input.GetMouseButtonUp(0)) 
            _hold = false;


        if(Input.GetMouseButton(0)) 
            _movementDelta = (Vector2)Input.mousePosition - _startTouch;
        
    }

    private void UpdateMobile(){
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                _tap = _hold = true;

            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) 
                _hold = false;

            _movementDelta = (Vector2)Input.mousePosition - _startTouch;


        }
    }
}