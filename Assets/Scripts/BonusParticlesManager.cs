using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BonusParticlesManager : MonoBehaviour
{
    [Header(" Header ")]
    [SerializeField] private GameObject BonusParticlePrefab;
    [SerializeField] private CarrotManager carrotManager;
    
    private void Awake()
    {
        InputManager.onCarrotClickedPosition += CarrotClickedCallback;

    }

    private void OnDestroy()
    {
        InputManager.onCarrotClickedPosition -= CarrotClickedCallback;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CarrotClickedCallback(Vector2 clickedPositon)
    {
        GameObject particleInstance = Instantiate(BonusParticlePrefab, clickedPositon, Quaternion.identity, transform);

        particleInstance.GetComponent<BonusParticle>().Configure(carrotManager.GetCurrentMultiplier());

        Destroy(particleInstance, 1);
    }

}
