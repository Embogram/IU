using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public Color ActiveColor;
    public float Scale;

    private Vector3 baseScale;
    private Vector3 activscale;
    private Color baseColor;
    private Transform mash;
    private bool activate = false;



    void Start()
    {
        Cursor.visible = true;
        mash = transform.GetChild(0);

        baseColor = mash.GetComponent<Renderer>().material.color;

        baseScale = mash.localScale;
        activscale = baseScale * Scale;

    }


    private void OnMouseEnter()
    {
        mash.localScale = activscale;
        GetComponent<AudioSource>().Play();

    }

    private void OnMouseExit()
    {
        mash.localScale = baseScale;
        mash.GetComponent<Renderer>().material.color = baseColor;
        activate = false;
    }

    private void OnMouseDown()
    {
        mash.GetComponent<Renderer>().material.color = ActiveColor;
        activate = true;
    }

    private void OnMouseUpAsButton()
    {

        mash.GetComponent<Renderer>().material.color = baseColor;

        if (activate)
        {
            SceneManager.LoadScene(0);
        }

    }
}
