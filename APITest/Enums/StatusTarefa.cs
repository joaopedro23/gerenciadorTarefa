using System.ComponentModel;

namespace APITest.Enums
{
    public enum StatusTarefa
    {
        [Description("a FAZER")]
        AFzaer = 1,
        [Description("EM andamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3
    }
}
