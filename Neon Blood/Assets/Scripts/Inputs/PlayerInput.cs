// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/PlayerInput.inputactions'

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
            ""name"": ""Player"",
            ""id"": ""782ceab4-616b-419c-9efe-0df6d0fd9e5e"",
            ""actions"": [
                {
                    ""name"": ""ShootStart"",
                    ""type"": ""Button"",
                    ""id"": ""e6dc50d9-aa0d-4e2a-8c5c-207c8d064330"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootStop"",
                    ""type"": ""Button"",
                    ""id"": ""5067504b-8f76-4b0a-a78c-f9773298b4af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZoomStart"",
                    ""type"": ""Button"",
                    ""id"": ""d4657ab8-eb05-405a-a3db-63031308c586"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZoomEnd"",
                    ""type"": ""Button"",
                    ""id"": ""bf76cbec-d016-4f7d-8ace-b3bb0b3f499a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CrouchStart"",
                    ""type"": ""Button"",
                    ""id"": ""1c5efbf9-0446-490c-acd0-d359157a6a62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CrouchEnd"",
                    ""type"": ""Button"",
                    ""id"": ""217dce8c-6f8c-4786-a8ef-108e153e892d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SprintStart"",
                    ""type"": ""Button"",
                    ""id"": ""60d3884e-2323-4e2c-afa1-20278d9377a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SprintStop"",
                    ""type"": ""Button"",
                    ""id"": ""deb88f17-20dc-4858-910a-0d649578a7e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9cb37b89-88d6-4721-b2f0-ec13c6033e16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""5e694c27-da36-4dc0-8343-e2a1d25ef116"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d950edf0-366f-4180-ad4e-e1c3fd41b440"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""Value"",
                    ""id"": ""ac565ae3-7999-46b9-9384-bb4cf2f0b048"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ControllerLook"",
                    ""type"": ""Button"",
                    ""id"": ""2edd67dc-7a0f-4f3f-b0b7-7e9adcdaef08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f08b9bd7-e74e-43b1-8c5c-81247a6ae248"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""ShootStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3224f6a2-f13d-4b6c-830a-9a5044bcc0fe"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ShootStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD Keys"",
                    ""id"": ""7dc361c1-b68c-404a-aeb3-999fe838ca2d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e00381a4-5665-4a70-add0-385d73c1c000"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6611f5c5-667f-4680-b44e-8049843a576b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""60498470-ef1f-455f-9e69-c99ee92e337f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""830ef812-e3d2-402b-930d-a0baaf106d54"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left Thumbstick"",
                    ""id"": ""e8ca70f5-9061-495a-88f8-bcde2a7bc70a"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""302a997e-a1b2-45ce-932d-2d647499c797"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fd515a1f-9e09-4176-b340-8720296ae9df"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2614a95a-3cc8-4153-9d3a-087f89e5cf16"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d29eed83-436a-481d-a07b-3ac74aec16a2"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5b3d464d-2bab-4f41-8836-155bec866e2e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""ZoomStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afe94bc6-ba5d-4855-991b-0b1bfbc88b7b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ZoomStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50019730-bfb5-4a17-b4f9-43d30db32f72"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a93ca97d-05a6-44b4-bb6e-731ea0f03637"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a55017e-2619-4f72-81a2-adf91d96b292"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa53d3ef-f2a8-4b0f-866a-b41f1ea76430"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""CrouchStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1f03345-169d-4643-862d-e2d552f9bf2c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CrouchStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Right Thumbstick"",
                    ""id"": ""588ae8b1-7ed8-4e29-9dc0-1a2e19afeaf7"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerLook"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""00376418-2abd-4360-ad17-b37f5e33e01b"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ControllerLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b240282e-08fb-425e-ae8e-35a074df194e"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ControllerLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6888638f-1f9c-4aba-94f7-a55f76a0dd37"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ControllerLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""29c7d408-0168-43d0-8d37-4c4c07f00991"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ControllerLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7bbfcfa6-0c0e-4c68-b4cd-ced3a5508dd2"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""ZoomEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86004a53-aeac-484a-b69f-0c9ac4bbe7b3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ZoomEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fce2e5d4-9393-4b71-8398-842b75734a6b"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""CrouchEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45d14ff3-fac2-4f61-9f85-937da41c8702"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CrouchEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2071f31-b18b-4b91-a603-138ce743921a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cac81cd3-3311-413f-bc55-6f9623213965"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52713210-36ab-4778-a131-e7b246954418"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""SprintStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfb6670d-1d00-4e98-937a-78862fd1a2ca"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SprintStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""902d4db0-9158-4bba-a176-ce6d6ae983c0"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""SprintStop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bca5db2-f967-442f-a555-38a87feee52a"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""SprintStop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a501745-263e-4552-bdcd-08c3430d80fa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""ShootStop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3de57345-0468-40fd-a946-76d8dc6a629d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ShootStop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse&Keyboard"",
            ""bindingGroup"": ""Mouse&Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_ShootStart = m_Player.FindAction("ShootStart", throwIfNotFound: true);
        m_Player_ShootStop = m_Player.FindAction("ShootStop", throwIfNotFound: true);
        m_Player_ZoomStart = m_Player.FindAction("ZoomStart", throwIfNotFound: true);
        m_Player_ZoomEnd = m_Player.FindAction("ZoomEnd", throwIfNotFound: true);
        m_Player_CrouchStart = m_Player.FindAction("CrouchStart", throwIfNotFound: true);
        m_Player_CrouchEnd = m_Player.FindAction("CrouchEnd", throwIfNotFound: true);
        m_Player_SprintStart = m_Player.FindAction("SprintStart", throwIfNotFound: true);
        m_Player_SprintStop = m_Player.FindAction("SprintStop", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_MouseLook = m_Player.FindAction("MouseLook", throwIfNotFound: true);
        m_Player_ControllerLook = m_Player.FindAction("ControllerLook", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_ShootStart;
    private readonly InputAction m_Player_ShootStop;
    private readonly InputAction m_Player_ZoomStart;
    private readonly InputAction m_Player_ZoomEnd;
    private readonly InputAction m_Player_CrouchStart;
    private readonly InputAction m_Player_CrouchEnd;
    private readonly InputAction m_Player_SprintStart;
    private readonly InputAction m_Player_SprintStop;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_MouseLook;
    private readonly InputAction m_Player_ControllerLook;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ShootStart => m_Wrapper.m_Player_ShootStart;
        public InputAction @ShootStop => m_Wrapper.m_Player_ShootStop;
        public InputAction @ZoomStart => m_Wrapper.m_Player_ZoomStart;
        public InputAction @ZoomEnd => m_Wrapper.m_Player_ZoomEnd;
        public InputAction @CrouchStart => m_Wrapper.m_Player_CrouchStart;
        public InputAction @CrouchEnd => m_Wrapper.m_Player_CrouchEnd;
        public InputAction @SprintStart => m_Wrapper.m_Player_SprintStart;
        public InputAction @SprintStop => m_Wrapper.m_Player_SprintStop;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @MouseLook => m_Wrapper.m_Player_MouseLook;
        public InputAction @ControllerLook => m_Wrapper.m_Player_ControllerLook;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @ShootStart.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootStart;
                @ShootStart.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootStart;
                @ShootStart.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootStart;
                @ShootStop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootStop;
                @ShootStop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootStop;
                @ShootStop.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootStop;
                @ZoomStart.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomStart;
                @ZoomStart.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomStart;
                @ZoomStart.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomStart;
                @ZoomEnd.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomEnd;
                @ZoomEnd.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomEnd;
                @ZoomEnd.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomEnd;
                @CrouchStart.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouchStart;
                @CrouchStart.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouchStart;
                @CrouchStart.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouchStart;
                @CrouchEnd.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouchEnd;
                @CrouchEnd.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouchEnd;
                @CrouchEnd.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouchEnd;
                @SprintStart.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintStart;
                @SprintStart.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintStart;
                @SprintStart.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintStart;
                @SprintStop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintStop;
                @SprintStop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintStop;
                @SprintStop.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintStop;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @MouseLook.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseLook;
                @ControllerLook.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnControllerLook;
                @ControllerLook.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnControllerLook;
                @ControllerLook.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnControllerLook;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ShootStart.started += instance.OnShootStart;
                @ShootStart.performed += instance.OnShootStart;
                @ShootStart.canceled += instance.OnShootStart;
                @ShootStop.started += instance.OnShootStop;
                @ShootStop.performed += instance.OnShootStop;
                @ShootStop.canceled += instance.OnShootStop;
                @ZoomStart.started += instance.OnZoomStart;
                @ZoomStart.performed += instance.OnZoomStart;
                @ZoomStart.canceled += instance.OnZoomStart;
                @ZoomEnd.started += instance.OnZoomEnd;
                @ZoomEnd.performed += instance.OnZoomEnd;
                @ZoomEnd.canceled += instance.OnZoomEnd;
                @CrouchStart.started += instance.OnCrouchStart;
                @CrouchStart.performed += instance.OnCrouchStart;
                @CrouchStart.canceled += instance.OnCrouchStart;
                @CrouchEnd.started += instance.OnCrouchEnd;
                @CrouchEnd.performed += instance.OnCrouchEnd;
                @CrouchEnd.canceled += instance.OnCrouchEnd;
                @SprintStart.started += instance.OnSprintStart;
                @SprintStart.performed += instance.OnSprintStart;
                @SprintStart.canceled += instance.OnSprintStart;
                @SprintStop.started += instance.OnSprintStop;
                @SprintStop.performed += instance.OnSprintStop;
                @SprintStop.canceled += instance.OnSprintStop;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
                @ControllerLook.started += instance.OnControllerLook;
                @ControllerLook.performed += instance.OnControllerLook;
                @ControllerLook.canceled += instance.OnControllerLook;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse&Keyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnShootStart(InputAction.CallbackContext context);
        void OnShootStop(InputAction.CallbackContext context);
        void OnZoomStart(InputAction.CallbackContext context);
        void OnZoomEnd(InputAction.CallbackContext context);
        void OnCrouchStart(InputAction.CallbackContext context);
        void OnCrouchEnd(InputAction.CallbackContext context);
        void OnSprintStart(InputAction.CallbackContext context);
        void OnSprintStop(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnMouseLook(InputAction.CallbackContext context);
        void OnControllerLook(InputAction.CallbackContext context);
    }
}
