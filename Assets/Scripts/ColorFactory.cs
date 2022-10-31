using System.Collections.Generic;
using UnityEngine;

public class ColorFactory{
    Dictionary<BallTypeE,Color> colors = new Dictionary<BallTypeE, Color>{
        {BallTypeE.Green,Color.green},
        {BallTypeE.Blue,Color.blue},
        {BallTypeE.Cyan,Color.cyan},
        {BallTypeE.Magenta, Color.magenta},
        {BallTypeE.Red, Color.red},
        {BallTypeE.Yellow,Color.yellow}
        
    };

    public Color GetColor(BallTypeE type){
        return colors[type];
    }
}
