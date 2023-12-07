using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    
    [SerializeField]
    private TMPro.TextMeshProUGUI firstMin;
    [SerializeField]
    public TextMeshProUGUI secondMin;
    [SerializeField]
    public TextMeshProUGUI seperator;
    [SerializeField]
    public TextMeshProUGUI firstSec;
    [SerializeField]
    public TextMeshProUGUI secondSec;
    
    public float timeStart = 0;
    public float timer;
    private float flashTimer;
    private float flashDuration = 1f;
    [SerializeField]
    private bool countDown = true;
    private float timeDuration = 3000f;


    private void Start()
    {
        // Starts the timer automatically

        timerIsRunning = true;
        ResetTimer();
    }

    void Update()
    {

           if(countDown && timer > 0 ){

                timer -= Time.deltaTime;
                UpdateTimer(timer);
            }else if(!countDown && timer < timeDuration){
                timer += Time.deltaTime;
                UpdateTimer(timer);

            }else{
                Flash();
            }
            
    }
            

/*
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
*/
    public void ResetTimer(){
        if(countDown){
            timer = timeDuration;
        }else{
       timer= 0;
        }
        SetTextDisplay(true);
    }

    public void UpdateTimer(float time){
        float minute = Mathf.FloorToInt(time/60);
        float seconds = Mathf.FloorToInt(time %60);

        string currentTime = string.Format("{00:00}{1:00}", minute, seconds);
        
        firstMin.text =  currentTime[0].ToString();
        secondMin.text = currentTime[1].ToString();
        firstSec.text = currentTime[2].ToString();
        secondSec.text = currentTime[3].ToString();
    }
    public void Flash(){
        if(timer != 0){
            timer = 0;
            UpdateTimer(timer);
        }

        if(flashTimer <=0){
            flashTimer = flashDuration;
            }else if(flashTimer >= flashDuration /2){
                flashTimer -= Time.deltaTime;
                SetTextDisplay(false);
            }else{
                flashTimer -= Time.deltaTime;
                SetTextDisplay(false);
            }
        
    }

    private void SetTextDisplay(bool enabled){
        firstMin.enabled = enabled;
        secondMin.enabled = enabled;
        firstSec.enabled = enabled;
        secondSec.enabled = enabled;
    }
    
}