namespace DDD.Logic
{
    public class Money : ValueObject<Money>
    {
        public readonly static Money None = new Money(0, 0, 0, 0, 0, 0);
        public readonly static Money OneCent = new Money(1, 0, 0, 0, 0, 0);
        public readonly static Money TenCent = new Money(0, 1, 0, 0, 0, 0);
        public readonly static Money QuarterCent = new Money(0, 0, 1, 0, 0, 0);
        public readonly static Money OneDollar = new Money(0, 0, 0, 1, 0, 0);
        public readonly static Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);
        public readonly static Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);

        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuarterCount { get; }
        public int OneDollarCount { get; }
        public int FiveDollarCount { get; }
        public int TwentyDollarCount { get; }
        public decimal Amount
        {
            get
            {
                return OneCentCount * 0.01m +
                       TenCentCount * 0.1m +
                       QuarterCount * 0.25m +
                       OneDollarCount +
                       FiveDollarCount * 5 +
                       TwentyDollarCount * 20;
            }
        }

        public Money(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            if (oneCentCount < 0)
                throw new InvalidOperationException();
            if (tenCentCount < 0)
                throw new InvalidOperationException();
            if (quarterCount < 0)
                throw new InvalidOperationException();
            if (oneDollarCount < 0)
                throw new InvalidOperationException();
            if (fiveDollarCount < 0)
                throw new InvalidOperationException();
            if (twentyDollarCount < 0)
                throw new InvalidOperationException();

            OneCentCount += oneCentCount;
            TenCentCount += tenCentCount;
            QuarterCount += quarterCount;
            OneDollarCount += oneDollarCount;
            FiveDollarCount += fiveDollarCount;
            TwentyDollarCount += twentyDollarCount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.OneCentCount + money2.OneCentCount,
                money1.TenCentCount + money2.TenCentCount,
                money1.QuarterCount + money2.QuarterCount,
                money1.OneDollarCount + money2.OneDollarCount,
                money1.FiveDollarCount + money2.FiveDollarCount,
                money1.TwentyDollarCount + money2.TwentyDollarCount
                );

            return sum;
        }

        public static Money operator -(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.OneCentCount - money2.OneCentCount,
                money1.TenCentCount - money2.TenCentCount,
                money1.QuarterCount - money2.QuarterCount,
                money1.OneDollarCount - money2.OneDollarCount,
                money1.FiveDollarCount - money2.FiveDollarCount,
                money1.TwentyDollarCount - money2.TwentyDollarCount
                );

            return sum;
        }


        #region Method

        protected override bool EqualsCore(Money core)
        {
            return
                OneCentCount == core.OneCentCount &&
                TenCentCount == core.TenCentCount &&
                QuarterCount == core.QuarterCount &&
                OneDollarCount == core.OneDollarCount &&
                FiveDollarCount == core.FiveDollarCount &&
                TwentyDollarCount == core.TwentyDollarCount;
        }
        protected override int GetHashCodeCore()
        {
            int hashCode = OneCentCount;
            hashCode = (hashCode * 397) ^ OneCentCount;
            hashCode = (hashCode * 397) ^ TenCentCount;
            hashCode = (hashCode * 397) ^ QuarterCount;
            hashCode = (hashCode * 397) ^ OneDollarCount;
            hashCode = (hashCode * 397) ^ FiveDollarCount;
            hashCode = (hashCode * 397) ^ TwentyDollarCount;

            return hashCode;
        }

        public override string ToString()
        {
            if(Amount < 1)
                return (Amount * 100).ToString("0") + " Cent";

            return "$" + Amount.ToString("0.00");
            
        }

        #endregion
    }
}
