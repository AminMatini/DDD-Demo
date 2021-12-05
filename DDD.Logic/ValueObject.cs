namespace DDD.Logic
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        protected abstract bool EqualsCore(T core);
        public override bool Equals(object? obj)
        {
            var valueObject = obj as T;

            if(ReferenceEquals(valueObject , null))
                return false;

            return EqualsCore(valueObject);
        }

        protected abstract int GetHashCodeCore();

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        public static bool operator==(ValueObject<T> a , ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a , ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
