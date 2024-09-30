using System.Collections;
using Environment;
using UnityEngine;

public class SkillManager : MonoBehaviour{
    enum Skills {Shield, Speed}
    [SerializeField] EnvironmentManager EnvironmentManager;//Insert the environment manager to this

    private float _powerupDuration = 6f;
    private bool _isProtected = false;

    [SerializeField] private Skills _currentSkill;

    public void ActivateSkill(){
        switch(_currentSkill){
            case Skills.Shield:
                StartCoroutine(ShieldPower());
                break;
            case Skills.Speed:
                StartCoroutine(SpeedBoost());
                break;
            default:
                break;
        }
    }
    IEnumerator ShieldPower(){
        _isProtected = true;
        yield return new WaitForSeconds(_powerupDuration);
        _isProtected = false;
    }
    IEnumerator SpeedBoost(){
        EnvironmentManager.InitiateSpeedBoost();
        yield return new WaitForSeconds(_powerupDuration);
        EnvironmentManager.CancelSpeedBoost();
    }
}