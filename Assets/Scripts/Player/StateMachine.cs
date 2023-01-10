using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



namespace player
{
    public enum State
    {
        idle, walking, falling, died
    }

    public enum Element
    {
        normal, fire
    }

    public class StateMachine : MonoBehaviour
    {
        Animator animator;
        Rigidbody2D rigibody;

        State currentState;
        [SerializeField] private ElementVariable currentElement;

        Dictionary<Element, ElementState> elements = new Dictionary<Element, ElementState>();
        public Element CurrentElement {get { return currentElement.value; } }


        [SerializeField] private GameObject bullet;

        void Start()
        {
            animator = GetComponent<Animator>();
            rigibody = GetComponent<Rigidbody2D>();

            InitiateElements();
            SwitchElements(currentElement.value);
        }
        void Update()
        {
            State lastState = currentState;
            currentState = GetNextState();

            if (currentState == lastState)
                return;

            UpdateAnimation(currentState);
        }

        /// <summary>
        /// checks the new state
        /// </summary>
        /// <returns>the next state</returns>
        State GetNextState()
        {
            Vector2 velocity = rigibody.velocity;
            if (velocity.y >= 2f || velocity.y <= -2f)
                return State.falling;

            if (velocity.x != 0)
                return State.walking;

            return State.idle;
        }


        /// <summary>
        /// adds the elementstates to the dictionary
        /// </summary>
        private void InitiateElements(){
            elements.Add(Element.normal, new ElementState(this, transform));

            elements.Add(Element.fire, new FireElement(this, transform, bullet));
        }

        /// <summary>
        /// function that switches the element (state) of the player
        /// </summary>
        /// <param name="element">next element</param>
        public void SwitchElements(Element element){
            currentElement.value = element;
            animator.SetInteger("Element", (int)element);
            animator.SetTrigger("changeElement");
            StartCoroutine(deactivateTrigger());
        }

        /// <summary>
        /// uses the current states power
        /// </summary>
        public void UsePower(InputAction.CallbackContext context){
            if(!context.performed)
                return;

            Debug.Log("power");
            elements[currentElement.value].UsePower();
        }


    	/// <summary>
        /// resets the changelement trigger
        /// </summary>
        IEnumerator deactivateTrigger(){
            yield return new WaitForEndOfFrame();
            animator.ResetTrigger("changeElement");
        }


        /// <summary>
        /// function that plays the next animation
        /// </summary>
        /// <param name="nextState">the state that the animator has to switch to</param>
        void UpdateAnimation(State nextState)
        {
            animator.SetInteger("state", (int)nextState);
        }

        public State CurrentState
        {
            get { return currentState; }
        }
    }
}