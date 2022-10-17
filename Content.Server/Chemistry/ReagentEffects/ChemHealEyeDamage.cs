using Content.Shared.Chemistry.Reagent;
using Content.Shared.Eye.Blinding;
using JetBrains.Annotations;

namespace Content.Server.Chemistry.ReagentEffects
{
    /// <summary>
    /// Heal eye damage (or deal)
    /// </summary>
    [UsedImplicitly]
    public sealed class ChemHealEyeDamage : ReagentEffect
    {
        /// <summary>
        /// Add or remove eye damage?
        [DataField("add")]
        public bool Add = false;

        public override void Effect(ReagentEffectArgs args)
        {
            if (args.MetabolismEffects != null && args.Quantity < args.MetabolismEffects.MetabolismRate)
                return; // the metabolism rate is the minimum needed to change eye damage

            EntitySystem.Get<SharedBlindingSystem>().AdjustEyeDamage(args.SolutionEntity, Add);
        }
    }
}
