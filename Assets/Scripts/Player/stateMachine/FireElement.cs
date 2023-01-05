using UnityEditor;
using UnityEngine;

namespace player{
    class FireElement : ElementState{

        private GameObject bulletPrefab;

        public FireElement(Transform player, GameObject projectile) : base(player)
        {
            Debug.Log(projectile);
            bulletPrefab = projectile;
        }

        /// <summary>
        /// function that launches a bullet 
        /// </summary>
        public override void UsePower(){
            Projectile bullet = GameObject.Instantiate(bulletPrefab).GetComponent<Projectile>();
            bullet.Launch(getDirection(), player);
        }


        /// <summary>
        /// function that calculates the velocty the bullet will have
        /// </summary>
        /// <returns>a vector3 of the velocity</returns>
        private Vector3 getDirection(){
            float vX = player.GetComponent<SpriteRenderer>().flipX ? -1 : 1;
            return new Vector3(vX, 0,0);
        }
    }
}