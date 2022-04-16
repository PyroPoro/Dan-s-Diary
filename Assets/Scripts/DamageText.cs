using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public Color TextColor;
    public string damageText;
    //private Color startColor;
    private Color endColor;
    private float startTime;
    private float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshPro>().text = damageText;
        gameObject.GetComponent<TextMeshPro>().color = TextColor;
        endColor = new Color(TextColor.r, TextColor.g, TextColor.b, 0);
        startTime = Time.deltaTime;
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshPro>().color = Color.Lerp(TextColor, endColor, t);
        t += Time.deltaTime;
        gameObject.transform.Translate(0, 0.002f, 0);
    }
}
