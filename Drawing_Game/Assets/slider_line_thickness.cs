using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider_line_thickness : MonoBehaviour
{
    public Slider m_slider;
    // Start is called before the first frame update

    void Start()
    {
        m_slider.value = 0.3f;
    }

    void Update()
    {
        Singletonattributes.Instance.thickness = m_slider.value;

    }


}
