using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ActiveBall : MonoBehaviour{

    BallInfo info;
    void Start(){
        info = GetComponent<BallInfo>();

    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "StaticBall"){
            Vector3 targetPoint = GetClosestPoint( col.gameObject.GetComponent<StaticBall>().CheckEmptySpaces());
            Debug.Log("Clousest point is :" + targetPoint);
            Destroy(GetComponent<Rigidbody2D>());
            transform.position = targetPoint;
            gameObject.tag = "StaticBall";
            gameObject.AddComponent<StaticBall>();

        }
    }


    Vector3 GetClosestPoint (Vector3[] points)
    {
        Vector3 bestPoint = transform.position;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach(Vector3 potentialPoint in points)
        {
            Vector3 directionToTarget = potentialPoint - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestPoint = potentialPoint;
            }
        }             
        return bestPoint;
    }

}
