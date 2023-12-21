using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //####################### SERIALIZED FIELDS #################################
    [SerializeField] private PlayerInput _playerInput;

    private InputActionMap _currentMap;

    private InputAction _moveAction;
    private InputAction _abilityConfOrAttack;
    private InputAction _abilitytOne;
    private InputAction _abilitytTwo;
    private InputAction _abilitytThree;
    private InputAction _abilitytFour;

    public Vector2 Move { get; private set; }
    public Vector2 Look { get; private set; }
    public bool AbilityOne { get; private set; }
    public bool AbilityTwo { get; private set; }
    public bool AbilityThree { get; private set; }
    public bool AbilityFour { get; private set; }

    private void Awake()
    {
        _currentMap = _playerInput.currentActionMap;

        _moveAction = _currentMap.FindAction("Move");
        _abilityConfOrAttack = _currentMap.FindAction("AbilityConfirmOrAttack");
        _abilitytOne = _currentMap.FindAction("AbilityOne");
        _abilitytTwo = _currentMap.FindAction("AbilityTwo");
        _abilitytThree = _currentMap.FindAction("AbilityThree");
        _abilitytFour = _currentMap.FindAction("AbilityFour");

        _moveAction.performed += OnMove;
        _abilityConfOrAttack.performed += OnAttack;
        _abilitytOne.performed += OnAbilityOne;
        _abilitytTwo.performed += OnAbilityTwo;
        _abilitytThree.performed += OnAbilityThree;
        _abilitytFour.performed += OnAbilityFour;

        _moveAction.canceled += OnMove;
        _abilityConfOrAttack.canceled += OnAttack;
        _abilitytOne.canceled += OnAbilityOne;
        _abilitytTwo.canceled += OnAbilityTwo;
        _abilitytThree.canceled += OnAbilityThree;
        _abilitytFour.canceled += OnAbilityFour;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }

    private void OnAttack(InputAction.CallbackContext context) 
    {
        Look = context.ReadValue<Vector2>();
    }

    private void OnAbilityOne(InputAction.CallbackContext context)
    {
        AbilityOne = true;
        AbilityTwo = false;
        AbilityThree = false;
        AbilityFour = false;
    }

    private void OnAbilityTwo(InputAction.CallbackContext context) 
    {
        AbilityOne = false;
        AbilityTwo = true;
        AbilityThree = false;
        AbilityFour = false;
    }

    private void OnAbilityThree(InputAction.CallbackContext context)
    {
        AbilityOne = false;
        AbilityTwo = false;
        AbilityThree = true;
        AbilityFour = false;
    }

    private void OnAbilityFour(InputAction.CallbackContext context)
    {
        AbilityOne = false;
        AbilityTwo = false;
        AbilityThree = false;
        AbilityFour = true;
    }
}
