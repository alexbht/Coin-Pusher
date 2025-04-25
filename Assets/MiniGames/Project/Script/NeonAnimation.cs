using UnityEngine;
using System.Collections;

public class NeonAnimation : MonoBehaviour
{
    public GameObject neonGroup;
    public Material bloomMat;
    public Material highBloomMat;

    private bool isBlinking = false;

    public void Blink()
    {
        if (!isBlinking)
            StartCoroutine(BlinkNeon());
    }

    IEnumerator BlinkNeon()
    {
        isBlinking = true;

        for (int i = 0; i < 3; i++)
        {
            SetMat(neonGroup, bloomMat);
            yield return new WaitForSeconds(0.5f);

            SetMat(neonGroup, highBloomMat);
            yield return new WaitForSeconds(0.5f);
        }

        SetMat(neonGroup, bloomMat);
        isBlinking = false;
    }

    void SetMat(GameObject group, Material mat)
    {
        foreach (Transform child in group.transform)
        {
            GameObject obj = child.gameObject;
            obj.GetComponent<Renderer>().material = mat;
        }
    }
}