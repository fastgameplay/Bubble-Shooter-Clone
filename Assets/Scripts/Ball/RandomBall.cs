using UnityEngine;
using static EnumExtentions;

[RequireComponent(typeof(BallInfo))]
public class RandomBall : MonoBehaviour{
    void Awake(){
        GetComponent<BallInfo>().Type = GetRandomEnumValue<BallTypeE>();
    }    
}
