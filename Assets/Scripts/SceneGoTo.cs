using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGoTo : MonoBehaviour {

    public void goToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void goToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

}
