using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    [SerializeField]
    IntVariable level;
    // Start is called before the first frame update

   public  void Quit(){
        Application.Quit();
    }
}
