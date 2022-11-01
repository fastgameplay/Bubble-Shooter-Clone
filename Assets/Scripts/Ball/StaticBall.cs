using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBall : MonoBehaviour{
    private readonly Vector3[] neighbourCellCords = new Vector3[6]{
        new Vector3( 0.0f       , 0.6661358f, 0),
        new Vector3( 0.5769231f , 0.3330679f, 0),
        new Vector3( 0.5769231f ,-0.3330679f, 0),
        new Vector3( 0.0f       ,-0.6661358f, 0),
        new Vector3(-0.5769231f ,-0.3330679f, 0),
        new Vector3(-0.5769231f , 0.3330679f, 0),
    };


    public Vector3[] CheckEmptySpaces(){
        List<Vector3> Output = new List<Vector3>();
        for (int i = 0; i < 6; i++){
           //TODO add collision cheking in givven place
            Output.Add(transform.position + neighbourCellCords[i]);
        }
        return Output.ToArray();
    }
}
