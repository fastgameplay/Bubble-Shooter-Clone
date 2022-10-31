using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ActiveBall : MonoBehaviour{

    BallInfo info;
    void Start(){
        info = GetComponent<BallInfo>();

    }
    void OnCollisionEnter(Collision other){
        Debug.Log(other.gameObject.tag);
    }

}
