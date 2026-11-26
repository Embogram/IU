using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    public Light LightSource;
    public float DownTime = 2f;
    public float UpTime = 0.5f;
    public float DownIntensity = 0.3f;
    public float UpIntensity = 0.75f;
    

    void Start()
    {
        StartCoroutine(LightPingPong());
    }
    IEnumerator LightPingPong()
    {
        while (true)
        {
            LightSource.intensity = DownIntensity;
            yield return new WaitForSeconds(DownTime);
            float timer = 0;
            while (timer < 0.25f)
            {
                timer += Time.deltaTime;
                //Down - Up  =>  0 <- timer -> 0.25
                //timer = 0.125 => 50%
                //Down - Up => 0.45
                var percent = Mathf.InverseLerp(0f, 0.25f, timer);
                var intensity = Mathf.Lerp(DownIntensity, UpIntensity, percent);
                LightSource.intensity = intensity;
                yield return null;
            }
            yield return new WaitForSeconds(UpTime);
            while (timer > 0f)
            {
                timer -= Time.deltaTime;
                //Down - Up  =>  0 <- timer -> 0.25
                //timer = 0.125 => 50%
                //Down - Up => 0.45
                var percent = Mathf.InverseLerp(0f, 0.25f, timer);
                var intensity = Mathf.Lerp(DownIntensity, UpIntensity, percent);
                LightSource.intensity = intensity;
                yield return null;
            }
        }
    }
}
