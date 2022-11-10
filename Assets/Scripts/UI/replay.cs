using UnityEngine;
using UnityEngine.SceneManagement;
public class replay : MonoBehaviour {


    /// <summary>
    /// function that switches back to the level scene
    /// </summary>
    public void Respawn(){
        SceneManager.LoadScene("Level" + 1);
    }
}

