using UnityEngine;
using UnityEngine.SceneManagement;
public class respawn : MonoBehaviour {

    [SerializeField]
    IntVariable level;

    /// <summary>
    /// function that switches back to the level scene
    /// </summary>
    public void Respawn(){
        SceneManager.LoadScene("Level" + level.value);
    }
}

