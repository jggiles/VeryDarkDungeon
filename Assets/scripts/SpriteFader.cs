using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteFader : MonoBehaviour
{
    public List<RectTransform> sprites;
    public float               fadeFrequency;
    public float               fadeLength;
    public bool                debug;

    private IEnumerator        _coroutine;
    private int                _listPosition = 0;

    void Start()
    {
        _coroutine = Fader(fadeFrequency);
        StartCoroutine(_coroutine);
    }

    //A timer that fades through an array of sprites in sequence
    private IEnumerator Fader(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(fadeFrequency);

            //fade this sprite out, fade in next two sprites
            LeanTween.alpha(sprites[_listPosition], 0, fadeLength);
            LeanTween.alpha(sprites[IncrimentListPosition(_listPosition, sprites.Count)], 1, fadeLength);
            LeanTween.alpha(sprites[IncrimentListPosition(_listPosition + 1, sprites.Count)], 1, fadeLength);
            _listPosition = IncrimentListPosition(_listPosition, sprites.Count);

            if (debug)
            {
                print("fading " + Time.time + ", List Position: " + _listPosition);
            }
        }
    }

    private int IncrimentListPosition(int position, int max)
    {
        if (position >= max - 1)
        {
            return 0;
        }
        else
        {
            return position + 1;
        }
    }
}
