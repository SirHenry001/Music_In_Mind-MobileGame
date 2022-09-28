using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public GameObject levelPopUp;

    public void LevelScreenExit()
    {
        levelPopUp.SetActive(false);
    }
}
