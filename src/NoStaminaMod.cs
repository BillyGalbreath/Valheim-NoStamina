using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace NoStamina {
    [BepInPlugin("billy.NoStamina", "NoStamina", "0.0.1")]
    public class NoStaminaMod : BaseUnityPlugin {
        protected void Awake() {
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch]
    internal class StaminaPatch {
        [HarmonyPatch(typeof(Player), "UseStamina"), HarmonyPostfix]
        private static void PostUseStamina(ref float ___m_stamina) {
            ___m_stamina = 1000f;
        }
    }
}
