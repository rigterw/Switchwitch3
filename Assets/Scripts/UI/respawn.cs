using UnityEngine;
using UnityEngine.SceneManagement;
public class respawn : MonoBehaviour {

    [SerializeField]
    IntVariable level;
    [SerializeField]IntVariable deaths;

    /// <summary>
    /// function that switches back to the level scene
    /// </summary>
    public void Respawn(){
        deaths.value++;
        SceneManager.LoadScene("Level" + level.value);
    }
}

