using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BallInfo : MonoBehaviour{
    public BallTypeE Type {
        get{return _type;}
        set{
            ValidateFields();
            _type = value;
            _spRenderer.color = _colorFactory.GetColor(value);
        }
        }
    private BallTypeE _type;
    ColorFactory _colorFactory = new ColorFactory();
    SpriteRenderer _spRenderer;

    private void ValidateFields(){
        if(_spRenderer == null)
            _spRenderer = GetComponent<SpriteRenderer>();
    }

}
