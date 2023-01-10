using UnityEngine;
using System.Collections;

namespace player{
    public class ElementState
    {
        private float cooldownTime;
        private bool onCooldown;

        private StateMachine sm;
        protected Transform player;
        public ElementState(StateMachine sm, Transform player, float cooldownTime = 0){
            this.cooldownTime = cooldownTime;
            this.player = player;
            this.sm = sm;
        }

        

        /// <summary>
        /// activates the current elements power
        /// </summary>
        protected virtual void ActivatePower(){

        }

        /// <summary>
        /// function that tries to use the power
        /// </summary>
        public void UsePower()
        {
            if(onCooldown)
                return;
            ActivatePower();
            onCooldown = true;
            sm.StartCoroutine(resetCooldown(cooldownTime));
            
        }

        /// <summary>
        /// function that stops the cooldown after x amount of seconds
        /// </summary>
        /// <param name="time">the time in seconds of the cooldown</param>
        IEnumerator resetCooldown(float time){
            yield return new WaitForSeconds(time);
            onCooldown = false;
        } 
    }

}