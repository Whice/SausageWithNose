using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public struct LootComponent
{
    /// <summary>
    /// Тип генерируемого объекта.
    /// </summary>
    public Int32 type;

    public override string ToString()
    {
        return "LC type = " + this.type.ToString();
    }
}
