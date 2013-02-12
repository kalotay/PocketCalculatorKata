namespace PocketCalculator
{
    public class CasioCalculator
    {
        public enum OperationFlags
        {
            None,
            Add,
            Sub,
            Mul,
            Div
        }

        public CasioCalculator()
        {
            _mainRegister = new DecimalRegister();
            _auxRegitser = new DecimalRegister();
            _memoryRegister = new DecimalRegister();
        }

        public decimal Display { get { return _mainRegister.ToDecimal(); } }

        private readonly DecimalRegister _mainRegister;
        private readonly DecimalRegister _auxRegitser;
        private bool _flush;
        private bool _resetScan;
        private readonly DecimalRegister _memoryRegister;
        private OperationFlags _operationFlag;

        public void PressAC()
        {
            _mainRegister.Clear();
            _auxRegitser.Clear();
        }

        public void PressDigit(Digits digit)
        {
            MaybeFlush();
            if (_resetScan)
            {
                _mainRegister.Clear();
                _resetScan = false;
            }

            _mainRegister.Push(digit);
        }

        public void PressEqual()
        {
            PressBinaryOperation(OperationFlags.None);
        }

        public void PressPlus()
        {
            PressBinaryOperation(OperationFlags.Add);
        }

        public void PressMinus()
        {
            PressBinaryOperation(OperationFlags.Sub);
        }

        public void PressStar()
        {
            PressBinaryOperation(OperationFlags.Mul);
        }

        public void PressSlash()
        {
            PressBinaryOperation(OperationFlags.Div);
        }

        public void PressPlusMinus()
        {
            MaybeFlush();
            _mainRegister.ChangeSign();
        }

        public void PressDot()
        {
        }

        public void PressC()
        {
            _mainRegister.Clear();
        }

        public void PressMPlus()
        {
            PressBinaryOperation(OperationFlags.None);
            _memoryRegister.Add(_memoryRegister, _mainRegister);
        }

        public void PressMMinus()
        {
            PressBinaryOperation(OperationFlags.None);
            _memoryRegister.Sub(_memoryRegister, _mainRegister);
        }

        public void PressMR()
        {
            _mainRegister.Copy(_memoryRegister);
        }

        public void PressSqrt()
        {
            _mainRegister.Sqrt();
        }

        public void PressBinaryOperation(OperationFlags operation)
        {
            switch (_operationFlag)
            {
                case OperationFlags.Add:
                    _mainRegister.Add(_auxRegitser, _mainRegister);
                    break;
                case OperationFlags.Sub:
                    _mainRegister.Sub(_auxRegitser, _mainRegister);
                    break;
                case OperationFlags.Mul:
                    _mainRegister.Mul(_auxRegitser, _mainRegister);
                    break;
                case OperationFlags.Div:
                    _mainRegister.Div(_auxRegitser, _mainRegister);
                    break;
            }
            _operationFlag = operation;
            _flush = true;
            _resetScan = true;
        }

        private void MaybeFlush()
        {
            if (!_flush) return;
            _auxRegitser.Copy(_mainRegister);
            _flush = false;
        }
    }
}