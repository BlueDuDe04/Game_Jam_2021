using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FXManager : MonoBehaviour
{
    public static FXManager Instance;
    public Audio ambience;
    public Audio footStep;

    private void Start() 
    {
        
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else 
            Instance = this;

    }
}
