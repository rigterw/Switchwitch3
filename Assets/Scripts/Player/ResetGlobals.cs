using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetGlobals : MonoBehaviour
{
    [SerializeField] BoolVariable gravity;
    [SerializeField] IntVariable level;
    // Start is called before the first frame update
    void Start()
    {
        gravity.value = false;
        string sceneName = SceneManager.GetActiveScene().name;
        char levelNr = sceneName[sceneName.Length - 1];
        level.value = (int)(levelNr - '0');
    }

}
