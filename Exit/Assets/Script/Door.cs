using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
  private Animator _animator;
  [Header("Sound")]
    [SerializeField] public AudioSource Gate;
        

  private void Awake()
  {
    _animator = GetComponent<Animator>();

  }
[ContextMenu(itemName:"Open")]
public void Open()
{
    _animator.SetTrigger(name:"Open");
Gate.Play();
}

}
