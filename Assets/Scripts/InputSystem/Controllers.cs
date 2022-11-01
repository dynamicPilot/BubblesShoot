//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputSystem/Controllers.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controllers : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controllers()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controllers"",
    ""maps"": [
        {
            ""name"": ""PlayerActions"",
            ""id"": ""f6c133a2-5951-4f5e-a1db-cf64d743b9f8"",
            ""actions"": [
                {
                    ""name"": ""PositionAction"",
                    ""type"": ""Value"",
                    ""id"": ""0f01df02-9ca6-4866-939c-44fe1a441c47"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ContactAction"",
                    ""type"": ""Button"",
                    ""id"": ""28403f4f-db69-4d53-8bdc-466d721e094a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c0e5d242-9f10-4f34-9cf6-c02b6448f0bc"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PositionAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa55d17b-abbe-4f49-a61d-022aa4df89ba"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PositionAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e62f3f4-b021-49ca-a4ed-d49155d9a6e6"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ContactAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2353f800-a3ad-4dec-8fd7-dfe1063708bf"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ContactAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_PositionAction = m_PlayerActions.FindAction("PositionAction", throwIfNotFound: true);
        m_PlayerActions_ContactAction = m_PlayerActions.FindAction("ContactAction", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_PositionAction;
    private readonly InputAction m_PlayerActions_ContactAction;
    public struct PlayerActionsActions
    {
        private @Controllers m_Wrapper;
        public PlayerActionsActions(@Controllers wrapper) { m_Wrapper = wrapper; }
        public InputAction @PositionAction => m_Wrapper.m_PlayerActions_PositionAction;
        public InputAction @ContactAction => m_Wrapper.m_PlayerActions_ContactAction;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @PositionAction.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnPositionAction;
                @PositionAction.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnPositionAction;
                @PositionAction.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnPositionAction;
                @ContactAction.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnContactAction;
                @ContactAction.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnContactAction;
                @ContactAction.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnContactAction;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PositionAction.started += instance.OnPositionAction;
                @PositionAction.performed += instance.OnPositionAction;
                @PositionAction.canceled += instance.OnPositionAction;
                @ContactAction.started += instance.OnContactAction;
                @ContactAction.performed += instance.OnContactAction;
                @ContactAction.canceled += instance.OnContactAction;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);
    public interface IPlayerActionsActions
    {
        void OnPositionAction(InputAction.CallbackContext context);
        void OnContactAction(InputAction.CallbackContext context);
    }
}