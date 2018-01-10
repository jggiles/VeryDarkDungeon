using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flicker : MonoBehaviour
{
    public RectTransform itemToFlicker;
    public float         frequency;
    public float         minimum;
    public float         maximum;
    public bool          debug;

    private IEnumerator  _coroutine;

    void Start()
    {
        _coroutine = FlickerSprite(frequency, minimum, maximum);
        StartCoroutine(_coroutine);
    }

    private IEnumerator FlickerSprite(float freq, float min, float max)
    {
        while (true)
        {
            yield return new WaitForSeconds(freq);
            itemToFlicker.GetComponent<CanvasRenderer>().SetAlpha(UnityEngine.Random.Range(min, max));
            if (debug)
            {
                print("flickering " + Time.time + ", Alpha: " + itemToFlicker.GetComponent<CanvasRenderer>().GetAlpha());
            }
        }
    }
}
