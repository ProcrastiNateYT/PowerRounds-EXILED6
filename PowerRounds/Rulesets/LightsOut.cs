using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;

namespace PowerRounds.Rulesets
{
    internal class LightsOut
    {
        internal static void prLightsOut()
        {
            /*
             * Turn off all the lights.
             * Give every player a flashlight.
             * Round continues as normal.
             */
            
            Timing.CallDelayed(5f, () =>
            {
                Cassie.MessageTranslated("Warning . Complete lighting system failure . Proceed with caution .", "WARNING! Complete lighting system failure! Proceed with caution." );
                Map.TurnOffAllLights(float.PositiveInfinity, Exiled.API.Enums.ZoneType.Unspecified);
            });
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.NewRole.IsHuman() == true)
            {
                ev.Items.Add(ItemType.Flashlight);
            }
            else return;
        }
    }
}
