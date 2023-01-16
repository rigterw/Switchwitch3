using UnityEditor;
using UnityEngine;

namespace player{
   public class FireElement : ElementState{

        private GameObject bulletPrefab;

        public FireElement(StateMachine sm, Transform player, GameObject projectile) : base(sm, player, 1)
        {
            bulletPrefab = projectile;
        }

        /// <summary>
        /// function that launches a bullet 
        /// </summary>
        protected override void ActivatePower(){
            Projectile bullet = GameObject.Instantiate(bulletPrefab).GetComponent<Projectile>();

            Debug.Log(bullet);
            Debug.Log(player);
            bullet.Launch(getDirection(player), player);
        }

        /// <summary>
        /// function that calculates the velocty the bullet will have
        /// </summary>
        /// <returns>a vector3 of the velocity</returns>
        private Vector3 getDirection(Transform sender){
            float vX = sender.GetComponent<SpriteRenderer>().flipX ? -1 : 1;
            return new Vector3(vX, 0,0);
        }


    }
}