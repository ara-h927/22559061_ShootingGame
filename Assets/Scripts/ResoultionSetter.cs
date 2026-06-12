using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoultionSetter : MonoBehaviour
{
    public int Width = 720;
    public int Height = 1440;
    public bool Disabled = false;

    // Start is called before the first frame update
    private void Start()
    {
        Screen.SetResolution(Width, Height, Disabled);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
