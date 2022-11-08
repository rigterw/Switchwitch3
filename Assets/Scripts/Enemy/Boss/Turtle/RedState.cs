using UnityEngine;
public class RedState : State
{
    public RedState(SpriteRenderer sprite) : base(sprite){
        color = new Color(222, 67, 29);
    }
}