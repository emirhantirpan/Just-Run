using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTimer : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] Player _player;
    
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_player._work == true)
        {
             _anim.SetBool("isTrigger", true);
        }
        else
        {
            Wait();
            _anim.SetBool("isTrigger", false);
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
    
    
}

