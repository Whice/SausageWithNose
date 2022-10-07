using UnityEngine;
using Voody.UniLeo;

internal class LootComponentProvider : MonoProvider<LootComponent>
{
    public ref LootComponent GetLootComponent()
    {
        return ref this.value;
    }
}