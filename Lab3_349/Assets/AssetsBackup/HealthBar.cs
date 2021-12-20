using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image filledPart;

    public void ShowHealthFraction(float fraction)
    {
        //Scales the fillepart to the fraction provided.
        filledPart.rectTransform.localScale = new Vector3(fraction, 1, 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
