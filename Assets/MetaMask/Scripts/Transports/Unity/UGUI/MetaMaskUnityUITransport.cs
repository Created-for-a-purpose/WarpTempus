using System;
using MetaMask.Models;
using MetaMask.SocketIOClient;
using MetaMask.Unity;
using UnityEngine;
using UnityEngine.Serialization;

namespace MetaMask.Transports.Unity.UI
{

    [CreateAssetMenu(menuName = "MetaMask/Transports/Unity UI")]
    public class MetaMaskUnityUITransport : MetaMaskUnityScriptableObjectTransport
    {

        #region Events
        /// <summary>Raised when the application is disconnecting to the wallet.</summary>
        public override event EventHandler<MetaMaskUnityRequestEventArgs> Requesting;

        #endregion

        #region Constants

        /// <summary>The path to the transports resource folder.</summary>
        protected const string ResourcePath = "MetaMask/Transports";
        /// <summary>The default resource path for Unity UI resources.</summary>
        /// <remarks>This is the default resource path for Unity UI resources. It is used when the <see cref="ResourcePath"/> property is not set.</remarks>
        protected const string DefaultResourcePath = ResourcePath + "/UnityUI";

        #endregion

        #region Fields

        /// <summary>The default instance.</summary>
        protected static MetaMaskUnityUITransport defaultInstance;

        /// <summary>The user agent to use when making requests.</summary>
        /// <remarks>This is used to identify the application when making requests.</remarks>
        [SerializeField]
        protected string userAgent = "UnityUGUITransport/1.0.0";
        /// <summary>Whether to use the deeplink to open the app.</summary>
        /// <remarks>This is only used when the app is launched from a deeplink.</remarks>
        //[FormerlySerializedAs("useDeeplink")] [SerializeField]
        //protected bool _useDeeplink = false;
        /// <summary>Whether to spawn a canvas on startup.</summary>
        [SerializeField]
        protected bool spawnCanvas = false;
        /// <summary>The canvas that contains the MetaMask UI.</summary>
        [SerializeField]
        protected GameObject metaMaskCanvas;

        /// <summary>The instance of the MetaMask canvas.</summary>
        protected GameObject metaMaskCanvasInstance;
        /// <summary>The UI handler for the MetaMask Unity plugin.</summary>
        protected MetaMaskUnityUIHandler uiHandler;

        protected string connectionDeepLinkUrl;
        protected string connectionUniversalLinkUrl;

        #endregion

        #region Properties

        /// <summary>The default instance of the <see cref="MetaMaskUnityUITransport"/> class.</summary>
        public static MetaMaskUnityUITransport DefaultInstance
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = Resources.Load<MetaMaskUnityUITransport>(DefaultResourcePath);
                }
                return defaultInstance;
            }
        }

        /// <summary>Gets the user agent string.</summary>
        /// <returns>The user agent string.</returns>
        public override string UserAgent
        {
            get
            {
                return this.userAgent;
            }
        }
        
        public bool UseDeeplink => IsMobile;

        #endregion

        #region Public Methods

        /// <summary>Initializes the transport manager.</summary>
        public override void Initialize()
        {
            if (this.spawnCanvas)
            {
                this.metaMaskCanvasInstance = Instantiate(this.metaMaskCanvas);
                this.uiHandler = this.metaMaskCanvasInstance.GetComponent<MetaMaskUnityUIHandler>();
            }
            
            MetaMaskUnity.Instance.Events.StartConnecting += WalletOnStartConnecting;
        }

        private void WalletOnStartConnecting(object sender, MetaMaskConnectEventArgs e)
        {
            var universalLink = this.connectionUniversalLinkUrl;
            var deepLink = this.connectionDeepLinkUrl;
            
            
            if (this.uiHandler != null)
            {
                this.uiHandler.OpenQRCode();
            }
            
            EmitListenerEvent(l => l.OnMetaMaskConnectRequest(universalLink, deepLink));
            
            MetaMaskUnityTransportBroadcaster.Instance.OnMetaMaskConnectRequest(universalLink, deepLink);
        }

        /// <summary>Connects to the specified URL.</summary>
        /// <param name="url">The URL to connect to.</param>
        public override void UpdateUrls(string universalLink, string deepLink)
        {
            this.connectionDeepLinkUrl = deepLink;
            this.connectionUniversalLinkUrl = universalLink;
            
        }

        public override void OnConnectRequest()
        {
            if (UseDeeplink)
            {
                OpenConnectionDeepLink();
            }
        }

        public void OpenConnectionDeepLink()
        {
            Debug.Log("Opening Connection URL: " + this.connectionUniversalLinkUrl);
            OpenDeeplinkURL(this.connectionUniversalLinkUrl);
        }

        /// <summary>Called when the application fails to retrieve the content of the request.</summary>
        /// <param name="error">The exception that occurred.</param>
        public override void OnFailure(Exception error)
        {
            Debug.LogError("On Failure: " + error);

            EmitListenerEvent(l => l.OnMetaMaskFailure(error));
            
            MetaMaskUnityTransportBroadcaster.Instance.OnMetaMaskFailure(error);
        }

        /// <summary>Called when a request is received.</summary>
        /// <param name="id">The request ID.</param>
        /// <param name="request">The request.</param>
        public override void OnRequest(string id, MetaMaskEthereumRequest request)
        {
            Requesting?.Invoke(this, new MetaMaskUnityRequestEventArgs(request));
            
            if (UseDeeplink)
            {
                // Use otp to re-enable host approval
                OpenConnectionDeepLink();
                //OpenDeeplinkURL(MetaMaskWallet.MetaMaskUniversalLinkUrl);
            }
            
            EmitListenerEvent(l => l.OnMetaMaskRequest(id, request));

            MetaMaskUnityTransportBroadcaster.Instance.OnMetaMaskRequest(id, request);
        }

        public override void OnOTPCode(int code)
        {
            if (this.uiHandler != null)
            {
                this.uiHandler.OnMetaMaskOTP(code);
            }
        }

        /// <summary>Notifies the application that a new session has been created.</summary>        
        /// <param name="session">The session that has been created.</param>
        public override void OnSessionRequest(MetaMaskSessionData session)
        {
        }

        /// <summary>Called when the MetaMask client has successfully connected to the Ethereum network.</summary>
        public override void OnSuccess()
        {
            EmitListenerEvent(l => l.OnMetaMaskSuccess());

            MetaMaskUnityTransportBroadcaster.Instance.OnMetaMaskSuccess();
        }

        public override void OnDisconnect()
        {
            EmitListenerEvent(l => l.OnMetaMaskDisconnected());
        }

        /// <summary>Returns wheter deeplinking is available on the client.</summary>
        public bool IsDeeplinkAvailable()
        {
            return UseDeeplink;
        }

        #endregion

        #region Private Methods

        private void EmitListenerEvent(Action<IMetaMaskUnityTransportListener> callback)
        {
            if (this.metaMaskCanvasInstance)
            {
                UnityThread.executeInUpdate(() =>
                {
                    var listeners =
                        this.metaMaskCanvasInstance.GetComponentsInChildren<IMetaMaskUnityTransportListener>();
                    for (int i = 0; i < listeners.Length; i++)
                    {
                        callback(listeners[i]);
                    }
                });
            }
        }

        #endregion
    }

}