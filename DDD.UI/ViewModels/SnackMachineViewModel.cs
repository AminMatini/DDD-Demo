using DDD.Logic;
using DDD.UI.Common;
using DDD.UI.ViewModels.Common;

namespace DDD.UI.ViewModels
{
    public class SnackMachineViewModel : BaseViewModel
    {
        #region Constructor

        public SnackMachineViewModel()
        {
            this._snackMachine = new SnackMachine();
            InsertOneCentMoneyCommand = new Command(() => InsertMoney(Money.OneCent));
            InsertTenCentMoneyCommand = new Command(() => InsertMoney(Money.TenCent));
            InsertQuarterCentMoneyCommand = new Command(() => InsertMoney(Money.QuarterCent));
            InsertOneDollarMoneyCommand = new Command(() => InsertMoney(Money.OneDollar));
            InsertFiveDollarMoneyCommand = new Command(() => InsertMoney(Money.FiveDollar));
            InsertTwentyDollarMoneyCommand = new Command(() => InsertMoney(Money.TwentyDollar));
            ReturnMoneyCommand = new Command(() => ReturnMoney());
            BuySnackCommand = new Command(() => BuySnack());
        }

        #endregion

        #region Properties

        private readonly SnackMachine _snackMachine;
        public override string PageTitle => "Snack Machin Page";
        public string MoneyInTranaction => _snackMachine.MoneyInTransaction.ToString();
        public string MoneyInSideAmount => MoneyInSide.Amount.ToString();
        public Money MoneyInSide => _snackMachine.MoneyInside + _snackMachine.MoneyInTransaction;

        #endregion

        #region Command

        public Command InsertOneCentMoneyCommand { get; set; }
        public Command InsertTenCentMoneyCommand { get; set; }
        public Command InsertQuarterCentMoneyCommand { get; set; }
        public Command InsertOneDollarMoneyCommand { get; set; }
        public Command InsertFiveDollarMoneyCommand { get; set; }
        public Command InsertTwentyDollarMoneyCommand { get; set; }
        public Command ReturnMoneyCommand { get; set; }
        public Command BuySnackCommand { get; set; }

        #endregion

        #region Method

        private void InsertMoney(Money money)
        {
            this._snackMachine.InsertMoney(money);
            NotifyClient();
        }

        private void ReturnMoney()
        {
            this._snackMachine.ReturnMoney();
            NotifyClient();
        }

        public void BuySnack()
        {
            this._snackMachine.BuySnack();
            NotifyClient();


        }

        public void NotifyClient()
        {
            Notify(nameof(MoneyInTranaction));
            Notify(nameof(MoneyInSide));
            Notify(nameof(MoneyInSideAmount));
        }

        #endregion
    }
}
