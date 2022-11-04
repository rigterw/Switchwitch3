using UnityEngine;

public class CreateLifes : MonoBehaviour
{
    [SerializeField]
    GameObject heart;
    public void MakeLifes()
    {
        int health =  HealthManager.MAXHEALTH;
        for (int i = 1; i < health+1; i++){
           GameObject tempHeart = Instantiate(heart, new Vector3(50 * i, Screen.height - 50, 0), Quaternion.identity, this.transform);
            tempHeart.name = "life" + i;
        }
        Debug.Log("lives ready");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
