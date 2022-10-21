using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    [SerializeField]
    IntVariable level;
    Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(!other.CompareTag("Player"))
            return;

        animator.SetBool("shouldClose", true);
        StartCoroutine(NextLevel(other));
    }

    IEnumerator NextLevel(Collider2D other){
        other.gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        Debug.Log("test");
        level.value++;
        SceneManager.LoadScene("level" + level.value);

    }
}
