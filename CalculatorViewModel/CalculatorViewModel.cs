using System;
using System.ComponentModel;
using System.Windows.Input;

namespace CalculatorViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private Operator currentOperator;
        private double firstNumber;
        private double secondNumber;

        private string txtResult = "0";
        public string TxtResult
        {
            get
            {
                return txtResult;
            }
            set
            {
                if (value != txtResult)
                {
                    txtResult = value;
                    OnPropertyChanged(nameof(TxtResult));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TxtResult)));
        }

        
        private readonly DelegateCommand _numComamnd;
        private readonly DelegateCommand _oprComamnd;
        private readonly DelegateCommand _resultComamnd;
        private readonly DelegateCommand _resetComamnd;

        public ICommand NumComamnd => _numComamnd;
        public ICommand OprComamnd => _oprComamnd;
        public ICommand ResultComamnd => _resultComamnd;
        public ICommand ResetComamnd => _resetComamnd;

        /// <summary>
        /// 
        /// </summary>
        public CalculatorViewModel()
        {
            _numComamnd = new DelegateCommand(OnNumClick);
            _oprComamnd = new DelegateCommand(OnOperatorClick);
            _resetComamnd = new DelegateCommand(OnResetClick);
            _resultComamnd = new DelegateCommand(OnResultClick);

        }

        private void OnNumClick(object commandParameter)
        {
            if (TxtResult != "0")
            {
                TxtResult = $"{TxtResult}{commandParameter}";
            }
            else
            {
                TxtResult = commandParameter.ToString();
            }
        }

        private void OnOperatorClick(object commandParameter)
        {
            try
            {
                switch (commandParameter)
                {
                    case "+":
                        currentOperator = Operator.Add;
                        break;
                    case "-":
                        currentOperator = Operator.Substract;
                        break;
                    case "*":
                        currentOperator = Operator.Multiply;
                        break;
                    case "/":
                        currentOperator = Operator.Divide;
                        break;
                    default:
                        break;
                }
                firstNumber = double.Parse(TxtResult);
                TxtResult = "0";
            }
            catch (Exception)
            {

            }
            
        }

        private void OnResetClick(object commandParameter)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentOperator = 0;
            TxtResult = "0";
        }
        private void OnResultClick(object commandParameter)
        {
            secondNumber = double.Parse(TxtResult);
            TxtResult = GetResult(firstNumber, currentOperator, secondNumber);
        }

        public enum Operator
        {
            Add,
            Substract,
            Multiply,
            Divide
        }

        private string GetResult(double firstNumber, Operator currentOperator, double secondNumber)
        {
            try
            {
                if (currentOperator == Operator.Add)
                {
                    return (firstNumber + secondNumber).ToString();
                }
                else if (currentOperator == Operator.Substract)
                {
                    return (firstNumber - secondNumber).ToString();
                }
                else if (currentOperator == Operator.Multiply)
                {
                    return (firstNumber * secondNumber).ToString();
                }
                else if (currentOperator == Operator.Divide)
                {
                    return (firstNumber / secondNumber).ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception)
            {

                return "0";
            }
           
        }
    }


    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _executeAction;

        public DelegateCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
        }

        public void Execute(object parameter) => _executeAction(parameter);

        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;
    }

}
