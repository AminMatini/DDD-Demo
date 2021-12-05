namespace DDD.Logic
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public override bool Equals(object? obj)
        {
            var other = obj as Entity;

            if(ReferenceEquals(null, other)) return false;

            if(ReferenceEquals (this, other)) return true;

            if(GetType() != other.GetType()) return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a , Entity b)
        {
            if(ReferenceEquals(a , null) && ReferenceEquals(b , null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a , Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }


}
