using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace CosyValuables;

[BepInPlugin("Wexop.CosyValuables", "CosyValuables", "1.0.1")]
public class Plugin : BaseUnityPlugin
{
    internal static Plugin Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger => Instance._logger;
    private ManualLogSource _logger => base.Logger;
    internal Harmony? Harmony { get; set; }

    private void Awake()
    {
        Instance = this;
        
        // Prevent the plugin from being deleted
        this.gameObject.transform.parent = null;
        this.gameObject.hideFlags = HideFlags.HideAndDontSave;

        LoadValuables();

        Logger.LogInfo($"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!");
    }

    private void LoadValuables()
    {
        string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "cozyvaluables");
        

        REPOLib.BundleLoader.LoadBundle(assetDir, assetBundle => 
        {
            //COFFEE
            var COFFEE = assetBundle.LoadAsset<GameObject>("Assets/REPO/Mods/CozyValuables/CozyCoffee.prefab");
            REPOLib.Modules.Valuables.RegisterValuable(COFFEE);
            
            //AQUARIUM
            var AQUARIUM = assetBundle.LoadAsset<GameObject>("Assets/REPO/Mods/CozyValuables/Aquarium.prefab");
            REPOLib.Modules.Valuables.RegisterValuable(AQUARIUM);
            
            //CANDLES
            var CANDLES = assetBundle.LoadAsset<GameObject>("Assets/REPO/Mods/CozyValuables/Candles.prefab");
            REPOLib.Modules.Valuables.RegisterValuable(CANDLES);
            
            //GREEN_CANDLES
            var GREEN_CANDLES = assetBundle.LoadAsset<GameObject>("Assets/REPO/Mods/CozyValuables/GreenCandles.prefab");
            REPOLib.Modules.Valuables.RegisterValuable(GREEN_CANDLES);
            
            //DISCO_BALL
            var DISCO_BALL = assetBundle.LoadAsset<GameObject>("Assets/REPO/Mods/CozyValuables/DiscoBall.prefab");
            REPOLib.Modules.Valuables.RegisterValuable(DISCO_BALL);
        });
        
    }
}