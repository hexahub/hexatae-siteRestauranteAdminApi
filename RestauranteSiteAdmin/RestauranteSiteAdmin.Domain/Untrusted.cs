using System;

namespace RestauranteSiteAdmin.Domain
{
    public struct Untrusted<T>
    {
        private readonly T _value;

        private Untrusted(T value)
        {
            _value = value;
        }

        public static implicit operator Untrusted<T>(T value)
            => new Untrusted<T>(value);

        public TR Validate<TR>(Func<T, bool> validator, Func<T, TR> success, Func<T, TR> fail)
            => validator(_value)
                ? success(_value)
                : fail(_value);
    }

    public static class Untrusted
    {
        public static Untrusted<T> Of<T>(T value)
            => value;
    }
}
