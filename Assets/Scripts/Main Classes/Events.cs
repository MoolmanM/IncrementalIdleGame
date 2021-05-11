using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Events : MonoBehaviour
{
    public float  animalAttack, villageUnderAttack, randomNumber;
    public TMP_Text txtHistoryLog, txtNotificationText;
    private string _currentHistoryLog;
    public TMP_Text txtAvailableWorkers;
    private bool eventHappened;

    public GameObject scrollViewObject;
    public Animator animatorNotification;

    private float _timer = 0.1f;
    private readonly float maxValue = 0.01f;

    private float Timer = 0.1f;
    private readonly float MaxValue = 10f;

    private void StoneAgeEvents()
    {
        animalAttack = 1f;
        villageUnderAttack = 0.3f;
        randomNumber = UnityEngine.Random.Range(0f, 100f);

        if (randomNumber <= animalAttack)
        {
            AnimalAttack();
            eventHappened = true;
        }
        if (randomNumber <= villageUnderAttack)
        {
            NotableEvent("Your village is under attack!");
            eventHappened = true;
        }

        if (eventHappened == true)
        {

            if (IsPlaying(animatorNotification, "Notification_Display"))
            {
                animatorNotification.Play("Notification_Display" , -1, 0);
                Debug.Log("Should Display");
            }
            else if (IsPlaying(animatorNotification, "Notification_Down"))
            {
                animatorNotification.SetTrigger("Start_Notification");
                Debug.Log("Interupted going down");
            }
            else
            {
                animatorNotification.SetTrigger("Start_Notification");
                //animatorNotification.Play("Notification_Up");
                Debug.Log("Should go up");
            }
            eventHappened = false;
        }
    }

    private bool IsPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    private void AnimalAttack()
    {
        
        float victoryChance = 50f;
        float randomNumberGenerated = UnityEngine.Random.Range(0f, 100f);
        if (randomNumberGenerated <= victoryChance)
        {
            NotableEvent("You've been attacked by an animal. But your people managed to kill it! You've gained # Food");
        }
        else
        {
            NotableEvent("You've been attacked by an animal. One of your people has been killed.");
        }
        

        // Here we should roll another dice to see if the player can kill the animal or not.
        // If killed gets a random amount of food between generous values.
        // If the player can't kill the animal then a worker dies or multiple.
    }
    private void GenerateWorkers()
    {
        if (Worker.AvailableWorkerCount < MakeshiftBed.SelfCount)
        {
            if ((Timer -= Time.deltaTime) <= 0)
            {
                Timer = MaxValue;

                Worker.AvailableWorkerCount++;
                NotableEvent("A worker has arrived");
                txtAvailableWorkers.text = string.Format("Available Workers: [{0}]", Worker.AvailableWorkerCount);
            }
        }
    }

    private void NotableEvent(string notableEventString)
    {
        // Write to a history log whenever something notable happens. 
        _currentHistoryLog = txtHistoryLog.text;
        if (_currentHistoryLog == "")
        {
            txtHistoryLog.text = string.Format("{0}<b>{1:t}</b>: {2}", _currentHistoryLog, DateTime.Now, notableEventString);
        }
        else
        {
            txtHistoryLog.text = string.Format("{0}\n<b>{1:t}</b>: {2}", _currentHistoryLog, DateTime.Now, notableEventString);
            Canvas.ForceUpdateCanvases();
            scrollViewObject.GetComponent<UnityEngine.UI.ScrollRect>().verticalNormalizedPosition = 0f;

        }

        txtNotificationText.text = string.Format("<b>{0:t}</b> {1}", DateTime.Now, notableEventString);
    }
    private void Update()
    {
        if ((_timer -= Time.deltaTime) <= 0)
        {
            _timer = maxValue;
            StoneAgeEvents();
            
        }

        GenerateWorkers();
    }
}
