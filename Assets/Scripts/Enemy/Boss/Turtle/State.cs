using UnityEngine;

namespace TurtleStates
{
    public class State
    {
        public Color color;
        SpriteRenderer sprite;
        [SerializeField]
        protected float speed = 3;
        Transform player;
        BoolVariable gravityBool;
        public State(SpriteRenderer spriteRenderer, Transform player)
        {
            sprite = spriteRenderer;
            this.player = player;
        }

        public virtual void Enter(){
            
        }


        public virtual void Update()
        {

        }

        public virtual Vector2 calculateForce(Transform bossPoss, Vector2? veloci = null)
        {
            Vector2 velocity;
            if (veloci == null)
            {
                velocity = new Vector2(1, 0);
            }
            else
            {
                velocity = (Vector2)veloci;
            }
            int direction = player.position.x > bossPoss.position.x ? 1 : -1;;


            velocity *= direction;
            return velocity;
        }
    }
}