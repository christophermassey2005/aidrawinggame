using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_behaviour : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;
    private float thickness;

    public LineRenderer currentLineRenderer;

    Vector2 lastPos;

    private void Update()
    {

        thickness = Singletonattributes.Instance.thickness;
        Drawing();
    }

    void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            PointToMousePos();
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        //currentLineRenderer.startColor = Color.green;
        //currentLineRenderer.endColor = Color.green;
        currentLineRenderer.material.SetColor("_Color", Color.yellow);
        currentLineRenderer.material.SetColor("_EmissionColor", Color.yellow);
        //because you gotta have 2 points to start a line renderer, 
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);


        currentLineRenderer.SetWidth(thickness, thickness);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }

    public void Delete()
    {
        Destroy(brush);
    }

}
