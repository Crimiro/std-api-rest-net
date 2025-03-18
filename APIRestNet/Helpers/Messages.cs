using System;

namespace APIRestNet.Helpers;

public static class Messages
{
    public static class Cat
    {
        public const string NotFound = "El gato solicitado no existe.";
    }

    public static class Skill
    {
        public const string NotFound = "La habilidad solicitada no existe.";
        public const string Found = "La habilidad ya existe.";
    }
}
