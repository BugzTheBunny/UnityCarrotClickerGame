using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Carrot : MonoBehaviour
{

    [Header(" Settings ")]
    [SerializeField] private float fillRate = 0.05f;

    [Header(" Elements ")]
    [SerializeField] private Transform carrotRenderrerTransform;
    [SerializeField] private Image fillImage;
    private bool isFrenzyActive = false;

    [Header(" Actions ")]
    public static Action onFrenzyStarted;
    public static Action onFrenzyStopped;


    private void Awake()
    {
        InputManager.onCarrotClicked += OnCarrotClickedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= OnCarrotClickedCallback;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCarrotClickedCallback()
    {
        Animate();
        if (!isFrenzyActive)
        {
            Fill();
        }
    }

    private void Fill()
    {
        fillImage.fillAmount += fillRate;
        if (fillImage.fillAmount >= 1) {
            StartFrenzyMode();
        }
    }

    private void StartFrenzyMode()
    {
        onFrenzyStarted?.Invoke();
        isFrenzyActive = true;
        LeanTween.value(1,0,5).setOnUpdate((value) => fillImage.fillAmount = value).setOnComplete(StopFrenzyMode);
    }

    private void StopFrenzyMode()
    {
        isFrenzyActive = false;
        onFrenzyStopped?.Invoke();

    }

    private void Animate()
    {
        carrotRenderrerTransform.localScale = Vector3.one * 0.8f;
        LeanTween.cancel(carrotRenderrerTransform.gameObject);
        LeanTween.scale(carrotRenderrerTransform.gameObject, Vector3.one * 0.7f, .15f).setLoopPingPong(1);
    }

}
