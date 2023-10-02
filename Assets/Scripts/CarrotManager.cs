using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarrotManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI carrotsText;

    [Header(" Data ")]
    [SerializeField] private double totalCarrotCount;
    [SerializeField] private int frenzyModeMultiplier;

    private int carrotIncrement = 1;


    private void Awake()
    {
        LoadData();
        InputManager.onCarrotClicked += CarrotClicekdCallback;

        Carrot.onFrenzyStarted += FrenzyModeStartedCallback;
        Carrot.onFrenzyStopped += FrenzyModeStoppedCallback;

    }

    
    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClicekdCallback;
        Carrot.onFrenzyStarted -= FrenzyModeStartedCallback;
        Carrot.onFrenzyStopped -= FrenzyModeStoppedCallback;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CarrotClicekdCallback()
    {
        totalCarrotCount += carrotIncrement;

        UpdateCarrotsText();

        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetString("Carrots",totalCarrotCount.ToString());
    }

    private void UpdateCarrotsText()
    {
        carrotsText.text = totalCarrotCount + " Carrots!";

    }

    private void LoadData()
    {
        Debug.Log("Called!");
        double.TryParse(PlayerPrefs.GetString("Carrots"), out totalCarrotCount);

        UpdateCarrotsText();

    }

    
    private void FrenzyModeStartedCallback()
    {
        carrotIncrement = frenzyModeMultiplier;
    }

    private void FrenzyModeStoppedCallback()
    {
        carrotIncrement = 1;
    }

    public int GetCurrentMultiplier()
    {
        return carrotIncrement;
    }

}
