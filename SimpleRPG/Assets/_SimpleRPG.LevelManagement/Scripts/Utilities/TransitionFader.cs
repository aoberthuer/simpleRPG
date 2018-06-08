using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionFader : ScreenFader {

    [SerializeField] private float lifetime = 1f;

    [SerializeField] private float delay = 0.3f;

    private void Awake()
    {
        // ensure lifetime makes sense
        lifetime = Mathf.Clamp(lifetime, FadeOnDuration + FadeOffDuration + delay, 10f);
    }

    private IEnumerator PlayRoutine()
    {
        SetAlpha(clearAlpha);
        yield return new WaitForSeconds(delay);

        FadeOn();
        float onTime = lifetime - (FadeOffDuration + delay);
        yield return new WaitForSeconds(onTime);

        FadeOff();
        Destroy(gameObject, FadeOffDuration);
    }

    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

}
