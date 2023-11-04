using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitPortal : MonoBehaviour
{
    [SerializeField]
    IntVariable level;
    [SerializeField]
    IntVariable deaths;
    public bool lifeFound;
    Animator animator;
    AudioSource openSound;


    void Start(){
        animator = GetComponent<Animator>();
        openSound = GetComponent<AudioSource>();
        lifeFound = false;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(!other.CompareTag("Player"))
            return;

        animator.SetBool("shouldClose", true);
        sendData();
            StartCoroutine(NextLevel(other));
    }
    void sendData(){
        var values = new Dictionary<string, object>{
            {"level", level.value},
            {"deaths", deaths.value},
            {"lifePickUp", lifeFound}
        };
        AnalyticsService.Instance.CustomData("levelCompleted", values);
    }

    IEnumerator NextLevel(Collider2D other){


            other.gameObject.SetActive(false);
            Debug.Log("next");
            yield return new WaitForSeconds(3);
            Debug.Log("nexie");
            level.value++;
            SceneManager.LoadScene("Level" + level.value);

    }

    public void Open(){
        animator.SetTrigger("open");
        openSound.Play();
    }

    /// <summary>
    /// function that makes the portal dissapear after close
    /// </summary>
    void Update(){
      if(  animator.GetCurrentAnimatorStateInfo(0).IsName("Remove"))
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

}
