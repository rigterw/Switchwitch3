using UnityEngine;
namespace TurtleStates
{
    public class HitState : State
    {
        
        int direction;
        Transform bouncePoint;
        Animator animator;
        BossHealth healthManager;
        public HitState(SpriteRenderer sprite, Transform player, Animator animator, Transform bounceObject, BossHealth healthManager) : base(sprite, player)
        {
            bouncePoint = bounceObject;
            this.animator = animator;
            direction = bouncePoint.localPosition.x > 0 ? 1 : -1;
            this.healthManager = healthManager;
        }


       public override void Update(){
            if(BounceCheck()){
                bouncePoint.localPosition = -bouncePoint.localPosition;
                direction = -direction;
            }
        }



        public override Vector2 calculateForce(Transform bossPoss, Vector2? veloci = null)
        {
            return new Vector2(direction * 7, 0);
        }
        bool BounceCheck(){
        Vector2 vdirection = direction == -1 ? Vector2.right : Vector2.left;
        RaycastHit2D wallHit = Physics2D.Raycast(bouncePoint.position, vdirection, 1, LayerMask.GetMask("world"));
        bool shouldBounce = wallHit.collider != null;


        return shouldBounce;
        }

    }
}