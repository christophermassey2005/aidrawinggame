using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSingletonfiles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() //Works because Start() is called after Awake() so the singleton is already instantiated at this point.
    {
        Singletonattributes.Instance.roundcounter = 0;
        Singletonattributes.Instance.pointcounter = 0;
        Singletonattributes.Instance.numberofrounds = 10;
        Singletonattributes.Instance.amountoftime = 10;
    }

}
