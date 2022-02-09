// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""id"": ""b61fb882-6f72-4ee3-b79e-a81a15330406"",
            ""actions"": [
                {
                    ""name"": ""MoveCursor"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5696908d-2fec-4f2f-8893-5f114eb2a08b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sell"",
                    ""type"": ""Value"",
                    ""id"": ""6b46166b-1764-40a9-a591-707f4a492d9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RefreshShop"",
                    ""type"": ""Value"",
                    ""id"": ""7f7d283a-ed0c-4a8b-92e0-2a88174cee92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F In Chat"",
                    ""type"": ""Value"",
                    ""id"": ""ef1e330d-439a-4e3f-aebd-693768535897"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""baf7751f-fa32-495f-9e6c-5bc311432840"",
                    ""expectedControlType"": ""Integer"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e491f393-b31d-4eb7-94a2-5d099cec9be3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4d562dff-cfbe-4045-a12e-40a04aa24c95"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65f867f4-88c9-44d4-8066-8d36a57d6471"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8f55b3c-d666-42dd-86d4-8d80eaeda6ad"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RefreshShop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae28dff8-6067-4faa-8641-5cd8f812c303"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F In Chat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7732557c-e7d4-4d41-8467-e96b70c4a23f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Left Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0391858-0030-4edf-8fd6-3872173eefb2"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Right Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // KeyboardAndMouse
        m_KeyboardAndMouse = asset.FindActionMap("KeyboardAndMouse", throwIfNotFound: true);
        m_KeyboardAndMouse_MoveCursor = m_KeyboardAndMouse.FindAction("MoveCursor", throwIfNotFound: true);
        m_KeyboardAndMouse_Sell = m_KeyboardAndMouse.FindAction("Sell", throwIfNotFound: true);
        m_KeyboardAndMouse_RefreshShop = m_KeyboardAndMouse.FindAction("RefreshShop", throwIfNotFound: true);
        m_KeyboardAndMouse_FInChat = m_KeyboardAndMouse.FindAction("F In Chat", throwIfNotFound: true);
        m_KeyboardAndMouse_LeftClick = m_KeyboardAndMouse.FindAction("Left Click", throwIfNotFound: true);
        m_KeyboardAndMouse_RightClick = m_KeyboardAndMouse.FindAction("Right Click", throwIfNotFound: true);
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

    // KeyboardAndMouse
    private readonly InputActionMap m_KeyboardAndMouse;
    private IKeyboardAndMouseActions m_KeyboardAndMouseActionsCallbackInterface;
    private readonly InputAction m_KeyboardAndMouse_MoveCursor;
    private readonly InputAction m_KeyboardAndMouse_Sell;
    private readonly InputAction m_KeyboardAndMouse_RefreshShop;
    private readonly InputAction m_KeyboardAndMouse_FInChat;
    private readonly InputAction m_KeyboardAndMouse_LeftClick;
    private readonly InputAction m_KeyboardAndMouse_RightClick;
    public struct KeyboardAndMouseActions
    {
        private @PlayerInput m_Wrapper;
        public KeyboardAndMouseActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveCursor => m_Wrapper.m_KeyboardAndMouse_MoveCursor;
        public InputAction @Sell => m_Wrapper.m_KeyboardAndMouse_Sell;
        public InputAction @RefreshShop => m_Wrapper.m_KeyboardAndMouse_RefreshShop;
        public InputAction @FInChat => m_Wrapper.m_KeyboardAndMouse_FInChat;
        public InputAction @LeftClick => m_Wrapper.m_KeyboardAndMouse_LeftClick;
        public InputAction @RightClick => m_Wrapper.m_KeyboardAndMouse_RightClick;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardAndMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardAndMouseActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardAndMouseActions instance)
        {
            if (m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface != null)
            {
                @MoveCursor.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnMoveCursor;
                @MoveCursor.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnMoveCursor;
                @MoveCursor.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnMoveCursor;
                @Sell.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnSell;
                @Sell.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnSell;
                @Sell.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnSell;
                @RefreshShop.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnRefreshShop;
                @RefreshShop.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnRefreshShop;
                @RefreshShop.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnRefreshShop;
                @FInChat.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnFInChat;
                @FInChat.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnFInChat;
                @FInChat.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnFInChat;
                @LeftClick.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnLeftClick;
                @RightClick.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnRightClick;
            }
            m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveCursor.started += instance.OnMoveCursor;
                @MoveCursor.performed += instance.OnMoveCursor;
                @MoveCursor.canceled += instance.OnMoveCursor;
                @Sell.started += instance.OnSell;
                @Sell.performed += instance.OnSell;
                @Sell.canceled += instance.OnSell;
                @RefreshShop.started += instance.OnRefreshShop;
                @RefreshShop.performed += instance.OnRefreshShop;
                @RefreshShop.canceled += instance.OnRefreshShop;
                @FInChat.started += instance.OnFInChat;
                @FInChat.performed += instance.OnFInChat;
                @FInChat.canceled += instance.OnFInChat;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
            }
        }
    }
    public KeyboardAndMouseActions @KeyboardAndMouse => new KeyboardAndMouseActions(this);
    public interface IKeyboardAndMouseActions
    {
        void OnMoveCursor(InputAction.CallbackContext context);
        void OnSell(InputAction.CallbackContext context);
        void OnRefreshShop(InputAction.CallbackContext context);
        void OnFInChat(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
    }
}
