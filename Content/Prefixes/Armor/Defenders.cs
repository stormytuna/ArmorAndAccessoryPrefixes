﻿using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor {
    public class Defenders : ArmorPrefix {
        public override bool CanRoll(Item item) => item.headSlot > 0;

        public override void ModifyValue(ref float valueMult) => valueMult = 1.3759f;

        public override void Apply(Item item) {
            base.Apply(item);

            item.GetGlobalItem<ArmorGlobalItem>().SentrySlots = 1;
        }

        public override string Name => "Defender's";
    }
}
