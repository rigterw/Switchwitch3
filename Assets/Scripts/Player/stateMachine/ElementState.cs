using UnityEngine;

namespace player{
    public class ElementState
    {
        protected Transform player;
        public ElementState(Transform player){
            this.player = player;
        }
        /// <summary>
        /// activates the current element
        /// </summary>
        public virtual void UsePower(){}
    }

}