using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour{

    [SerializeField] GameObject ballPrefab;
    [SerializeField] BallTypeE[] colorCycle;
    [SerializeField] float ballSpeed = 4.0f;
    


    Vector2 Axis;
    Rigidbody2D currentBallRB;

    int _counter = 0;
    bool ReadyToLaunch = false;
    bool _isRandom;

    void Start(){
        if( colorCycle.Length == 0){
            _isRandom = true;
        }
        GenerateNewBall();
    }

    
    void Update(){
        if(TouchInput.Instance.Began){
            ReadyToLaunch = true;
        }
        if(TouchInput.Instance.Hold) Axis = TouchInput.Instance.AxisNormalized;

        if(!TouchInput.Instance.Hold){
            if(ReadyToLaunch){
                currentBallRB.velocity = Axis * ballSpeed;
                currentBallRB.GetComponent<CircleCollider2D>().isTrigger = false;
                GenerateNewBall();
                ReadyToLaunch = false;
                
            }
        }
    }


    void GenerateNewBall(){
        currentBallRB = Instantiate(ballPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();

        if(_isRandom) {
            currentBallRB.gameObject.AddComponent<RandomBall>();
        }
        else {
            currentBallRB.gameObject.GetComponent<BallInfo>().Type = colorCycle[_counter % colorCycle.Length];
            _counter++;
        }
    }
}
