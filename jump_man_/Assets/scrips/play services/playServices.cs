using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using TMPro;
using UnityEngine.UI;
using Unity.Services.Authentication;
using System;
using System.Threading.Tasks;
using Unity.Services.Core;

public class playServices : MonoBehaviour
{ /// <summary>
  /// //////////////// jump man services 
  /// </summary>
    public bool connetedagoogleplay;  // v11
                                      //public MonedasCasinoManager monedas_puntuacion;
    public float puntuacion;
    public TextMeshProUGUI autenticado;
    public TextMeshProUGUI iniciosucess;
    //private PlayGamesClientConfiguration clientConfiguration;
    // private PlayGamesPlatform inicio; 
    // [SerializeField] GameObject learboardaaa; 
    public string Token;
    public string Error;
    private void Awake()
    {

        PlayGamesPlatform.DebugLogEnabled = true; // v11.0
        PlayGamesPlatform.Activate();  // v11.0    esto  hace que google se mi plataforma predeterminda 
                                       //inicio = new IPlayGamesClient
                                       //playGamesPlatform.InitializeNearby
                                       //inicio.CreateLeaderboard();
                                       //Social.CreateLeaderboard();
        autenticado.text = "ja".ToString();
        // PlayGamesPlatform.Instance.RequestServerSideAccess()

        //  PlayGamesPlatform.Instance.AddIdMapping("My Leaderboard", GPGSIds.leaderboard_papus_topgg);
        //Social.Active.ShowLeaderboardUI();
    }
    // Start is called before the first frame update
    async void Start()
    {

        autenticado.text = "ja".ToString();
        //PlayGamesPlatform.Instance.RequestServerSideAccess( false,code-> {});
        //PlayGamesPlatform.Instance.RequestServerSideAccess(true, code => { });
        await UnityServices.InitializeAsync();
        //iniciar_seccion(); // v11.0
        await LoginGooglePlayGames();
        await SignInWithGooglePlayGamesAsync(Token);

    }
    /*  public Task iniciar_seccion()  // v11.0
      {
          Debug.Log("intentando iniciar ");
         // PlayGamesPlatform.DebugLogEnabled = true;
          PlayGamesPlatform.Instance.Authenticate(procesodAautenticacion);  // v11.0}*/
    public Task LoginGooglePlayGames()
    {
        var tcs = new TaskCompletionSource<object>();  /// que es esto??????
        PlayGamesPlatform.Instance.Authenticate((success) =>  /// esto es una funcion ???
        {
            if (success == SignInStatus.Success)  /// si esta autenticado 
            {
                connetedagoogleplay = true;
                Debug.Log("Login with Google Play games successful.");
                PlayGamesPlatform.Instance.RequestServerSideAccess(true, code =>
                {
                    autenticado.text = "autenticado".ToString();
                    Debug.Log("Authorization code: " + code);
                    Token = code;
                    // This token serves as an example to be used for SignInWithGooglePlayGames
                    tcs.SetResult(null);
                    autenticado.text = "autenticacion exitosa ".ToString();
                    //  await SignInWithGooglePlayGamesAsync(Token);
                });
            }
            else
            {
                connetedagoogleplay = false;
                Error = "Failed to retrieve Google play games authorization code";
                Debug.Log("Login Unsuccessful");
                tcs.SetException(new Exception("Failed"));
                autenticado.text = "fallo autenticacion".ToString();
            }
        });
        return tcs.Task;
    }
    async Task SignInWithGooglePlayGamesAsync(string authCode)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithGooglePlayGamesAsync(authCode); // ESTA PIDEINDO EL TOKEN 
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}"); //Display the Unity Authentication PlayerID
            Debug.Log("SignIn is successful.");
            iniciosucess.text = "inicio esxitos";
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
            iniciosucess.text = "inicio fallido" + ex;
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
            iniciosucess.text = "inicio fallido" + ex;
        }
    }
    public void inicioManual()
    {
        if (!connetedagoogleplay)
        {
            PlayGamesPlatform.Instance.ManuallyAuthenticate(authResult =>
            {
                if (authResult == SignInStatus.Success) { PlayGamesPlatform.Instance.RequestServerSideAccess(true, code => { }); iniciosucess.text = "inicio manuale exitoso"; }
                else
                {
                    iniciosucess.text = "fallido manual" + authResult.ToString();

                    //autenticacioninformacion(false);
                }
            });
        }
    }
    public void procesodAautenticacion(SignInStatus status) // v11.0
    {
        if (status == SignInStatus.Success)
        {
            connetedagoogleplay = true;
            // /PlayGamesPlatform.Instance.RequestServerSideAccess({true,code->});
            //PlayGamesPlatform.Instance.RequestServerSideAccess(true, code => { });
            autenticado.text = "autenticado".ToString();
            Debug.Log("lora de felizidada ");

        }
        else
        {
            connetedagoogleplay = false;
            autenticado.text = "fail autenticado".ToString();
            // PlayGamesPlatform.Instance.
            /// PlayGamesPlatform.Instance.ManuallyAuthenticate(procesodAautenticacion);


        }


    }
    public void enviarpuntuacion()  // v11.0
    {
        Debug.Log("ENVIAR ");
        if (connetedagoogleplay)
        {
            Debug.Log("COMPROBADAD Y EVIADA "); // v11.0
                                                //   puntuacion = monedas_puntuacion.monedasdata; // v11.0
            Social.ReportScore((long)puntuacion, "CggIjZ3YqgcQAhAB", succes => { });  // cuando llamamos este metodo  actualiza la puntuacion  de la tabla  // v11.0
                                                                                      // Social.ReportScore((long)puntuacion, GPGSIds.leaderboard_papus, leaderboardUpdate);  // v11.0


        }
        else
        {
            LoginGooglePlayGames();
        }
    }
    public void leaderboardUpdate(bool success)  // v11.0
    {
        if (success) Debug.Log("update leard board"); // v11.0
        else Debug.Log("unable update leard board"); // v11.0
    }

    public void mostraranking()   // v11.0
    {
        Debug.Log("mostrar ranking ");
        autenticado.text = "mostrando.... ";
        if (!connetedagoogleplay)
        {
            // iniciar_seccion();
            LoginGooglePlayGames();
            autenticado.text = "lo lograstes cabron ".ToString();
            autenticado.text = "mo funciono  lorra cabron ";
        }
        else
        {
            autenticado.text = "funciono  ".ToString();
            autenticado.text = " funciono papi ";
            Social.Active.ShowLeaderboardUI();
            Social.ShowLeaderboardUI();// esto muestra la tabla
                                       ///// PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_papus);
        }

        //Social.Active.ShowLeaderboardUI();
        // Social.ShowLeaderboardUI();// esto muestra la tabla
        //  PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_papus);

        //((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CggIjZ3YqgcQAhAB");
        // ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(GPGSIds.leaderboard_papus_topgg);
        // Debug.Log("RANKING EN PANTALLA feliz ");
    }

    public void nivel1()
    {

        Debug.Log("logro nivel 1  god farmer");
        autenticado.text = "mostrando.... ";
        if (!connetedagoogleplay)
        {
            // iniciar_seccion();
            LoginGooglePlayGames();
            autenticado.text = "lo lograstes cabron ".ToString();
            autenticado.text = "mo funciono  lorra cabron ";
        }
        else
        {
            Social.ReportProgress("CgkIyKSG2scGEAIQAg", 100f, success => { });
        }
    }
    public void nivel2()
    {
        Debug.Log("logro nivel 2  worker");
        autenticado.text = "mostrando.... ";
        if (!connetedagoogleplay)
        {
            // iniciar_seccion();
            LoginGooglePlayGames();
            autenticado.text = "lo lograstes cabron ".ToString();
            autenticado.text = "mo funciono  lorra cabron ";
        }
        else
        {
            Social.ReportProgress("CgkIyKSG2scGEAIQAw", 100f, success => { });
        }
    }
    public void nivel3()
    {
        Debug.Log("logro nivel 3  montañista ");
        autenticado.text = "mostrando.... ";
        if (!connetedagoogleplay)
        {
            // iniciar_seccion();
            LoginGooglePlayGames();
            autenticado.text = "lo lograstes cabron ".ToString();
            autenticado.text = "mo funciono  lorra cabron ";
        }
        else
        {
            Social.ReportProgress("CgkIyKSG2scGEAIQBA", 100f, success => { });
        }
    }
    public void nivel4()
    {
        Debug.Log("logro nivel 4  elite");
        autenticado.text = "mostrando.... ";
        if (!connetedagoogleplay)
        {
            // iniciar_seccion();
            LoginGooglePlayGames();
            autenticado.text = "lo lograstes cabron ".ToString();
            autenticado.text = "mo funciono  lorra cabron ";
        }
        else
        {
            Social.ReportProgress("CgkIyKSG2scGEAIQBQ", 100f, success => { });
        }
    }
    public void nivel5()
    {
        Debug.Log("logro nivel 5 win  ");
        autenticado.text = "mostrando.... ";
        if (!connetedagoogleplay)
        {
            // iniciar_seccion();
            LoginGooglePlayGames();
            autenticado.text = "lo lograstes cabron ".ToString();
            autenticado.text = "mo funciono  lorra cabron ";
        }
        else
        {
            Social.ReportProgress("CgkIyKSG2scGEAIQBg", 100f, success => { });
        }
    }
}
