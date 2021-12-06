using static DDD.Logic.Money;

namespace DDD.Logic
{
    public sealed class SnackMachine : Entity
    {
        #region Properties

        public Money MoneyInside { get; private set; } = None;
        public Money MoneyInTransaction { get; private set; } = None;

        #endregion

        #region Method

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = { OneCent, TenCent, QuarterCent, OneDollar, FiveDollar, TwentyDollar };

            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = Money.None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;

            // MoneyInTransaction = 0;
        }

        #endregion
    }
}
