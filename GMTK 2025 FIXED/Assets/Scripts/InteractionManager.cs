using System;
using UnityEditor.Rendering;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance { get; private set; }
    private InputSystem_Actions InpSysActions;
    public event EventHandler OnInteract;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        InpSysActions = new InputSystem_Actions();
        InpSysActions.Enable();
        InpSysActions.Player.Enable();
        InpSysActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteract?.Invoke(this, EventArgs.Empty);
    }
}
