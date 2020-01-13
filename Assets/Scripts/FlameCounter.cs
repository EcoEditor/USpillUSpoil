using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class FlameCounter : MonoBehaviour
{
    public float fireDuration; //in seconds. 
    public float EXPLOSION_FACTOR = 2;
    public float EXPLOSION_ANIMATION_TIME = 3;
    public Color EXPLOSION_COLOR;
    public AudioSource fireAudio;
    public AudioClip explosionSound;

    private float counter;
    private Vector3 startingFireValues;
    private float startingLightRange;
    private Light fireLight;
    private bool deacreaseFire;
    private Color DEFAULT_COLOR = Color.white;

    public float fireLeft;

    void Start()
    {
        fireLeft = fireDuration;

        deacreaseFire = true;
        fireLight = GetComponentInChildren<Light>(); // 1 is the index of light child.
        startingFireValues = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        startingLightRange = fireLight.range;
        ChangeColor(DEFAULT_COLOR);
    }

    void Update()
    {
        if (deacreaseFire)
        {
            //counter += Time.deltaTime;

            fireLeft -= Time.deltaTime;
            var fireVal = fireLeft/fireDuration;
            transform.localScale = Vector3.one * Mathf.Clamp01(fireVal);

            // transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, fireDuration * Time.deltaTime);
           
            if (fireLeft <= 0)
            {
                print("GAME OVER!");
            }
            //if (counter >= fireDuration - 4f) //the explosion will be triggered by the player
            //{
            //    if (!explosionStarted) {
            //        StartCoroutine(ExplosionEnumarator());
            //    }
            //    explosionStarted = true;
            //}
        }
    }
    
    //private bool explosionStarted = false;
    public void CallExplosion()
    {
        StartCoroutine(ExplosionEnumarator());
    }
    private IEnumerator ExplosionEnumarator()
    {
        deacreaseFire = false;
        float startRange = fireLight.range;
        Vector3 startScale = transform.localScale;
        Color startColor = fireLight.color;
        bool isSoundChanged = false;

        float t = 0;
        while (t <= EXPLOSION_ANIMATION_TIME)
        {
            fireLight.range = Mathf.Lerp(startRange, startingLightRange * EXPLOSION_FACTOR, t / EXPLOSION_ANIMATION_TIME);
            transform.localScale = Vector3.Lerp(startScale, startingFireValues * EXPLOSION_FACTOR, t / EXPLOSION_ANIMATION_TIME);
            if (t >= EXPLOSION_ANIMATION_TIME / 4 && !isSoundChanged)
            {
                isSoundChanged = true;
                fireAudio.clip = explosionSound;
                fireAudio.Play();
            }
            ChangeColor(Color.Lerp(startColor, EXPLOSION_COLOR, t / EXPLOSION_ANIMATION_TIME));

            t += Time.deltaTime;
            yield return null;
        }

    }

    private void ChangeColor(Color c)
    {
        fireLight.color = Color.Lerp(c, Color.white, 0.5f); ;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", c);
        GetComponent<Renderer>().material.SetColor("_Color", c);
    }
}
