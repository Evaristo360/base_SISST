using System.ComponentModel;

namespace Comunes.Enumerables
{

    public enum enumMensajeCuentaCaracteres : int
    {
        [Description("caracteres restantes para este campo.")]
        Mensaje1 = 1,
    }

    /// <summary>
    /// Operadores de comparación genérica
    /// </summary>
    /// <remarks>
    /// Desarrollado por
    ///     Juan Miguel González Castro
    ///     Septiembre 2021
    /// </remarks>
    public enum GenericCompareOperator
    {
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual
    }

}
