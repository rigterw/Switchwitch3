using UnityEngine;

namespace TurtleStates
{
    public class State
    {
        protected Color color;
        SpriteRenderer sprite;
        protected float speed = 10;
        Transform player;

        public State(SpriteRenderer spriteRenderer, Transform player)
        {
            sprite = spriteRenderer;
            this.player = player;
        }

        public virtual void Enter()
        {
            sprite.color = color;
        }


        public virtual void Update()
        {

        }

        public virtual Vector2 calculateForce(Transform bossPoss, Vector2? veloci = null)
        {
            Vector2 velocity;
            if (veloci == null)
            {
                velocity = new Vector2(0, 0);
            }
            else
            {
                velocity = (Vector2)veloci;
            }
            int direction;

            direction = player.position.x > bossPoss.position.x ? 1 : -1;

            velocity *= direction * speed;
            return velocity;
        }
    }
}