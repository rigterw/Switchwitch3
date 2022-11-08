using UnityEngine;
public class State
{
    protected Color color;
    SpriteRenderer sprite;
    public State(SpriteRenderer spriteRenderer){
        sprite = spriteRenderer;
    }

    public virtual void Enter(){
        sprite.color = color;
    }


    public virtual void Update(){

    }

    public virtual Vector2 calculateForce(){
        return Vector2.zero;
    }
}