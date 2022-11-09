using UnityEngine;
namespace TurtleStates
{
    public class RedState : State
    {
        public RedState(SpriteRenderer sprite, Transform player) : base(sprite, player)
        {
            color = new Color(222, 67, 29);
            speed *= 3;
        }


    }
}