using UnityEngine;
namespace TurtleStates
{
    public class IdleState : State
    {

        public IdleState(SpriteRenderer sprite, Transform player) : base(sprite, player)
        {
            color = new Color(29, 203, 222);
        }

        public override Vector2 calculateForce(Transform bossPoss, Vector2? veloci = null)
        {
            return Vector2.zero;
        }
    }
}
