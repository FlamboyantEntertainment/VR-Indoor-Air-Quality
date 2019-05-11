using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


public class FadeInGameObject : MonoBehaviour
{
    private VRInteractiveItem m_InteractiveItem;
    SpriteRenderer homeRender;

    

    // Use this for initialization
    void Start()
    {
        homeRender = GetComponent<SpriteRenderer>();
        Color c = homeRender.material.color;
        c.a = 0f;
        homeRender.material.color = c;

    }

    IEnumerator FadeInHere()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = homeRender.material.color;
            c.a = f;
            homeRender.material.color = c;
            yield return new WaitForSeconds(0.05f);
           
        }
    }

    public void startFading()
    {
        StartCoroutine(FadeInHere());
    }
}

