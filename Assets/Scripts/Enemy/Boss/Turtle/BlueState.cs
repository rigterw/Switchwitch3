using UnityEngine;
namespace TurtleStates
{
    public class BlueState : State
    {
        public BlueState(SpriteRenderer sprite, Transform player) : base(sprite, player)
        {
            color = new Color(29, 203, 222);
        }
    }
}