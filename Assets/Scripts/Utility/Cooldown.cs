using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown   
{
    private float duration = 0f;//Maximum duration of a timer
    private float completeTime = 0f;



    public Cooldown(float duration){
        this.duration = duration;
        completeTime = 0;
    }
    
    public void startCooldown(){
        completeTime = Time.time + duration;
    }
    public bool IsReady(){
        return Time.time > completeTime;
    }
}
