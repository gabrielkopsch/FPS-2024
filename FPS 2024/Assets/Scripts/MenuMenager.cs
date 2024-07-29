using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMenager : MonoBehaviour
{
    public static MenuMenager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Connected()
    {

    }

}
