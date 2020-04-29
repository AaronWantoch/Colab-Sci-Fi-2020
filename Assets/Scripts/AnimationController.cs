using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    NavMeshAgent _agent;
    ThirdPersonCharacter _character;
    Animator _animator;

    int _isWalkingHash = Animator.StringToHash("isWalking");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.speed > 0)
            _animator.SetBool(_isWalkingHash, true);
        else
            _animator.SetBool(_isWalkingHash, false);

    }
}
