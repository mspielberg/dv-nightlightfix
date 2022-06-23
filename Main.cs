using UnityModManagerNet;

namespace DvMod.NightLightFix
{
    [EnableReloading]
    public static class Main
    {
        public static UnityModManager.ModEntry? mod;

        static public bool Load(UnityModManager.ModEntry modEntry)
        {
            mod = modEntry;

            modEntry.OnToggle = OnToggle;

            return true;
        }

        static private bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            if (value)
            {
                NightLightFix.InstallCallbacks();
            }
            else
            {
                NightLightFix.RemoveCallbacks();
            }
            return true;
        }
    }
}
