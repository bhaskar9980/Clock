using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private const float degreePerHour = 30f;
    private const float degreePerMinute = 6f;
    private const float degreePerSecond = 6f;

    [SerializeField] private Transform hoursTransform, minutesTransform, secondsTransform;
    [SerializeField] private bool continous;

    private void Awake()
    {
        UpdateStepper();
    }

    private void Update()
    {
        if (continous)
            UpdateContinous();
        else
            UpdateStepper();
    }

    private void UpdateContinous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;

        hoursTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degreePerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreePerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreePerSecond, 0f);
    }

    private void UpdateStepper()
    {
        DateTime time = DateTime.Now;
        float hours = (float)time.Hour + (float)((time.Minute) / 60.0);
        float minutes = (float)time.Hour * 60 + (float)time.Minute;
        float seconds = minutes * 60 + (float)time.Second;
        hoursTransform.localRotation = Quaternion.Euler(0f, hours * degreePerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, minutes * degreePerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, seconds * degreePerSecond, 0f);
    }
}