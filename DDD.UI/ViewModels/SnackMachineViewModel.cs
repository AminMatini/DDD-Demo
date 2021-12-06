using DDD.Logic;
using DDD.UI.Common;
using DDD.UI.ViewModels.Common;

namespace DDD.UI.ViewModels
{
    public class SnackMachineViewModel : BaseViewModel
    {
        #region Constructor

        private readonly SnackMachine _snackMachine;
        public SnackMachineViewModel()
        {
            this._snackMachine = new SnackMachine();
            InsertOneCentMoneyCommand = new Command(() => InsertOneCent());
            InsertTenCentMoneyCommand = new Command(() => InsertTenCent());
            InsertQuarterCentMoneyCommand = new Command(() => InsertQuarterCent());
            InsertOneDollarMoneyCommand = new Command(() => InsertOneDollar());
            InsertFiveDollarMoneyCommand = new Command(() => InsertFiveDollar());
            InsertTwentyDollarMoneyCommand = new Command(() => InsertTwentyDollar());
        }

        #endregion

        #region Properties

        public override string PageTitle => "Snack Machin Page";
        public string MoneyInTranaction => _snackMachine.MoneyInTransaction.ToString();
        public Command InsertOneCentMoneyCommand { get; set; }
        public Command InsertTenCentMoneyCommand { get; set; }
        public Command InsertQuarterCentMoneyCommand { get; set; }
        public Command InsertOneDollarMoneyCommand { get; set; }
        public Command InsertFiveDollarMoneyCommand { get; set; }
        public Command InsertTwentyDollarMoneyCommand { get; set; }

        #endregion

        #region Method

        private void InsertOneCent()
        {
            this._snackMachine.InsertMoney(Money.OneCent);
            Notify("MoneyInTranaction");
        }

        private void InsertTenCent()
        {
            this._snackMachine.InsertMoney(Money.TenCent);
            Notify("MoneyInTranaction");
        }

        private void InsertQuarterCent()
        {
            this._snackMachine.InsertMoney(Money.QuarterCent);
            Notify("MoneyInTranaction");
        }

        private void InsertOneDollar()
        {
            this._snackMachine.InsertMoney(Money.OneDollar);
            Notify("MoneyInTranaction");
        }

        private void InsertFiveDollar()
        {
            this._snackMachine.InsertMoney(Money.FiveDollar);
            Notify("MoneyInTranaction");
        }

        private void InsertTwentyDollar()
        {
            this._snackMachine.InsertMoney(Money.TwentyDollar);
            Notify("MoneyInTranaction");
        }


        #endregion
    }
}
