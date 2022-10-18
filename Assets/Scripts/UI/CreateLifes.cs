using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLifes : MonoBehaviour
{
    [SerializeField]
    GameObject heart;
    void Start()
    {
        int health = GameObject.Find("Player").GetComponent<HealthManager>().Health;
        for (int i = 1; i < health+1; i++){
           GameObject tempHeart = Instantiate(heart, new Vector3(50 * i, Screen.height - 50, 0), Quaternion.identity, this.transform);
            tempHeart.name = "life" + i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
